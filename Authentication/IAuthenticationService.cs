using Application.DataTransferObjects;

namespace Authentication;

public interface IAuthenticationService
{
    Task<Guid> Register(UserForRegistrationDto userForRegistration);
    Task<UserDetailsWithTokensDto> Authenticate(AuthenticationDto authenticationDto, bool checkIfCanLoginToPortal);
    Task<UserDetailsWithTokensDto> Refresh(TokensDto tokensDto);
    Task SetPassword(Guid id, string newPassword);
    Task ForgotPassword(ForgotPasswordDto forgotPasswordDto);
}
