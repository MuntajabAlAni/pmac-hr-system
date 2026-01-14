using Entities.Enums;

namespace Shared.DataTransferObjects;

public class UserDetailsDto : UserDto
{
    public Guid AddedByUserId { get; set; }
    public string AddedByUsername { get; set; } = null!;
    public List<PermissionDto> AdditionalPermissions { get; set; } = new();
}