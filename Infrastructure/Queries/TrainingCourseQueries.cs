namespace Infrastructure.Queries;

public class TrainingCourseQueries
{
    public const string FindAllQuery = """
        SELECT 
            TC.Id,
            TC.EmployeeId,
            TC.EmployeeName,
            TC.OrderNumber,
            TC.OrderDate,
            TC.CourseName,
            TC.Sponsor,
            TC.CourseEvaluator,
            TC.NumberOfDays,
            TC.StartDate,
            TC.EndDate,
            TC.DetachmentDate,
            TC.InitiationDate,
            TC.Evaluation,
            TC.CourseNotes,
            TC.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName
        FROM Training_Course TC
        LEFT JOIN Employee E ON TC.EmployeeId = E.Emp_Id
        ORDER BY TC.StartDate DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            TC.Id,
            TC.EmployeeId,
            TC.EmployeeName,
            TC.OrderNumber,
            TC.OrderDate,
            TC.CourseName,
            TC.Sponsor,
            TC.CourseEvaluator,
            TC.NumberOfDays,
            TC.StartDate,
            TC.EndDate,
            TC.DetachmentDate,
            TC.InitiationDate,
            TC.Evaluation,
            TC.CourseNotes,
            TC.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName
        FROM Training_Course TC
        LEFT JOIN Employee E ON TC.EmployeeId = E.Emp_Id
        WHERE TC.Id = @Id
        """;

    public const string FindByEmployeeIdQuery = """
        SELECT 
            TC.Id,
            TC.EmployeeId,
            TC.EmployeeName,
            TC.OrderNumber,
            TC.OrderDate,
            TC.CourseName,
            TC.Sponsor,
            TC.CourseEvaluator,
            TC.NumberOfDays,
            TC.StartDate,
            TC.EndDate,
            TC.DetachmentDate,
            TC.InitiationDate,
            TC.Evaluation,
            TC.CourseNotes,
            TC.FilePath
        FROM Training_Course TC
        WHERE TC.EmployeeId = @EmployeeId
        ORDER BY TC.StartDate DESC
        """;

    public const string InsertQuery = """
        INSERT INTO Training_Course (
            Id, EmployeeId, EmployeeName, OrderNumber, OrderDate,
            CourseName, Sponsor, CourseEvaluator, NumberOfDays,
            StartDate, EndDate, DetachmentDate, InitiationDate,
            Evaluation, CourseNotes, FilePath
        )
        VALUES (
            @Id, @EmployeeId, @EmployeeName, @OrderNumber, @OrderDate,
            @CourseName, @Sponsor, @CourseEvaluator, @NumberOfDays,
            @StartDate, @EndDate, @DetachmentDate, @InitiationDate,
            @Evaluation, @CourseNotes, @FilePath
        )
        """;

    public const string UpdateQuery = """
        UPDATE Training_Course SET
            EmployeeId = @EmployeeId,
            EmployeeName = @EmployeeName,
            OrderNumber = @OrderNumber,
            OrderDate = @OrderDate,
            CourseName = @CourseName,
            Sponsor = @Sponsor,
            CourseEvaluator = @CourseEvaluator,
            NumberOfDays = @NumberOfDays,
            StartDate = @StartDate,
            EndDate = @EndDate,
            DetachmentDate = @DetachmentDate,
            InitiationDate = @InitiationDate,
            Evaluation = @Evaluation,
            CourseNotes = @CourseNotes,
            FilePath = @FilePath
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Training_Course WHERE Id = @Id
        """;
}
