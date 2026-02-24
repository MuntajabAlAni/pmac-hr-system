namespace Infrastructure.Queries;

public class StepQueries
{
    public const string FindAllQuery = """
        SELECT Step_Id AS Id, Step_Name AS Name
        FROM Step
        ORDER BY Step_Name
        """;

    public const string FindByIdQuery = """
        SELECT Step_Id AS Id, Step_Name AS Name
        FROM Step
        WHERE Step_Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Step (Step_Id, Step_Name)
        VALUES (@Id, @Name)
        """;

    public const string UpdateQuery = """
        UPDATE Step SET
            Step_Name = @Name
        WHERE Step_Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Step WHERE Step_Id = @Id
        """;
}
