namespace Infrastructure.Queries;

public class CommitteeQueries
{
    public const string FindAllQuery = """
        SELECT 
            C.Id,
            C.EmployeeId,
            C.EmployeeName,
            C.CommitteeType,
            C.CommitteeOrderNumber,
            C.OrderDate,
            C.CommitteeDurationType,
            C.NumberOfDays,
            C.CommitteeNotes,
            C.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName
        FROM Committee C
        LEFT JOIN Employee E ON C.EmployeeId = E.Emp_Id
        ORDER BY C.OrderDate DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            C.Id,
            C.EmployeeId,
            C.EmployeeName,
            C.CommitteeType,
            C.CommitteeOrderNumber,
            C.OrderDate,
            C.CommitteeDurationType,
            C.NumberOfDays,
            C.CommitteeNotes,
            C.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName
        FROM Committee C
        LEFT JOIN Employee E ON C.EmployeeId = E.Emp_Id
        WHERE C.Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Committee (
            Id, EmployeeId, EmployeeName, CommitteeType, CommitteeOrderNumber,
            OrderDate, CommitteeDurationType, NumberOfDays, CommitteeNotes, FilePath
        )
        VALUES (
            @Id, @EmployeeId, @EmployeeName, @CommitteeType, @CommitteeOrderNumber,
            @OrderDate, @CommitteeDurationType, @NumberOfDays, @CommitteeNotes, @FilePath
        )
        """;

    public const string UpdateQuery = """
        UPDATE Committee SET
            EmployeeId = @EmployeeId,
            EmployeeName = @EmployeeName,
            CommitteeType = @CommitteeType,
            CommitteeOrderNumber = @CommitteeOrderNumber,
            OrderDate = @OrderDate,
            CommitteeDurationType = @CommitteeDurationType,
            NumberOfDays = @NumberOfDays,
            CommitteeNotes = @CommitteeNotes,
            FilePath = @FilePath
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Committee WHERE Id = @Id
        """;
}
