namespace Infrastructure.Queries;

public class CareerQueries
{
    // Fetch all careers with related entity names
    public const string FindAllQuery = """
        SELECT 
            c.Career_Emp_Id AS Id,
            c.Emp_Id AS EmployeeId,
            e.Employee_First_Name + ' ' + ISNULL(e.Employee_Second_Name, '') + ' ' + ISNULL(e.Employee_Third_Name, '') + ' ' + ISNULL(e.Employee_Forth_Name, '') AS EmployeeName,
            c.Employee_National_Num AS EmployeeNationalNumber,
            c.Directorate_Id AS DirectorateId,
            d.Directorate_Name AS DirectorateName,
            c.Department_Id AS DepartmentId,
            dept.Deptartment_Name AS DepartmentName,
            c.Section_Id AS SectionId,
            s.Section_Name AS SectionName,
            c.Job_Title_Id AS JobTitleId,
            j.Job_Title_Name AS JobTitleName,
            c.Position_Id AS PositionId,
            p.Title AS PositionName,
            c.Rank_Id AS RankId,
            r.Rank_Name AS RankName,
            c.Grade AS GradeId,
            g.Grade_Name AS GradeName,
            c.Step AS StepId,
            st.Step_Name AS StepName,
            c.ContinuationId,
            sc.Name AS ContinuationName,
            c.Work_Career_Type_Id AS WorkCareerTypeId,
            w.Name AS WorkCareerTypeName,
            c.SideId,
            cf.Name AS CommingFromName,
            c.ExceptionTypeId,
            f.Name AS ExceptionTypeName,
            c.Employment_Status AS EmploymentStatus,
            c.Last_Promotion_Date AS LastPromotionDate,
            c.Last_Raise_Date AS LastRaiseDate,
            c.Next_Raise_Date AS NextRaiseDate,
            c.Basic_Salary AS BasicSalary,
            c.Start_Date AS StartDate,
            c.End_Date AS EndDate,
            c.Is_Current AS IsCurrent
        FROM Career c
        LEFT JOIN Employee e ON c.Emp_Id = e.Emp_Id
        LEFT JOIN Directorate d ON c.Directorate_Id = d.Directorate_Id
        LEFT JOIN Department dept ON c.Department_Id = dept.Deptartment_Id
        LEFT JOIN Section s ON c.Section_Id = s.Section_Id
        LEFT JOIN Job_Title j ON c.Job_Title_Id = j.Job_Title_Id
        LEFT JOIN Position p ON c.Position_Id = p.Position_Id
        LEFT JOIN Ranks r ON c.Rank_Id = r.Rank_Id
        LEFT JOIN Grade g ON c.Grade = g.Grade_Id
        LEFT JOIN Step st ON c.Step = st.Step_Id
        LEFT JOIN ServiceContinuation sc ON c.ContinuationId = sc.Id
        LEFT JOIN Work_Career_Type w ON c.Work_Career_Type_Id = w.Id
        LEFT JOIN CommingFrom cf ON c.SideId = cf.Id
        LEFT JOIN FingerPrintExceptionType f ON c.ExceptionTypeId = f.Id
        ORDER BY e.Employee_First_Name
        """;

    public const string FindByIdQuery = """
        SELECT 
            c.Career_Emp_Id AS Id,
            c.Emp_Id AS EmployeeId,
            c.Employee_National_Num AS EmployeeNationalNumber,
            c.Directorate_Id AS DirectorateId,
            c.Department_Id AS DepartmentId,
            c.Section_Id AS SectionId,
            c.Job_Title_Id AS JobTitleId,
            c.Position_Id AS PositionId,
            c.Rank_Id AS RankId,
            c.Grade AS GradeId,
            c.Step AS StepId,
            c.ContinuationId,
            c.Work_Career_Type_Id AS WorkCareerTypeId,
            c.SideId,
            c.ExceptionTypeId,
            c.Employment_Status AS EmploymentStatus,
            c.Last_Promotion_Date AS LastPromotionDate,
            c.Last_Raise_Date AS LastRaiseDate,
            c.Next_Raise_Date AS NextRaiseDate,
            c.Basic_Salary AS BasicSalary,
            c.Start_Date AS StartDate,
            c.End_Date AS EndDate,
            c.Is_Current AS IsCurrent,
            c.Education,
            c.CareerNotes,
            c.ServiceSummaryNotes,
            c.AssignBookNumber,
            c.AssignBookDate,
            c.InitiationBookNumber,
            c.InitiationBookDate,
            c.InitiationActualDate,
            c.InitiationAtOfficeBookNumber,
            c.InitiationAtOfficeBookDate,
            c.AdditionalService,
            c.MartyreRelated,
            c.PoliticalPrisoner,
            c.PoliticalIsolation,
            c.EndOfServiceDate,
            c.HasLeftEarlier,
            c.Transferred,
            c.DeletionBookNumber,
            c.UpdateBookNumber,
            c.PreviousDirectorate,
            c.NormalVacationCredit,
            c.IllnessVacationCredit,
            c.HasFingerprint,
            c.FingerprintDate,
            c.MinistryFinanceApproval,
            c.ApprovalType
        FROM Career c
        WHERE c.Career_Emp_Id = @Id
        """;
        
