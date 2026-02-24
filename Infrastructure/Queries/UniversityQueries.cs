namespace Infrastructure.Queries;

public class UniversityQueries
{
    public const string FindAllQuery = """
        SELECT 
            Id,
            Name
        FROM University
        ORDER BY Name
        """;

    public const string FindByIdQuery = """
        SELECT 
            Id,
            Name
        FROM University
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO University (
            Id, Name
        )
        VALUES (
            @Id, @Name
        )
        """;

    public const string UpdateQuery = """
        UPDATE University SET
            Name = @Name
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM University WHERE Id = @Id
        """;
}
