namespace Application.DataTransferObjects;

public class UserForAdminManipulationDto : UserForManipulationDto
{
    public Guid RoleId { get; set; }
    public Guid ProviderId { get; set; }
    public List<int> Permissions { get; set; } = new();
    public string Password { get; set; } = null!;
}