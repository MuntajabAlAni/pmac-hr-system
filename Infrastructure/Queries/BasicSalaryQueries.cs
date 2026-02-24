namespace Infrastructure.Queries;

public class BasicSalaryQueries
{
    public const string FindAllQuery = """
        SELECT Id, Salary
        FROM Basic_Salary
        ORDER BY Salary
        """;

    public const string FindByIdQuery = """
        SELECT Id, Salary
        FROM Basic_Salary
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Basic_Salary (Id, Salary)
        VALUES (@Id, @Salary)
        """;

    public const string UpdateQuery = """
        UPDATE Basic_Salary SET
            Salary = @Salary
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Basic_Salary WHERE Id = @Id
        """;
}
