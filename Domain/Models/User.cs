using Domain.Attributes;
using Domain.Enums;

namespace Domain.Models;

public class User
{
    [IgnoreChange] public Guid Id { get; set; }
    [DisplayName("Full Name")] public string FullName { get; set; } = null!;
    [DisplayName("Specialty")] public string? Specialty { get; set; }
    [IgnoreChange] public Guid RoleId { get; set; }
    [DisplayName("Role")] public Role Role { get; set; } = null!;
    [DisplayName("Phone Number")] public string PhoneNumber { get; set; } = null!;
    [DisplayName("Email")] public string Email { get; set; } = null!;

    [IgnoreChange] public string? Password { get; set; }
    [IgnoreChange] public string? AccessToken { get; set; }
    [IgnoreChange] public string? RefreshToken { get; set; }
    [IgnoreChange] public DateTime? RefreshTokenExpiryTime { get; set; }
    [IgnoreChange] public string? FcmToken { get; set; }
    [IgnoreChange] public Guid? AddedByUserId { get; set; }
    [IgnoreChange] public string? AddedByUsername { get; set; }
    [IgnoreChange] public bool IsDeleted { get; set; }
    [IgnoreChange] public DateTime RecordDate { get; set; }
    [IgnoreChange] public List<Permission> AdditionalPermissions { get; set; } = new();
}