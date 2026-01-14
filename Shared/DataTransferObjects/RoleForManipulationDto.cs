namespace Shared.DataTransferObjects;

public class RoleForManipulationDto
{
    public string Description { get; set; } = null!;
    public List<int> Permissions { get; set; } = [];
}