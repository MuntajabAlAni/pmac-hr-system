using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(202601310001)]
public class InitialTables_202601310001 : Migration
{
    public override void Up()
    {
        // 1. Roles & Users (Identity)
        Create.Table("Roles")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Description").AsString(50).NotNullable();

        Create.Table("RolePermissions")
            .WithColumn("RoleId").AsGuid().NotNullable().ForeignKey("Roles", "Id")
            .WithColumn("Permission").AsInt32().NotNullable();

        Create.Table("Users")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("FullName").AsString(250).NotNullable()
            .WithColumn("RoleId").AsGuid().NotNullable().ForeignKey("Roles", "Id")
            .WithColumn("PhoneNumber").AsString(15).NotNullable()
            .WithColumn("Specialty").AsString().Nullable()
            .WithColumn("Email").AsString(250).NotNullable()
            .WithColumn("Password").AsString(int.MaxValue).Nullable()
            .WithColumn("AccessToken").AsString(int.MaxValue).Nullable()
            .WithColumn("RefreshToken").AsString().Nullable()
            .WithColumn("RefreshTokenExpiryTime").AsDateTime2().Nullable()
            .WithColumn("FcmToken").AsString().Nullable()
            .WithColumn("AddedByUserId").AsGuid().Nullable()
            .WithColumn("ProviderId").AsString().Nullable()
            .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(0)
            .WithColumn("RecordDate").AsDateTime2().WithDefault(SystemMethods.CurrentDateTime);

        Create.Table("UserAdditionalPermissions")
            .WithColumn("UserId").AsGuid().NotNullable().ForeignKey("Users", "Id")
            .WithColumn("Permission").AsInt32().NotNullable();

        Create.Table("UserLocations")
             .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
             .WithColumn("UserId").AsGuid().NotNullable().ForeignKey("Users", "Id")
             .WithColumn("Title").AsString().Nullable()
             .WithColumn("Description").AsString().Nullable()
             .WithColumn("Longitude").AsString().Nullable()
             .WithColumn("Latitude").AsString().Nullable()
             .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(0)
             .WithColumn("RecordDate").AsDateTime2().WithDefault(SystemMethods.CurrentDateTime);

        Create.Table("Gender")
             .WithColumn("Gender_Id").AsGuid().NotNullable().PrimaryKey()
             .WithColumn("Gender_Name").AsString(50).NotNullable();

        Create.Table("Marital_Status")
             .WithColumn("Marital_Status_Id").AsGuid().NotNullable().PrimaryKey()
             .WithColumn("Marital_Status_Name").AsString(100).NotNullable();

        Create.Table("Grade")
             .WithColumn("Grade_Id").AsGuid().NotNullable().PrimaryKey()
             .WithColumn("Grade_Name").AsString(100).NotNullable();

        Create.Table("Step")
             .WithColumn("Step_Id").AsGuid().NotNullable().PrimaryKey()
             .WithColumn("Step_Name").AsString(100).NotNullable();

        Create.Table("Job_Title")
             .WithColumn("Job_Title_Id").AsGuid().NotNullable().PrimaryKey()
             .WithColumn("Job_Title_Name").AsString(100).NotNullable();

        Create.Table("Position")
             .WithColumn("Position_Id").AsGuid().NotNullable().PrimaryKey()
             .WithColumn("Title").AsString(100).NotNullable();

        Create.Table("Ranks")
             .WithColumn("Rank_Id").AsGuid().NotNullable().PrimaryKey()
             .WithColumn("Rank_Name").AsString(50).NotNullable();

        Create.Table("Vacation_Type")
            .WithColumn("Vacation_Type_Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Vacation_Type_Name").AsString(100).NotNullable();

       Create.Table("Work_Career_Type")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString(100).NotNullable();

        // 3. Organization Structure
        Create.Table("Directorate")
            .WithColumn("Directorate_Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Directorate_Name").AsString(200).NotNullable()
            .WithColumn("Exception").AsInt32().WithDefaultValue(0)
            .WithColumn("hidden").AsInt32().WithDefaultValue(0);

        Create.Table("Department")
            .WithColumn("Deptartment_Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Deptartment_Name").AsString(200).NotNullable()
            .WithColumn("Directorate_Id").AsGuid().NotNullable().ForeignKey("Directorate", "Directorate_Id")
            .WithColumn("Exception").AsInt32().WithDefaultValue(0)
            .WithColumn("hidden").AsInt32().WithDefaultValue(0);

        Create.Table("Section")
            .WithColumn("Section_Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Section_Name").AsString(200).NotNullable()
            .WithColumn("Department_Id").AsGuid().NotNullable().ForeignKey("Department", "Deptartment_Id");

        Create.Table("Administrative_Action_Type")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString(100).NotNullable();

        Create.Table("Official_Document_Type")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString(100).NotNullable();

        // 4. Employee
        Create.Table("Employee")
            .WithColumn("Emp_Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Employee_F_Name").AsString(500).Nullable() // Full Name
            .WithColumn("Employee_First_Name").AsString(100).NotNullable()
            .WithColumn("Employee_Second_Name").AsString(100).Nullable()
            .WithColumn("Employee_Third_Name").AsString(100).Nullable()
            .WithColumn("Employee_Forth_Name").AsString(100).Nullable()
            .WithColumn("Employee_Last_Name").AsString(100).Nullable()
            .WithColumn("Mother_Name").AsString(200).Nullable()
            .WithColumn("Gender_Id").AsGuid().Nullable().ForeignKey("Gender", "Gender_Id")
            .WithColumn("Birth_Date").AsDateTime().Nullable()
            .WithColumn("Phone_No").AsString(50).Nullable()
            .WithColumn("Email").AsString(250).Nullable()
            .WithColumn("Civil_Id_No").AsString(50).Nullable()
            .WithColumn("Nat_Card_No").AsString(50).Nullable()
            .WithColumn("Address").AsString(int.MaxValue).Nullable()
            .WithColumn("Marital_Status").AsGuid().Nullable().ForeignKey("Marital_Status", "Marital_Status_Id")
            .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(0);

        // 5. Career
        Create.Table("Career")
            .WithColumn("Career_Emp_Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Emp_Id").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("Emp_Name").AsString(500).Nullable()
            .WithColumn("Employee_National_Num").AsString(50).Nullable()
            .WithColumn("Directorate_Id").AsGuid().Nullable().ForeignKey("Directorate", "Directorate_Id")
            .WithColumn("Department_Id").AsGuid().Nullable().ForeignKey("Department", "Deptartment_Id")
            .WithColumn("Section_Id").AsGuid().Nullable().ForeignKey("Section", "Section_Id")
            .WithColumn("Job_Title_Id").AsGuid().Nullable().ForeignKey("Job_Title", "Job_Title_Id")
            .WithColumn("Grade").AsGuid().Nullable().ForeignKey("Grade", "Grade_Id")
            .WithColumn("Step").AsGuid().Nullable().ForeignKey("Step", "Step_Id")
            .WithColumn("Position_Id").AsGuid().Nullable().ForeignKey("Position", "Position_Id")
            .WithColumn("Employment_Status").AsString(100).Nullable()
            .WithColumn("Last_Promotion_Date").AsDateTime().Nullable()
            .WithColumn("Last_Raise_Date").AsDateTime().Nullable()
            .WithColumn("Next_Raise_Date").AsDateTime().Nullable()
            .WithColumn("Basic_Salary").AsString(50).Nullable()
            .WithColumn("Work_Career_Type_Id").AsGuid().Nullable().ForeignKey("Work_Career_Type", "Id")
            .WithColumn("Rank_Id").AsGuid().Nullable().ForeignKey("Ranks", "Rank_Id")
            .WithColumn("Initiation_Actual_Date").AsDateTime().Nullable()
            .WithColumn("EntryDate").AsDateTime().WithDefault(SystemMethods.CurrentDateTime);

        // 6. Vacation
        Create.Table("Vacation")
            .WithColumn("Vacation_Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Emp_Id").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("Emp_Name").AsString(500).Nullable()
            .WithColumn("Vacation_Type_Id").AsGuid().NotNullable().ForeignKey("Vacation_Type", "Vacation_Type_Id")
            .WithColumn("Start_Date").AsDateTime().Nullable()
            .WithColumn("End_Date").AsDateTime().Nullable()
            .WithColumn("No_Of_Days").AsInt32().Nullable()
            .WithColumn("No_Of_Months").AsInt32().Nullable()
            .WithColumn("No_Of_Years").AsInt32().Nullable()
            .WithColumn("Order_Issue_No").AsString(50).Nullable()
            .WithColumn("Order_Issue_Date").AsDateTime().Nullable()
            .WithColumn("Vac_Notes").AsString(int.MaxValue).Nullable()
            .WithColumn("UserName").AsString(100).Nullable()
            .WithColumn("EntryDate").AsDateTime().WithDefault(SystemMethods.CurrentDateTime);

    }

    public override void Down()
    {
        // Delete in reverse order of dependencies
        Delete.Table("Vacation");
        Delete.Table("Career");
        Delete.Table("Employee");
        Delete.Table("Section");
        Delete.Table("Department");
        Delete.Table("Directorate");
        Delete.Table("Work_Career_Type");
        Delete.Table("Vacation_Type");
        Delete.Table("Ranks");
        Delete.Table("Step");
        Delete.Table("Grade");
        Delete.Table("Position");
        Delete.Table("Job_Title");
        Delete.Table("Marital_Status");
        Delete.Table("Gender");
        Delete.Table("UserLocations");
        Delete.Table("UserAdditionalPermissions");
        Delete.Table("Users");
        Delete.Table("RolePermissions");
        Delete.Table("Roles");
    }
}
