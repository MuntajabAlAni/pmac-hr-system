using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator;

namespace PmacHrSystem.Migrations;

[Migration(202510300001)]
public class AddLocationsTable_202510300001 : Migration
{
    public override void Down()
    {
        Delete.Table("UserLocations");
    }

    public override void Up()
    {
        Create.Table("UserLocations")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey().WithDefault(SystemMethods.NewSequentialId)
            .WithColumn("UserId").AsGuid().NotNullable()
            .ForeignKey("Users", "Id")
            .OnDelete(System.Data.Rule.None)
            .WithColumn("Title").AsString().NotNullable()
            .WithColumn("Description").AsString().NotNullable()
            .WithColumn("Longitude").AsDecimal().NotNullable()
            .WithColumn("Latitude").AsDecimal().NotNullable()
            .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("RecordDate").AsDateTime2().WithDefault(SystemMethods.CurrentDateTime);
    }
}
