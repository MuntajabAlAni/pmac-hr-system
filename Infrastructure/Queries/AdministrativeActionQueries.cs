namespace Infrastructure.Queries;

public class AdministrativeActionQueries
{
    public const string FindAllQuery = """
        SELECT 
            AA.Id,
            AA.EmployeeId,
            AA.ActionTypeId,
            AA.IssueNumber,
            AA.IssueDate,
            AA.Issuer,
            AA.Reason,
            AA.Notes,
            AA.OldOrderNumber,
            AA.OldOrderDate,
            AA.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName,
            AAT.Name AS ActionTypeName
        FROM Administrative_Action AA
        LEFT JOIN Employee E ON AA.EmployeeId = E.Emp_Id
        LEFT JOIN Administrative_Action_Type AAT ON AA.ActionTypeId = AAT.Id
        ORDER BY AA.IssueDate DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            AA.Id,
            AA.EmployeeId,
            AA.ActionTypeId,
            AA.IssueNumber,
            AA.IssueDate,
            AA.Issuer,
            AA.Reason,
            AA.Notes,
            AA.OldOrderNumber,
            AA.OldOrderDate,
            AA.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName,
            AAT.Name AS ActionTypeName
        FROM Administrative_Action AA
        LEFT JOIN Employee E ON AA.EmployeeId = E.Emp_Id
        LEFT JOIN Administrative_Action_Type AAT ON AA.ActionTypeId = AAT.Id
        WHERE AA.Id = @Id
        """;

    public const string FindByEmployeeIdQuery = """
        SELECT 
            AA.Id,
            AA.EmployeeId,
            AA.ActionTypeId,
            AA.IssueNumber,
            AA.IssueDate,
            AA.Issuer,
            AA.Reason,
            AA.Notes,
            AA.OldOrderNumber,
            AA.OldOrderDate,
            AA.FilePath,
            AAT.Name AS ActionTypeName
        FROM Administrative_Action AA
        LEFT JOIN Administrative_Action_Type AAT ON AA.ActionTypeId = AAT.Id
        WHERE AA.EmployeeId = @EmployeeId
        ORDER BY AA.IssueDate DESC
        """;

    public const string InsertQuery = """
        INSERT INTO Administrative_Action (
            Id, EmployeeId, ActionTypeId, IssueNumber, IssueDate,
            Issuer, Reason, Notes, OldOrderNumber, OldOrderDate, FilePath
        )
        VALUES (
            @Id, @EmployeeId, @ActionTypeId, @IssueNumber, @IssueDate,
            @Issuer, @Reason, @Notes, @OldOrderNumber, @OldOrderDate, @FilePath
        )
        """;

    public const string UpdateQuery = """
        UPDATE Administrative_Action SET
            EmployeeId = @EmployeeId,
            ActionTypeId = @ActionTypeId,
            IssueNumber = @IssueNumber,
            IssueDate = @IssueDate,
            Issuer = @Issuer,
            Reason = @Reason,
            Notes = @Notes,
            OldOrderNumber = @OldOrderNumber,
            OldOrderDate = @OldOrderDate,
            FilePath = @FilePath
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Administrative_Action WHERE Id = @Id
        """;
}
