namespace Shared.DataTransferObjects;

public class AuthenticationDto
{
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string? FcmToken { get; set; }
}