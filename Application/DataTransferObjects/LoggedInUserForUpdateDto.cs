namespace Application.DataTransferObjects;

public class LoggedInUserForUpdateDto
{
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Specialty { get; set; }
    public string Email { get; set; } = null!;
}