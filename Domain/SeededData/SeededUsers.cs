using Domain.Models;

namespace Domain.SeededData;

public static class SeededUsers
{
    public static readonly User AdminUser = new()
    {
        Id = Guid.Parse("a2f3b4c5-d6e7-d23a-8f9a-0b1c2d3e4f5a"),
        FullName = "مدير",
        Specialty = "مبرمج",
        RoleId = SeededRoles.Admin.Id,
        PhoneNumber = "07733810890",
        Email = "muntajabalani98@gmail.com",
        Password = "AFexjMBjLOBJiYMKGaVQToORAenL7bym078kh4KP2kWtjeDA5XGcow/Xm+ZFxoRlKA==",
        AddedByUserId = Guid.Parse("a2f3b4c5-d6e7-d23a-8f9a-0b1c2d3e4f5a")
    };
}