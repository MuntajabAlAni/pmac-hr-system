namespace Shared.DataTransferObjects;

public class UserDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Specialty { get; set; }
    public Guid RoleId { get; set; }
    public RoleDto Role { get; set; } = null!;
    public DateTime RecordDate { get; set; }
}