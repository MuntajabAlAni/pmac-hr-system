using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(202602240001)]
public class AlignConsultantTaskTable_202602240001 : Migration
{
    public override void Up()
    {
        // Aligning Consultant_Task with ConsultantTask model
        Delete.Column("TaskName").FromTable("Consultant_Task");
        Delete.Column("OrderNumber").FromTable("Consultant_Task");
        Delete.Column("OrderDate").FromTable("Consultant_Task");
        Delete.Column("StartDate").FromTable("Consultant_Task");
        Delete.Column("EndDate").FromTable("Consultant_Task");

        Alter.Table("Consultant_Task")
            .AddColumn("Subject").AsString(int.MaxValue).Nullable()
            .AddColumn("TaskDate").AsDateTime().Nullable()
            .AddColumn("WorkNatureId").AsGuid().Nullable()
            .AddColumn("ProcedureDescriptionId").AsGuid().Nullable()
            .AddColumn("ProgressDescription").AsString(int.MaxValue).Nullable()
            .AddColumn("TaskRecommendations").AsString(int.MaxValue).Nullable();

        Delete.Column("Action").FromTable("Log_File");
        Delete.Column("Details").FromTable("Log_File");
        Delete.Column("UserId").FromTable("Log_File");
        Delete.Column("Timestamp").FromTable("Log_File");

        Alter.Table("Log_File")
            .AddColumn("UserName").AsString(500).Nullable()
            .AddColumn("EntryTime").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime)
            .AddColumn("EntryType").AsString(500).Nullable()
            .AddColumn("EntryTable").AsString(500).Nullable()
            .AddColumn("RecordId").AsGuid().NotNullable().WithDefaultValue("00000000-0000-0000-0000-000000000000")
            .AddColumn("NotificationString").AsString(int.MaxValue).Nullable()
            .AddColumn("EmployeeName").AsString(500).Nullable()
            .AddColumn("Link").AsString(int.MaxValue).Nullable()
            .AddColumn("Military").AsInt32().NotNullable().WithDefaultValue(0);
    }

    public override void Down()
    {
        Delete.Column("Subject").FromTable("Consultant_Task");
        Delete.Column("TaskDate").FromTable("Consultant_Task");
        Delete.Column("WorkNatureId").FromTable("Consultant_Task");
        Delete.Column("ProcedureDescriptionId").FromTable("Consultant_Task");
        Delete.Column("ProgressDescription").FromTable("Consultant_Task");
        Delete.Column("TaskRecommendations").FromTable("Consultant_Task");

        Alter.Table("Consultant_Task")
            .AddColumn("TaskName").AsString(500).Nullable()
            .AddColumn("OrderNumber").AsString(100).Nullable()
            .AddColumn("OrderDate").AsDateTime().Nullable()
            .AddColumn("StartDate").AsDateTime().Nullable()
            .AddColumn("EndDate").AsDateTime().Nullable();

        Delete.Column("UserName").FromTable("Log_File");
        Delete.Column("EntryTime").FromTable("Log_File");
        Delete.Column("EntryType").FromTable("Log_File");
        Delete.Column("EntryTable").FromTable("Log_File");
        Delete.Column("RecordId").FromTable("Log_File");
        Delete.Column("NotificationString").FromTable("Log_File");
        Delete.Column("EmployeeName").FromTable("Log_File");
        Delete.Column("Link").FromTable("Log_File");
        Delete.Column("Military").FromTable("Log_File");

        Alter.Table("Log_File")
            .AddColumn("Action").AsString(200).Nullable()
            .AddColumn("Details").AsString(int.MaxValue).Nullable()
            .AddColumn("UserId").AsGuid().Nullable()
            .AddColumn("Timestamp").AsDateTime().WithDefaultValue(SystemMethods.CurrentDateTime);
    }
}
