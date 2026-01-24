using Domain.Enums;
using Domain.Models;

namespace Domain.SeededData;

public static class SeededRoles
{
    public static readonly Role RegisteredUser = new()
    {
        Id = Guid.Parse("b1f8c0d2-3e4f-4a5b-8c6d-7e8f9a0b1c2d"),
        Description = "Employee",
        Permissions =
        [
            Permission.ViewUser,
            Permission.EditUser
        ]
    };

    public static readonly Role Admin = new()
    {
        Id = Guid.Parse("c1d2e3f4-5a6b-7c8d-9e0f-1a2b3c4d5e6f"),
        Description = "Admin",
        Permissions =
        [
            Permission.SuperAdmin
        ]
    };
}