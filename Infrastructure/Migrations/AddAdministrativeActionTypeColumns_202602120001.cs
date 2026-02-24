using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(202602120001)]
public class AddAdministrativeActionTypeColumns_202602120001 : Migration
{
    public override void Up()
    {
        Alter.Table("Administrative_Action_Type")
            .AddColumn("ImpactInDays").AsInt32().WithDefaultValue(0)
            .AddColumn("IsPenalty").AsBoolean().WithDefaultValue(0)
            .AddColumn("RaiseAffected").AsBoolean().WithDefaultValue(0);
    }

    public override void Down()
    {
        Delete.Column("RaiseAffected").FromTable("Administrative_Action_Type");
        Delete.Column("IsPenalty").FromTable("Administrative_Action_Type");
        Delete.Column("ImpactInDays").FromTable("Administrative_Action_Type");
    }
}
