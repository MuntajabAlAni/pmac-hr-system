using Entities.Attributes;
using Entities.Enums;

namespace Entities.Models;

public class Role
{
    [IgnoreChange] public Guid Id { get; set; }
    [DisplayName("وصف الدور")] public string Description { get; set; } = null!;
    [DisplayName("الصلاحيات")] public List<Permission> Permissions { get; set; } = new();
}