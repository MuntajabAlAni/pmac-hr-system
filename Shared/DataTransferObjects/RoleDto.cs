using Entities.Enums;

namespace Shared.DataTransferObjects;

public class RoleDto : DescriptionDto
{
    public List<PermissionDto> Permissions { get; set; } = new();
}