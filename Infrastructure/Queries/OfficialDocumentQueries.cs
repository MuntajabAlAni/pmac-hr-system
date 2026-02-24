namespace Infrastructure.Queries;

public class OfficialDocumentQueries
{
    public const string FindAllQuery = """
        SELECT 
            OD.Id,
            OD.EmployeeId,
            OD.DocumentTypeId,
            OD.IssueNumber,
            OD.IssueDate,
            OD.DestinationOrSubject,
            OD.Subject,
            OD.EffectiveDate,
            OD.Notes,
            OD.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName,
            ODT.Name AS DocumentTypeName
        FROM Official_Document OD
        LEFT JOIN Employee E ON OD.EmployeeId = E.Emp_Id
        LEFT JOIN Official_Document_Type ODT ON OD.DocumentTypeId = ODT.Id
        ORDER BY OD.IssueDate DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            OD.Id,
            OD.EmployeeId,
            OD.DocumentTypeId,
            OD.IssueNumber,
            OD.IssueDate,
            OD.DestinationOrSubject,
            OD.Subject,
            OD.EffectiveDate,
            OD.Notes,
            OD.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName,
            ODT.Name AS DocumentTypeName
        FROM Official_Document OD
        LEFT JOIN Employee E ON OD.EmployeeId = E.Emp_Id
        LEFT JOIN Official_Document_Type ODT ON OD.DocumentTypeId = ODT.Id
        WHERE OD.Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Official_Document (
            Id, EmployeeId, DocumentTypeId, IssueNumber, IssueDate, 
            DestinationOrSubject, Subject, EffectiveDate, Notes, FilePath
        )
        VALUES (
            @Id, @EmployeeId, @DocumentTypeId, @IssueNumber, @IssueDate, 
            @DestinationOrSubject, @Subject, @EffectiveDate, @Notes, @FilePath
        )
        """;

    public const string UpdateQuery = """
        UPDATE Official_Document SET
            EmployeeId = @EmployeeId,
            DocumentTypeId = @DocumentTypeId,
            IssueNumber = @IssueNumber,
            IssueDate = @IssueDate,
            DestinationOrSubject = @DestinationOrSubject,
            Subject = @Subject,
            EffectiveDate = @EffectiveDate,
            Notes = @Notes,
            FilePath = @FilePath
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Official_Document WHERE Id = @Id
        """;
}
