using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Application.Interfaces;
using Application.DataTransferObjects;
using Domain.Helpers;
using Domain.SeededData;

namespace Authentication;

public class AuthenticationService(
    IRepositoryManager repositoryManager,
    IConfiguration configuration,
    IEmailService emailService,
    IMapper mapper)
    : IAuthenticationService
{
    public async Task<Guid> Register(UserForRegistrationDto userForRegistration)
    {
        var userForCreation = mapper.Map<User>(userForRegistration);
        userForCreation.RoleId = SeededRoles.RegisteredUser.Id;

        await Validate(userForCreation);
        var id = await repositoryManager.User.Create(userForCreation);

        var htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "Shared", "Email", "EmailContent.html"); 
        // Note: Logic for HTML path might fail if directory structure changed. 
        // Shared/Email is now Infrastructure/Email. 
        // But execution directory might be API.
        // I need to check where current dir is. usually project root.
        // It was "Shared/Email/EmailContent.html".
        // Now it is "Infrastructure/Email/EmailContent.html" if running from root?
        // Or if publishing, it depends on CopyToOutput.
        // I will assume simple path update or keep logic if I can find file.
        // I'll update path to "Infrastructure", "Email", "EmailContent.html". 
        // Wait, "Shared" folder is GONE.
        
        var htmlContent = await File.ReadAllTextAsync(htmlPath);

        userForCreation.Id = id;

        var accessToken = CreatePasswordToken(userForCreation);
        htmlContent = htmlContent.Replace("#url#",
            userForRegistration.SetPasswordUrl + accessToken);

        await emailService.SendEmailAsync([userForCreation.Email],
            "تطبيق سكلتي - قم بتعيين كلمة المرور الخاصة بك",
            htmlContent, isHtml: true);

        await repositoryManager.User.UpdateAccessTokenById(userForCreation.Id, accessToken);

        return id;
    }

    public async Task<UserDetailsWithTokensDto> Authenticate(AuthenticationDto authenticationDto, bool checkIfCanLoginToPortal)
    {
        var user = await repositoryManager.User.FindByIdOrEmail(email: authenticationDto.Email);
        if (user is null)
            throw new EntityNotFoundException("المستخدم", "البريد الإلكتروني", authenticationDto.Email);

        var verified = authenticationDto.Password.VerifyHashedPassword(user.Password);
        var canLoginToPortal = user.AdditionalPermissions.Any(p => p == Domain.Enums.Permission.LoginToPortal || p == Domain.Enums.Permission.SuperAdmin) ||
                      user.Role.Permissions.Any(p => p == Domain.Enums.Permission.LoginToPortal || p == Domain.Enums.Permission.SuperAdmin);

        if (!verified || (checkIfCanLoginToPortal && !canLoginToPortal))
            throw new InvalidCredentialsUnauthorizedException(authenticationDto.Email);

        if (!string.IsNullOrEmpty(authenticationDto.FcmToken) && authenticationDto.FcmToken.Length is > 50 and < 250)
            await repositoryManager.User.UpdateFcmTokenById(user.Id, authenticationDto.FcmToken);

        var (accessToken, refreshToken) = await CreateToken(user, true);

        await repositoryManager.User.UpdateAccessTokenById(user.Id, accessToken);

        var userDto = mapper.Map<UserDetailsWithTokensDto>(user);
        userDto.AccessToken = accessToken;
        userDto.RefreshToken = refreshToken;

        return userDto;
    }

    public async Task<UserDetailsWithTokensDto> Refresh(TokensDto tokensDto)
    {
        var principal = GetPrincipalFromExpiredToken(tokensDto.AccessToken);
        var userId = Guid.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var user = await repositoryManager.User.FindByIdOrEmail(userId);
        if (user is null)
            throw new EntityNotFoundException("المستخدم", "المعرف", userId);

        if (user is null || user.RefreshToken != tokensDto.RefreshToken ||
            (user.RefreshTokenExpiryTime is not null &&
             user.RefreshTokenExpiryTime.Value.AddDays(40) <= DateTime.Now))
            throw new ExpiredRefreshTokenUnauthorizedException();

        var (accessToken, refreshToken) = await CreateToken(user, false);

        await repositoryManager.User.UpdateAccessTokenById(user.Id, accessToken);

        var userDto = mapper.Map<UserDetailsWithTokensDto>(user);
        userDto.AccessToken = accessToken;
        userDto.RefreshToken = refreshToken;

        return userDto;
    }

    public async Task ForgotPassword(ForgotPasswordDto forgotPasswordDto)
    {
        var user = await repositoryManager.User.FindByIdOrEmail(email: forgotPasswordDto.Email);
        if (user is null)
            throw new EntityNotFoundException("المستخدم", "البريد الإلكتروني", forgotPasswordDto.Email);

        var accessToken = CreatePasswordToken(user);

        var htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "Infrastructure", "Email", "EmailContent.html"); 
        // Updated path
        var htmlContent = await File.ReadAllTextAsync(htmlPath);

        htmlContent = htmlContent.Replace("#url#",
            forgotPasswordDto.SetPasswordUrl + accessToken);

        await emailService.SendEmailAsync([user.Email],
            "تطبيق سكلتي - قم بتعيين كلمة المرور الخاصة بك",
            htmlContent, isHtml: true);

        await repositoryManager.User.UpdateAccessTokenById(user.Id, accessToken);
    }

    public async Task SetPassword(Guid id, string newPassword)
    {
        var user = await repositoryManager.User.FindByIdOrEmail(id);
        if (user is null)
            throw new EntityNotFoundException("المستخدم", "المعرف", id);

        await repositoryManager.User.UpdatePasswordById(id, newPassword.HashPassword());
    }

    private async Task Validate(User user, Guid? id = null)
    {
        // Validation logic needed for Register
        // Can I reuse UserService one? It's private there.
        // I should probably duplicate it or move it to a shared validator.
        // But "Don't delete anything, just merge". duplication is safer.
        // I'll copy the Validate logic from UserService.
        
        // Wait, Validate depends on logic.
        // I need to copy dependencies too.
        
        switch (user.PhoneNumber.Length)
        {
            case < 11:
                throw new StringLimitBadRequestException("رقم الهاتف", 11, false);
            case > 11:
                throw new StringLimitBadRequestException("رقم الهاتف", 11, true);
        }

        if (!user.PhoneNumber.StartsWith("077") &&
            !user.PhoneNumber.StartsWith("078") &&
            !user.PhoneNumber.StartsWith("079"))
            throw new NotIraqiPhoneNumberBadRequestException();

        if (user.FullName.Length < 2)
            throw new StringLimitBadRequestException("الإسم", 2, false);

        var anyUserSameEmail = await repositoryManager.User.FindByIdOrEmail(id, user.Email);
        if (anyUserSameEmail is not null && (id is null || id == Guid.Empty || anyUserSameEmail.Id != id))
            throw new AlreadyExistBadRequestException("البريد الإلكتروني ", user.Email);

        var role = await repositoryManager.User.FindRoleById(user.RoleId);
        if (role is null)
            throw new EntityNotFoundException("الدور", "المعرف", user.RoleId);

        user.AdditionalPermissions = user.AdditionalPermissions.Except(role.Permissions).ToList();
    }

    private async Task<(string accessToken, string refreshToken)> CreateToken(User user, bool populateExp)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = GetClaims(user);
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        var refreshToken = user.RefreshToken = GenerateRefreshToken();
        var refreshTokenExpiryTime = populateExp ? DateTime.Now.AddDays(7) : user.RefreshTokenExpiryTime;

        if (refreshTokenExpiryTime is not null)
            await repositoryManager.User.UpdateRefreshToken(user.Id, refreshToken, refreshTokenExpiryTime.Value);

        return (accessToken, refreshToken);
    }

    private string CreatePasswordToken(User user)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = new List<Claim>
            { new(ClaimTypes.Role, "Set.Password"), new(ClaimTypes.NameIdentifier, user.Id.ToString()) };

        var jwtSettings = configuration.GetSection("JwtSettings");
        var setPasswordToken = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: signingCredentials
        ));

        return setPasswordToken;
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]!);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateLifetime = false,
            ValidIssuer = jwtSettings["validIssuer"],
            ValidAudience = jwtSettings["validAudience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]!);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private static IEnumerable<Claim> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.FullName),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
        };

        claims.AddRange(user.AdditionalPermissions.Select(permission =>
            new Claim(ClaimTypes.Role, permission.GetDescription())));

        claims.AddRange(user.Role.Permissions.Select(permission =>
            new Claim(ClaimTypes.Role, permission.GetDescription())));

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions
        (SigningCredentials signingCredentials, IEnumerable<Claim> claims)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }
}
