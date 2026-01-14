using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Entities.Enums;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using Shared.DataTransferObjects;
using Shared.Helpers;
using Shared.RequestFeatures;
using Shared.SeededData;
using Action = Entities.Enums.Action;

namespace Services;

public class UserService(
    IRepositoryManager repositoryManager,
    IConfiguration configuration,
    IEmailService emailService,
    IMapper mapper)
    : IUserService
{
    public async Task<Guid> Register(UserForRegistrationDto userForRegistration)
    {
        var userForCreation = mapper.Map<User>(userForRegistration);
        userForCreation.RoleId = SeededRoles.RegisteredUser.Id;

        await Validate(userForCreation);
        var id = await repositoryManager.User.Create(userForCreation);

        var htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "Shared", "Email", "EmailContent.html");
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

    public async Task<Guid> Create(UserForAdminManipulationDto userForCreate, Guid userId)
    {
        var userForCreation = mapper.Map<User>(userForCreate);
        await Validate(userForCreation);

        userForCreation.AddedByUserId = userId;
        userForCreation.Password = userForCreate.Password.HashPassword();
        var id = await repositoryManager.User.Create(userForCreation);

        return id;
    }

    private async Task Validate(User user, Guid? id = null)
    {
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

    public async Task<UserDetailsWithTokensDto> Authenticate(AuthenticationDto authenticationDto, bool checkIfCanLoginToPortal)
    {
        var user = await repositoryManager.User.FindByIdOrEmail(email: authenticationDto.Email);
        if (user is null)
            throw new EntityNotFoundException("المستخدم", "البريد الإلكتروني", authenticationDto.Email);

        var verified = authenticationDto.Password.VerifyHashedPassword(user.Password);
        var canLoginToPortal = user.AdditionalPermissions.Any(p => p == Permission.LoginToPortal || p == Permission.SuperAdmin) ||
                      user.Role.Permissions.Any(p => p == Permission.LoginToPortal || p == Permission.SuperAdmin);

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

    public IEnumerable<PermissionDto> GetAllPermissions()
    {
        var permissions = Enum.GetValues(typeof(Permission))
            .Cast<Permission>()
            .Select(permission => mapper.Map<PermissionDto>(permission));

        return permissions;
    }

    public async Task<PagedList<UserDto>> GetByParameters(UsersParameters usersParameters)
    {
        var (users, count) = await repositoryManager.User.FindByParameters(usersParameters);
        var usersDto = mapper.Map<List<UserDto>>(users);

        var userDtoPagedList = new PagedList<UserDto>(usersDto, count,
            usersParameters.PageNumber, usersParameters.PageSize);

        return userDtoPagedList;
    }

    public async Task<UserDetailsDto> GetById(Guid id)
    {
        var user = await repositoryManager.User.FindByIdOrEmail(id);

        if (user is null)
            throw new EntityNotFoundException("المستخدم", "المعرف", id);

        var userDto = mapper.Map<UserDetailsDto>(user);
        return userDto;
    }

    public async Task Update(Guid id, UserForAdminManipulationDto userForAdminManipulation, Guid userId)
    {
        var oldUser = await repositoryManager.User.FindByIdOrEmail(id);
        if (oldUser is null)
            throw new EntityNotFoundException("المستخدم", "المعرف", id);

        var newUser = mapper.Map<UserForAdminManipulationDto, User>(userForAdminManipulation);

        await Validate(newUser, id);

        newUser.Id = id;
        await repositoryManager.User.Update(newUser);

        // User updated successfully
    }

    public async Task UpdateLoggedIn(Guid id, UserForManipulationDto userForManipulation)
    {
        var oldUser = await repositoryManager.User.FindByIdOrEmail(id);
        if (oldUser is null)
            throw new EntityNotFoundException("المستخدم", "المعرف", id);

        var newUser = mapper.Map<UserForManipulationDto, User>(userForManipulation);

        newUser.RoleId = oldUser.RoleId;
        await Validate(newUser, id);

        newUser.Id = id;
        await repositoryManager.User.UpdateLoggedIn(newUser);

        var comparer = new ModelComparer<User>();
        var differences = comparer.Compare(oldUser, newUser);

        // User updated successfully
    }

    public async Task ChangePassword(Guid id, ChangePasswordDto changePasswordDto, Guid userId)
    {
        var user = await repositoryManager.User.FindByIdOrEmail(id);
        if (user is null)
            throw new EntityNotFoundException("المستخدم", "المعرف", id);

        if (id != userId)
        {
            var adminUser = await repositoryManager.User.FindByIdOrEmail(userId);
            if (adminUser is null)
                throw new EntityNotFoundException("المستخدم المدير", "المعرف", userId);

            var verified = changePasswordDto.LoggedInUserPassword.VerifyHashedPassword(adminUser.Password);
            if (!verified) throw new InvalidCredentialsUnauthorizedException(adminUser.Email);

            await repositoryManager.User.UpdatePasswordById(id, changePasswordDto.NewPassword.HashPassword());

            // Password updated successfully
        }
        else
        {
            var verified = changePasswordDto.LoggedInUserPassword.VerifyHashedPassword(user.Password);
            if (!verified) throw new InvalidCredentialsUnauthorizedException(user.Email);

            await repositoryManager.User.UpdatePasswordById(id, changePasswordDto.NewPassword.HashPassword());
        }
    }

    public async Task Delete(Guid id, Guid userId)
    {
        var user = await repositoryManager.User.FindByIdOrEmail(id);
        if (user is null)
            throw new EntityNotFoundException("المستخدم", "المعرف", id);

        await repositoryManager.User.Delete(id);

        // User deleted successfully
    }

    public async Task<IEnumerable<RoleDto>> GetAllRoles()
    {
        var roles = await repositoryManager.User.FindAllRoles();
        var rolesDto = mapper.Map<IEnumerable<RoleDto>>(roles);
        return rolesDto;
    }

    public async Task<RoleDto> GetRoleByIdOrDescription(Guid? id, string? description)
    {
        var role = await repositoryManager.User.FindRoleById(id, description);

        if (role is null)
            throw new EntityNotFoundException("الدور",
                description is null ? "المعرف" : "الوصف",
                description is null ? id!.Value : description);

        var roleDto = mapper.Map<RoleDto>(role);
        return roleDto;
    }

    public async Task<Guid> CreateRole(RoleForManipulationDto roleForManipulation, Guid userId)
    {
        var roleForCreation = mapper.Map<Role>(roleForManipulation);
        await ValidateRole(roleForCreation);
        var id = await repositoryManager.User.CreateRole(roleForCreation);

        return id;
    }

    public async Task UpdateRole(Guid id, RoleForManipulationDto roleForManipulation, Guid userId)
    {
        var oldRole = await repositoryManager.User.FindRoleById(id);
        if (oldRole is null)
            throw new EntityNotFoundException("الدور", "المعرف", id);

        var role = mapper.Map<Role>(roleForManipulation);

        await ValidateRole(role, id);

        role.Id = oldRole.Id;
        await repositoryManager.User.UpdateRole(id, role);

        var comparer = new ModelComparer<Role>();
        var differences = comparer.Compare(oldRole, role);

        // Role updated successfully
    }

    public async Task DeleteRole(Guid id, Guid userId)
    {
        var role = await repositoryManager.User.FindRoleById(id);
        if (role is null)
            throw new EntityNotFoundException("الدور", "المعرف", id);

        await repositoryManager.User.DeleteRole(id);

        // Role deleted successfully
    }

    public async Task ForgotPassword(ForgotPasswordDto forgotPasswordDto)
    {
        var user = await repositoryManager.User.FindByIdOrEmail(email: forgotPasswordDto.Email);
        if (user is null)
            throw new EntityNotFoundException("المستخدم", "البريد الإلكتروني", forgotPasswordDto.Email);

        var accessToken = CreatePasswordToken(user);

        var htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "Shared", "Email", "EmailContent.html");
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

    private async Task ValidateRole(Role role, Guid? id = null)
    {
        if (role.Description.Length < 3)
            throw new StringLimitBadRequestException("الوصف", 3, false);

        if (role.Permissions.Count <= 0)
            throw new RoleShouldHavePermissionsBadRequestException();

        var anyRoleSameDescription = await repositoryManager.User.FindRoleById(role.Id, role.Description);
        if (anyRoleSameDescription is not null && (id is null || id == Guid.Empty || anyRoleSameDescription.Id != id))
            throw new AlreadyExistBadRequestException("وصف الدور ", role.Description);
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

        // var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
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

    public async Task<Guid> CreateLocation(UserLocationForManipulationDto userLocationForManipulation, Guid userId)
    {
        var userLocationForCreation = mapper.Map<UserLocation>(userLocationForManipulation);
        userLocationForCreation.UserId = userId;
        var id = await repositoryManager.User.CreateLocation(userLocationForCreation);
        return id;
    }

    public async Task<IEnumerable<UserLocationDto>> GetMyLocations(Guid userId)
    {
        var userLocations = await repositoryManager.User.FindLocationsByUserId(userId);
        var userLocationsDto = mapper.Map<IEnumerable<UserLocationDto>>(userLocations);
        return userLocationsDto;
    }

    public async Task UpdateLocation(Guid id, UserLocationForManipulationDto userLocationForManipulation, Guid userId)
    {
        var userLocation = await repositoryManager.User.FindLocationById(id);
        if (userLocation is null)
            throw new EntityNotFoundException("الموقع", "المعرف", id);

        if (userLocation.UserId != userId)
            throw new ForbiddenException("Cannot edit location not related to you");

        var userLocationForUpdate = mapper.Map<UserLocation>(userLocationForManipulation);
        userLocationForUpdate.Id = id;
        await repositoryManager.User.UpdateLocation(userLocationForUpdate);
    }

    public async Task DeleteLocation(Guid id, Guid userId)
    {
        var userLocation = await repositoryManager.User.FindLocationById(id);
        if (userLocation is null)
            throw new EntityNotFoundException("الموقع", "المعرف", id);

        if (userLocation.UserId != userId)
            throw new ForbiddenException("Cannot edit location not related to you");

        await repositoryManager.User.DeleteLocation(id);
    }
}