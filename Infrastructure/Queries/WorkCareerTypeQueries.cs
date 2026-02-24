namespace Infrastructure.Queries;

public class WorkCareerTypeQueries
{
    public const string FindAllQuery = """
        SELECT Id, Name
        FROM Work_Career_Type
        ORDER BY Name
        """;

    public const string FindByIdQuery = """
        SELECT Id, Name
        FROM Work_Career_Type
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Work_Career_Type (Id, Name)
        VALUES (@Id, @Name)
        """;

    public const string UpdateQuery = """
        UPDATE Work_Career_Type SET
            Name = @Name
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Work_Career_Type WHERE Id = @Id
        """;
}
