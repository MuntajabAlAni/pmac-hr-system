using FluentMigrator;
using Domain.SeededData;

namespace API.Migrations;

[Migration(202506190001)]
public class InitialSeed_202506190001 : Migration
{
    public override void Up()
    {
        Insert.IntoTable("Roles").Row(new
        {
            SeededRoles.Admin.Id,
            SeededRoles.Admin.Description,
        })
        .Row(new
        {
            SeededRoles.RegisteredUser.Id,
            SeededRoles.RegisteredUser.Description,
        });

        foreach (var permission in SeededRoles.Admin.Permissions)
        {
            Insert.IntoTable("RolePermissions").Row(new
            {
                RoleId = SeededRoles.Admin.Id,
                Permission = (int)permission
            });
        }

        foreach (var permission in SeededRoles.RegisteredUser.Permissions)
        {
            Insert.IntoTable("RolePermissions").Row(new
            {
                RoleId = SeededRoles.RegisteredUser.Id,
                Permission = (int)permission
            });
        }

        Insert.IntoTable("Users").Row(new
        {
            SeededUsers.AdminUser.Id,
            SeededUsers.AdminUser.FullName,
            SeededUsers.AdminUser.Specialty,
            SeededUsers.AdminUser.RoleId,
            SeededUsers.AdminUser.PhoneNumber,
            SeededUsers.AdminUser.Email,
            SeededUsers.AdminUser.Password,
            SeededUsers.AdminUser.AddedByUserId
        });
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}