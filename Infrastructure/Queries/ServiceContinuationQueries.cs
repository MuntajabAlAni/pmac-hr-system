namespace Infrastructure.Queries;

public class ServiceContinuationQueries
{
    public const string FindAllQuery = """
        SELECT Id, Name
        FROM ServiceContinuation
        ORDER BY Name
        """;

    public const string FindByIdQuery = """
        SELECT Id, Name
        FROM ServiceContinuation
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO ServiceContinuation (Id, Name)
        VALUES (@Id, @Name)
        """;

    public const string UpdateQuery = """
        UPDATE ServiceContinuation SET
            Name = @Name
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM ServiceContinuation WHERE Id = @Id
        """;
}
