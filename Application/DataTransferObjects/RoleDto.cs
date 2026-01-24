using Domain.Enums;

namespace Application.DataTransferObjects;

public class RoleDto : DescriptionDto
{
    public List<PermissionDto> Permissions { get; set; } = new();
}