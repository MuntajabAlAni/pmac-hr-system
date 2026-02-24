using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(202602060001)]
public class SchemaCompletion_202602060001 : Migration
{
    public override void Up()
    {
        // 1. Missing Lookup Tables


        if (!Schema.Table("Comming_From").Exists())
        {
            Create.Table("Comming_From")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(200).NotNullable();
        }

        if (!Schema.Table("Finger_Print_Exception_Type").Exists())
        {
            Create.Table("Finger_Print_Exception_Type")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(200).NotNullable();
        }

        if (!Schema.Table("Service_Continuation").Exists())
        {
            Create.Table("Service_Continuation")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(200).NotNullable();
        }

        if (!Schema.Table("Service_Type").Exists())
        {
            Create.Table("Service_Type")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(200).NotNullable();
        }

        if (!Schema.Table("Raise_Type").Exists())
        {
            Create.Table("Raise_Type")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(100).NotNullable();
        }

        if (!Schema.Table("Certificate_Publisher").Exists())
        {
            Create.Table("Certificate_Publisher")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(200).NotNullable();
        }

        if (!Schema.Table("Certificate").Exists())
        {
            Create.Table("Certificate")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(200).NotNullable();
        }

        if (!Schema.Table("University").Exists())
        {
            Create.Table("University")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(200).NotNullable();
        }

        if (!Schema.Table("Task_Status").Exists())
        {
            Create.Table("Task_Status")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(100).NotNullable();
        }

        // 2. Update existing tables with missing columns
        // Employee
        Alter.Table("Employee")
            .AddColumn("Store_Emp_Id").AsGuid().Nullable()
            .AddColumn("Blood_Group").AsString(10).Nullable()
            .AddColumn("Nationality").AsString(100).Nullable()
            .AddColumn("Religion").AsString(100).Nullable()
            .AddColumn("Place_Of_Birth").AsString(200).Nullable()
            .AddColumn("Number_Of_Children").AsString(50).Nullable()
            .AddColumn("Spouse_Name").AsString(200).Nullable()
            .AddColumn("Spouse_Job").AsString(200).Nullable()
            .AddColumn("Record_Number").AsString(50).Nullable()
            .AddColumn("Page_Number").AsString(50).Nullable()
            .AddColumn("Publisher").AsString(200).Nullable()
            .AddColumn("Date_Of_Issuance").AsDateTime().Nullable()
            .AddColumn("National_Card_Issuance_Date").AsDateTime().Nullable()
            .AddColumn("Certificate_Number").AsString(100).Nullable()
            .AddColumn("Pocket_Number").AsString(100).Nullable()
            .AddColumn("Certificate_Publisher").AsString(200).Nullable()
            .AddColumn("Certificate_Issuance_Date").AsDateTime().Nullable()
            .AddColumn("Information_Office_Name").AsString(200).Nullable()
            .AddColumn("Housing_Card_Number").AsString(100).Nullable()
            .AddColumn("Housing_Card_Issuance_Date").AsDateTime().Nullable()
            .AddColumn("Supplying_Card_Number").AsString(100).Nullable()
            .AddColumn("Supply_Center_Name").AsString(200).Nullable()
            .AddColumn("Supply_Center_Number").AsString(100).Nullable()
            .AddColumn("Supply_Notes").AsString(int.MaxValue).Nullable()
            .AddColumn("File_Path").AsString(int.MaxValue).Nullable()
            .AddColumn("Profile_Picture").AsString(int.MaxValue).Nullable()
            .AddColumn("IsSelected").AsBoolean().WithDefaultValue(0)
            .AddColumn("IsSelected_Thanks").AsBoolean().WithDefaultValue(0)
            .AddColumn("IsSelected_Letters").AsBoolean().WithDefaultValue(0)
            .AddColumn("Military").AsInt32().WithDefaultValue(0);

        // Career
        Alter.Table("Career")
            .AddColumn("Continuation_Id").AsGuid().Nullable().ForeignKey("Service_Continuation", "Id")
            .AddColumn("Education").AsString(200).Nullable()
            .AddColumn("Dead_Line_Date").AsDateTime().Nullable()
            .AddColumn("No_Deserver_Months").AsInt32().WithDefaultValue(0)
            .AddColumn("No_Deserved_Thanks").AsInt32().WithDefaultValue(0)
            .AddColumn("Consultant_Agency").AsString(200).Nullable()
            .AddColumn("Work_Type").AsString(int.MaxValue).Nullable()
            .AddColumn("Career_Notes").AsString(int.MaxValue).Nullable()
            .AddColumn("Service_Summary_Notes").AsString(int.MaxValue).Nullable()
            .AddColumn("Assign_Book_Number").AsString(100).Nullable()
            .AddColumn("Assign_Book_Date").AsDateTime().Nullable()
            .AddColumn("Initiation_Book_Number").AsString(100).Nullable()
            .AddColumn("Initiation_Book_Date").AsDateTime().Nullable()
            .AddColumn("Initiation_At_Office_Book_Number").AsString(100).Nullable()
            .AddColumn("Initiation_At_Office_Book_Date").AsDateTime().Nullable()
            .AddColumn("Additional_Service").AsString(100).Nullable()
            .AddColumn("Martyre_Related").AsString(100).Nullable()
            .AddColumn("Political_Prisoner").AsString(100).Nullable()
            .AddColumn("Political_Isolation").AsString(100).Nullable()
            .AddColumn("End_Of_Service_Date").AsDateTime().Nullable()
            .AddColumn("Has_Left_Earlier").AsString(100).Nullable()
            .AddColumn("Transferred").AsString(100).Nullable()
            .AddColumn("Deletion_Book_Number").AsString(100).Nullable()
            .AddColumn("Update_Book_Number").AsString(100).Nullable()
            .AddColumn("Previous_Directorate").AsString(200).Nullable()
            .AddColumn("Normal_Vacation_Credit").AsString(100).Nullable()
            .AddColumn("Illness_Vacation_Credit").AsString(100).Nullable()
            .AddColumn("Ordinary_Final_Total").AsString(100).WithDefaultValue("0")
            .AddColumn("Illness_Final_Total").AsString(100).WithDefaultValue("0")
            .AddColumn("No_Sal_Vac").AsString(100).WithDefaultValue("0")
            .AddColumn("Other_Vacs").AsString(100).WithDefaultValue("0")
            .AddColumn("Illness_Vacs_Consumed").AsString(100).WithDefaultValue("0")
            .AddColumn("Ordinary_Vacs_Consumed").AsString(100).WithDefaultValue("0")
            .AddColumn("Data_Validated").AsString(100).Nullable()
            .AddColumn("Certificate_Publisher_Id").AsGuid().Nullable().ForeignKey("Certificate_Publisher", "Id")
            .AddColumn("Major").AsString(200).Nullable()
            .AddColumn("Year_Of_Graduate").AsString(50).Nullable()
            .AddColumn("Approve_Certificate_Number").AsString(100).Nullable()
            .AddColumn("Approve_Certificate_Date").AsDateTime().Nullable()
            .AddColumn("File_Path").AsString(int.MaxValue).Nullable()
            .AddColumn("Years").AsInt32().WithDefaultValue(0)
            .AddColumn("Months").AsInt32().WithDefaultValue(0)
            .AddColumn("Days").AsInt32().WithDefaultValue(0)
            .AddColumn("Next_Raise_Promotion").AsString(100).Nullable()
            .AddColumn("Side_Id").AsGuid().Nullable().ForeignKey("Comming_From", "Id")
            .AddColumn("Has_Fingerprint").AsInt32().WithDefaultValue(0)
            .AddColumn("Fingerprint_Date").AsDateTime().Nullable()
            .AddColumn("Ministry_Finance_Approval").AsString(100).Nullable()
            .AddColumn("Approval_Type").AsString(100).Nullable()
            .AddColumn("Exception_Type_Id").AsGuid().Nullable().ForeignKey("Finger_Print_Exception_Type", "Id");

        // Vacation
        Alter.Table("Vacation")
            .AddColumn("No_Of_Days2").AsInt32().WithDefaultValue(0)
            .AddColumn("No_Of_Months2").AsInt32().WithDefaultValue(0)
            .AddColumn("No_Of_Years2").AsInt32().WithDefaultValue(0)
            .AddColumn("Vacation_Direct_Order_Number").AsString(100).Nullable()
            .AddColumn("Book_Number").AsString(100).Nullable()
            .AddColumn("Proceeding_Book_Number").AsString(100).Nullable()
            .AddColumn("Proceeding_Book_Date").AsDateTime().Nullable()
            .AddColumn("Running").AsInt32().WithDefaultValue(1)
            .AddColumn("File_Path").AsString(int.MaxValue).Nullable();

        // 3. New Transaction Tables
        Create.Table("Administrative_Action")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("ActionTypeId").AsGuid().NotNullable().ForeignKey("Administrative_Action_Type", "Id")
            .WithColumn("IssueNumber").AsString(100).Nullable()
            .WithColumn("IssueDate").AsDateTime().Nullable()
            .WithColumn("Issuer").AsString(200).Nullable()
            .WithColumn("Reason").AsString(int.MaxValue).Nullable()
            .WithColumn("Notes").AsString(int.MaxValue).Nullable()
            .WithColumn("OldOrderNumber").AsString(100).Nullable()
            .WithColumn("OldOrderDate").AsDateTime().Nullable()
            .WithColumn("FilePath").AsString(int.MaxValue).Nullable();

        Create.Table("Official_Document")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("DocumentTypeId").AsGuid().NotNullable().ForeignKey("Official_Document_Type", "Id")
            .WithColumn("IssueNumber").AsString(100).Nullable()
            .WithColumn("IssueDate").AsDateTime().Nullable()
            .WithColumn("DestinationOrSubject").AsString(500).Nullable()
            .WithColumn("Subject").AsString(500).Nullable()
            .WithColumn("EffectiveDate").AsDateTime().Nullable()
            .WithColumn("Notes").AsString(int.MaxValue).Nullable()
            .WithColumn("FilePath").AsString(int.MaxValue).Nullable();

        Create.Table("Added_Service")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("EmployeeName").AsString(500).Nullable()
            .WithColumn("OrderNumber").AsString(100).Nullable()
            .WithColumn("BookNumber").AsString(100).Nullable()
            .WithColumn("OrderDate").AsDateTime().Nullable()
            .WithColumn("OrderTypeId").AsGuid().Nullable()
            .WithColumn("FromDate").AsDateTime().Nullable()
            .WithColumn("ToDate").AsDateTime().Nullable()
            .WithColumn("TotalDays").AsFloat().Nullable()
            .WithColumn("Years").AsInt32().Nullable()
            .WithColumn("Months").AsInt32().Nullable()
            .WithColumn("Days").AsInt32().Nullable()
            .WithColumn("AddedType").AsString(100).Nullable()
            .WithColumn("Notes").AsString(int.MaxValue).Nullable()
            .WithColumn("IsRunning").AsBoolean().WithDefaultValue(1)
            .WithColumn("FilePath").AsString(int.MaxValue).Nullable()
            .WithColumn("ServiceTypeId").AsGuid().Nullable().ForeignKey("Service_Type", "Id");

        Create.Table("Committee")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("EmployeeName").AsString(500).Nullable()
            .WithColumn("CommitteeType").AsString(200).Nullable()
            .WithColumn("CommitteeOrderNumber").AsString(100).Nullable()
            .WithColumn("OrderDate").AsDateTime().Nullable()
            .WithColumn("CommitteeDurationType").AsString(100).Nullable()
            .WithColumn("NumberOfDays").AsString(50).Nullable()
            .WithColumn("CommitteeNotes").AsString(int.MaxValue).Nullable()
            .WithColumn("FilePath").AsString(int.MaxValue).Nullable();

        Create.Table("Deligation")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("EmployeeName").AsString(500).Nullable()
            .WithColumn("Destination").AsString(200).Nullable()
            .WithColumn("Sponsor").AsString(200).Nullable()
            .WithColumn("Subject").AsString(500).Nullable()
            .WithColumn("Title").AsString(200).Nullable()
            .WithColumn("Evaluator").AsString(200).Nullable()
            .WithColumn("ActualDays").AsString(50).Nullable()
            .WithColumn("TravelDays").AsString(50).Nullable()
            .WithColumn("TravelDate").AsDateTime().Nullable()
            .WithColumn("OrderNumber").AsString(100).Nullable()
            .WithColumn("OrderDate").AsDateTime().Nullable()
            .WithColumn("InitiationDate").AsDateTime().Nullable()
            .WithColumn("Notes").AsString(int.MaxValue).Nullable()
            .WithColumn("FilePath").AsString(int.MaxValue).Nullable();

        Create.Table("Education_Certificate")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("EmployeeName").AsString(500).Nullable()
            .WithColumn("CertificateId").AsGuid().NotNullable().ForeignKey("Certificate", "Id")
            .WithColumn("NumberOfMonths").AsInt32().WithDefaultValue(0)
            .WithColumn("InstituteName").AsString(200).Nullable()
            .WithColumn("CollegeName").AsString(200).Nullable()
            .WithColumn("DepartmentName").AsString(200).Nullable()
            .WithColumn("Major").AsString(200).Nullable()
            .WithColumn("CertificateNumber").AsString(100).Nullable()
            .WithColumn("OrderDate").AsDateTime().Nullable()
            .WithColumn("YearOfGraduate").AsString(50).Nullable()
            .WithColumn("ApproveCertificateNumber").AsString(100).Nullable()
            .WithColumn("ApproveCertificateDate").AsDateTime().Nullable()
            .WithColumn("CountryOfGraduate").AsString(100).Nullable()
            .WithColumn("Sequence").AsString(50).Nullable()
            .WithColumn("Average").AsString(50).Nullable()
            .WithColumn("AffectRaise").AsString(50).Nullable()
            .WithColumn("ConsiderationDate").AsDateTime().Nullable()
            .WithColumn("EducationNotes").AsString(int.MaxValue).Nullable()
            .WithColumn("Running").AsInt32().WithDefaultValue(1)
            .WithColumn("FilePath").AsString(int.MaxValue).Nullable();

        Create.Table("Basic_Salary")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Salary").AsString(50).NotNullable();

        Create.Table("Consultant_Task")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("EmployeeName").AsString(500).Nullable()
            .WithColumn("TaskName").AsString(500).Nullable()
            .WithColumn("TaskDescriptionId").AsGuid().Nullable()
            .WithColumn("TaskStatusId").AsGuid().Nullable().ForeignKey("Task_Status", "Id")
            .WithColumn("OrderNumber").AsString(100).Nullable()
            .WithColumn("OrderDate").AsDateTime().Nullable()
            .WithColumn("StartDate").AsDateTime().Nullable()
            .WithColumn("EndDate").AsDateTime().Nullable()
            .WithColumn("TaskNotes").AsString(int.MaxValue).Nullable()
            .WithColumn("FilePath").AsString(int.MaxValue).Nullable();

        Create.Table("Training_Course")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("EmployeeName").AsString(500).Nullable()
            .WithColumn("OrderNumber").AsString(100).Nullable()
            .WithColumn("OrderDate").AsDateTime().Nullable()
            .WithColumn("CourseName").AsString(500).Nullable()
            .WithColumn("Sponsor").AsString(200).Nullable()
            .WithColumn("CourseEvaluator").AsString(200).Nullable()
            .WithColumn("NumberOfDays").AsString(50).Nullable()
            .WithColumn("StartDate").AsDateTime().Nullable()
            .WithColumn("EndDate").AsDateTime().Nullable()
            .WithColumn("DetachmentDate").AsDateTime().Nullable()
            .WithColumn("InitiationDate").AsDateTime().Nullable()
            .WithColumn("Evaluation").AsString(200).Nullable()
            .WithColumn("CourseNotes").AsString(int.MaxValue).Nullable()
            .WithColumn("FilePath").AsString(int.MaxValue).Nullable();

        Create.Table("Raise")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("RaiseTypeId").AsGuid().NotNullable().ForeignKey("Raise_Type", "Id")
            .WithColumn("OrderNumber").AsString(100).Nullable()
            .WithColumn("OrderDate").AsDateTime().Nullable()
            .WithColumn("EffectiveDate").AsDateTime().Nullable()
            .WithColumn("OldSalary").AsString(50).Nullable()
            .WithColumn("NewSalary").AsString(50).Nullable()
            .WithColumn("OldGradeId").AsGuid().Nullable().ForeignKey("Grade", "Grade_Id")
            .WithColumn("NewGradeId").AsGuid().Nullable().ForeignKey("Grade", "Grade_Id")
            .WithColumn("OldStepId").AsGuid().Nullable().ForeignKey("Step", "Step_Id")
            .WithColumn("NewStepId").AsGuid().Nullable().ForeignKey("Step", "Step_Id")
            .WithColumn("Notes").AsString(int.MaxValue).Nullable();

        Create.Table("Store_Employee")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("RecordDate").AsDateTime().NotNullable();

        Create.Table("Vacation_Total")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("OrdinaryTotal").AsInt32().WithDefaultValue(0)
            .WithColumn("IllnessTotal").AsInt32().WithDefaultValue(0)
            .WithColumn("Year").AsInt32().NotNullable();

        Create.Table("Reward")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("RewardName").AsString(500).Nullable()
            .WithColumn("OrderNumber").AsString(100).Nullable()
            .WithColumn("OrderDate").AsDateTime().Nullable()
            .WithColumn("RewardDate").AsDateTime().Nullable()
            .WithColumn("Notes").AsString(int.MaxValue).Nullable();

        Create.Table("Personal_Card")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("EmployeeId").AsGuid().NotNullable().ForeignKey("Employee", "Emp_Id")
            .WithColumn("CardNumber").AsString(100).Nullable()
            .WithColumn("IssuanceDate").AsDateTime().Nullable()
            .WithColumn("ExpiryDate").AsDateTime().Nullable()
            .WithColumn("FilePath").AsString(int.MaxValue).Nullable();

        Create.Table("Log_File")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Action").AsString(200).Nullable()
            .WithColumn("Details").AsString(int.MaxValue).Nullable()
            .WithColumn("UserId").AsGuid().Nullable()
            .WithColumn("Timestamp").AsDateTime().WithDefault(SystemMethods.CurrentDateTime);
    }

    public override void Down()
    {
        // Drop new tables
        Delete.Table("Log_File");
        Delete.Table("Personal_Card");
        Delete.Table("Reward");
        Delete.Table("Vacation_Total");
        Delete.Table("Store_Employee");
        Delete.Table("Raise");
        Delete.Table("Training_Course");
        Delete.Table("Consultant_Task");
        Delete.Table("Basic_Salary");
        Delete.Table("Education_Certificate");
        Delete.Table("Deligation");
        Delete.Table("Committee");
        Delete.Table("Added_Service");
        Delete.Table("Official_Document");
        Delete.Table("Administrative_Action");
        
        // Drop new lookup tables
        Delete.Table("Task_Status");
        Delete.Table("University");
        Delete.Table("Certificate");
        Delete.Table("Certificate_Publisher");
        Delete.Table("Raise_Type");
        Delete.Table("Service_Type");
        Delete.Table("Service_Continuation");
        Delete.Table("Finger_Print_Exception_Type");
        Delete.Table("Comming_From");
    }
}
