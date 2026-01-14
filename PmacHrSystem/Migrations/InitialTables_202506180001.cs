using FluentMigrator;

namespace PmacHrSystem.Migrations;

[Migration(202506180001)]
public class InitialTables_202506180001 : Migration
{
    public override void Up()
    {
        Create.Table("Roles")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey().WithDefault(SystemMethods.NewSequentialId)
            .WithColumn("Description").AsString(50).NotNullable();

        Create.Table("RolePermissions")
            .WithColumn("RoleId").AsGuid().NotNullable()
            .ForeignKey("Roles", "Id")
            .OnDelete(System.Data.Rule.None)
            .WithColumn("Permission").AsInt32().NotNullable();

        Create.Table("Users")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey().WithDefault(SystemMethods.NewSequentialId)
            .WithColumn("FullName").AsString(250).NotNullable()
            .WithColumn("Specialty").AsString().Nullable()
            .WithColumn("RoleId").AsGuid().NotNullable()
            .ForeignKey("Roles", "Id")
            .OnDelete(System.Data.Rule.None)
            .WithColumn("PhoneNumber").AsString(15).NotNullable()
            .WithColumn("Email").AsString(250).NotNullable()
            .WithColumn("Password").AsString(int.MaxValue).Nullable()
            .WithColumn("AccessToken").AsString(int.MaxValue).Nullable()
            .WithColumn("RefreshToken").AsString().Nullable()
            .WithColumn("RefreshTokenExpiryTime").AsDateTime2().Nullable()
            .WithColumn("FcmToken").AsString().Nullable()
            .WithColumn("AddedByUserId").AsGuid().Nullable()
            .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(0)
            .WithColumn("RecordDate").AsDateTime2().WithDefault(SystemMethods.CurrentDateTime);

        Create.Table("UserAdditionalPermissions")
            .WithColumn("UserId").AsGuid().NotNullable()
            .ForeignKey("Users", "Id")
            .OnDelete(System.Data.Rule.None)
            .WithColumn("Permission").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("UserAdditionalPermissions");
        Delete.Table("Users");
        Delete.Table("RolePermissions");
        Delete.Table("Roles");
    }
}