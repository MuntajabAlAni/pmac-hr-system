namespace Application.DataTransferObjects;

public class ChangePasswordDto
{
    public string LoggedInUserPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}