namespace Infrastructure.Queries;

public class PersonalCardQueries
{
    public const string FindAllQuery = """
        SELECT 
            PC.Id,
            PC.EmployeeId,
            PC.CardNumber,
            PC.IssuanceDate,
            PC.ExpiryDate,
            PC.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName
        FROM Personal_Card PC
        LEFT JOIN Employee E ON PC.EmployeeId = E.Emp_Id
        ORDER BY PC.IssuanceDate DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            PC.Id,
            PC.EmployeeId,
            PC.CardNumber,
            PC.IssuanceDate,
            PC.ExpiryDate,
            PC.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName
        FROM Personal_Card PC
        LEFT JOIN Employee E ON PC.EmployeeId = E.Emp_Id
        WHERE PC.Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Personal_Card (Id, EmployeeId, CardNumber, IssuanceDate, ExpiryDate, FilePath)
        VALUES (@Id, @EmployeeId, @CardNumber, @IssuanceDate, @ExpiryDate, @FilePath)
        """;

    public const string UpdateQuery = """
        UPDATE Personal_Card SET
            EmployeeId = @EmployeeId,
            CardNumber = @CardNumber,
            IssuanceDate = @IssuanceDate,
            ExpiryDate = @ExpiryDate,
            FilePath = @FilePath
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Personal_Card WHERE Id = @Id
        """;
}