    public const string FindByEmployeeIdQuery = """
        SELECT * FROM Career WHERE Emp_Id = @EmployeeId
        """;

    public const string InsertQuery = """
        INSERT INTO Career (
            Career_Emp_Id, Emp_Id, Employee_National_Num, Directorate_Id, Department_Id, Section_Id, 
            Job_Title_Id, Position_Id, Rank_Id, Grade, Step, ContinuationId, Work_Career_Type_Id, 
            SideId, ExceptionTypeId, Employment_Status, Last_Promotion_Date, Last_Raise_Date, Next_Raise_Date, 
            Basic_Salary, Education, CareerNotes, ServiceSummaryNotes, AssignBookNumber, AssignBookDate,
            InitiationBookNumber, InitiationBookDate, InitiationActualDate, InitiationAtOfficeBookNumber, 
            InitiationAtOfficeBookDate, AdditionalService, MartyreRelated, PoliticalPrisoner, PoliticalIsolation, 
            EndOfServiceDate, HasLeftEarlier, Transferred, DeletionBookNumber, UpdateBookNumber, PreviousDirectorate, 
            NormalVacationCredit, IllnessVacationCredit, HasFingerprint, FingerprintDate, MinistryFinanceApproval, ApprovalType,
            EntryDate
        )
        VALUES (
            @Id, @EmployeeId, @EmployeeNationalNumber, @DirectorateId, @DepartmentId, @SectionId, 
            @JobTitleId, @PositionId, @RankId, @GradeId, @StepId, @ContinuationId, @WorkCareerTypeId, 
            @SideId, @ExceptionTypeId, @EmploymentStatus, @LastPromotionDate, @LastRaiseDate, @NextRaiseDate, 
            @Basic_Salary, @Education, @CareerNotes, @ServiceSummaryNotes, @AssignBookNumber, @AssignBookDate,
            @InitiationBookNumber, @InitiationBookDate, @InitiationActualDate, @InitiationAtOfficeBookNumber, 
            @InitiationAtOfficeBookDate, @AdditionalService, @MartyreRelated, @PoliticalPrisoner, @PoliticalIsolation, 
            @EndOfServiceDate, @HasLeftEarlier, @Transferred, @DeletionBookNumber, @UpdateBookNumber, @PreviousDirectorate, 
            @NormalVacationCredit, @IllnessVacationCredit, @HasFingerprint, @FingerprintDate, @MinistryFinanceApproval, @ApprovalType,
            GETDATE()
        )
        """;

    public const string UpdateQuery = """
        UPDATE Career SET
            Emp_Id = @EmployeeId,
            Employee_National_Num = @EmployeeNationalNumber,
            Directorate_Id = @DirectorateId,
            Department_Id = @DepartmentId,
            Section_Id = @SectionId,
            Job_Title_Id = @JobTitleId,
            Position_Id = @PositionId,
            Rank_Id = @RankId,
            Grade = @GradeId,
            Step = @StepId,
            ContinuationId = @ContinuationId,
            Work_Career_Type_Id = @WorkCareerTypeId,
            SideId = @SideId,
            ExceptionTypeId = @ExceptionTypeId,
            Employment_Status = @EmploymentStatus,
            Last_Promotion_Date = @LastPromotionDate,
            Last_Raise_Date = @LastRaiseDate,
            Next_Raise_Date = @NextRaiseDate,
            Basic_Salary = @BasicSalary,
            Education = @Education,
            CareerNotes = @CareerNotes,
            ServiceSummaryNotes = @ServiceSummaryNotes,
            AssignBookNumber = @AssignBookNumber,
            AssignBookDate = @AssignBookDate,
            InitiationBookNumber = @InitiationBookNumber,
            InitiationBookDate = @InitiationBookDate,
            InitiationActualDate = @InitiationActualDate,
            InitiationAtOfficeBookNumber = @InitiationAtOfficeBookNumber,
            InitiationAtOfficeBookDate = @InitiationAtOfficeBookDate,
            AdditionalService = @AdditionalService,
            MartyreRelated = @MartyreRelated,
            PoliticalPrisoner = @PoliticalPrisoner,
            PoliticalIsolation = @PoliticalIsolation,
            EndOfServiceDate = @EndOfServiceDate,
            HasLeftEarlier = @HasLeftEarlier,
            Transferred = @Transferred,
            DeletionBookNumber = @DeletionBookNumber,
            UpdateBookNumber = @UpdateBookNumber,
            PreviousDirectorate = @PreviousDirectorate,
            NormalVacationCredit = @NormalVacationCredit,
            IllnessVacationCredit = @IllnessVacationCredit,
            HasFingerprint = @HasFingerprint,
            FingerprintDate = @FingerprintDate,
            MinistryFinanceApproval = @MinistryFinanceApproval,
            ApprovalType = @ApprovalType
        WHERE Career_Emp_Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Career WHERE Career_Emp_Id = @Id
        """;
}
