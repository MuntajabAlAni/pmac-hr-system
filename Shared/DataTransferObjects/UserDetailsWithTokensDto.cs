namespace Shared.DataTransferObjects;

public class UserDetailsWithTokensDto : UserDetailsDto
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}