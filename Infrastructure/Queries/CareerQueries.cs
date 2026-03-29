namespace Infrastructure.Queries;

public class CareerQueries
{
    public const string FindAllQuery = """
        SELECT 
            c.Id, c.EmployeeId, c.MovementDate, c.MovementType, c.Notes,
            c.AuthorityName, c.SubAuthorityName,
            c.DirectorateName, c.SubDirectorateName,
            c.DepartmentName, c.SectionName, c.UnitName,
            c.JobTitle, c.GradeName, c.BasicSalary
        FROM Career c
        ORDER BY c.MovementDate DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            c.Id, c.EmployeeId, c.MovementDate, c.MovementType, c.Notes,
            c.AuthorityName, c.SubAuthorityName,
            c.DirectorateName, c.SubDirectorateName,
            c.DepartmentName, c.SectionName, c.UnitName,
            c.JobTitle, c.GradeName, c.BasicSalary
        FROM Career c
        WHERE c.Id = @Id
        """;
        
    public const string FindByEmployeeIdQuery = """
        SELECT 
            c.Id, c.EmployeeId, c.MovementDate, c.MovementType, c.Notes,
            c.AuthorityName, c.SubAuthorityName,
            c.DirectorateName, c.SubDirectorateName,
            c.DepartmentName, c.SectionName, c.UnitName,
            c.JobTitle, c.GradeName, c.BasicSalary
        FROM Career c
        WHERE c.EmployeeId = @EmployeeId
        ORDER BY c.MovementDate DESC
        """;

    public const string InsertQuery = """
        INSERT INTO Career (
            Id, EmployeeId, MovementDate, MovementType, Notes,
            AuthorityName, SubAuthorityName,
            DirectorateName, SubDirectorateName,
            DepartmentName, SectionName, UnitName,
            JobTitle, GradeName, BasicSalary
        )
        VALUES (
            @Id, @EmployeeId, @MovementDate, @MovementType, @Notes,
            @AuthorityName, @SubAuthorityName,
            @DirectorateName, @SubDirectorateName,
            @DepartmentName, @SectionName, @UnitName,
            @JobTitle, @GradeName, @BasicSalary
        )
        """;

    public const string UpdateQuery = """
        UPDATE Career SET
            Notes = @Notes
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Career WHERE Id = @Id
        """;
}
