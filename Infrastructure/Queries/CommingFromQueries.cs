namespace Infrastructure.Queries;

public class CommingFromQueries
{
    public const string FindAllQuery = """
        SELECT Id, Name
        FROM CommingFrom
        ORDER BY Name
        """;

    public const string FindByIdQuery = """
        SELECT Id, Name
        FROM CommingFrom
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO CommingFrom (Id, Name)
        VALUES (@Id, @Name)
        """;

    public const string UpdateQuery = """
        UPDATE CommingFrom SET
            Name = @Name
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM CommingFrom WHERE Id = @Id
        """;
}
