namespace Infrastructure.Queries;

public class RaiseTypeQueries
{
    public const string FindAllQuery = """
        SELECT Id, Name
        FROM RaiseType
        ORDER BY Name
        """;

    public const string FindByIdQuery = """
        SELECT Id, Name
        FROM RaiseType
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO RaiseType (Id, Name)
        VALUES (@Id, @Name)
        """;

    public const string UpdateQuery = """
        UPDATE RaiseType SET
            Name = @Name
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM RaiseType WHERE Id = @Id
        """;
}
