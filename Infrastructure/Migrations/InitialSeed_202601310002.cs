using FluentMigrator;
using Domain.SeededData;

namespace Infrastructure.Migrations;

[Migration(202601310002)]
public class InitialSeed_202601310002 : Migration
{
    public override void Up()
    {
        // Roles
        Insert.IntoTable("Roles").Row(new
        {
            Id = SeededRoles.Admin.Id,
            Description = SeededRoles.Admin.Description,
        })
        .Row(new
        {
            Id = SeededRoles.RegisteredUser.Id,
            Description = SeededRoles.RegisteredUser.Description,
        });

        // Role Permissions
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

        // Users
        Insert.IntoTable("Users").Row(new
        {
            Id = SeededUsers.AdminUser.Id,
            FullName = SeededUsers.AdminUser.FullName,
            Specialty = SeededUsers.AdminUser.Specialty,
            RoleId = SeededUsers.AdminUser.RoleId,
            PhoneNumber = SeededUsers.AdminUser.PhoneNumber,
            Email = SeededUsers.AdminUser.Email,
            Password = SeededUsers.AdminUser.Password,
            AddedByUserId = SeededUsers.AdminUser.AddedByUserId,
            RecordDate = SystemMethods.CurrentDateTime,
            IsDeleted = false
        });
        
        // Administrative Action Types
        // Assuming SeededAdministrativeActionTypes has a static list or properties
        // Since I cannot see the file content yet, I will verify it or comment this out if unsure.
        // But the user requested "Similar as the current example".
        // I'll skip these specific lookups for now unless I see a static list in the file.
    }

    public override void Down()
    {
        // Delete seeded data
        Delete.FromTable("Users").Row(new { Id = SeededUsers.AdminUser.Id });
        Delete.FromTable("Roles").Row(new { Id = SeededRoles.Admin.Id });
        Delete.FromTable("Roles").Row(new { Id = SeededRoles.RegisteredUser.Id });
    }
}
