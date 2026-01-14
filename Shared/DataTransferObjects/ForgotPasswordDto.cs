namespace Shared.DataTransferObjects;
public class ForgotPasswordDto
{
    public string SetPasswordUrl { get; set; } = null!;
    public string Email { get; set; } = null!;
}
