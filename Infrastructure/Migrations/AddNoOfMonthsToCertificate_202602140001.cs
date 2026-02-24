using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(202602140001)]
public class AddNoOfMonthsToCertificate_202602140001 : Migration
{
    public override void Up()
    {
        Alter.Table("Certificate")
            .AddColumn("NoOfMonths").AsInt32().WithDefaultValue(0);
    }

    public override void Down()
    {
        Delete.Column("NoOfMonths").FromTable("Certificate");
    }
}
