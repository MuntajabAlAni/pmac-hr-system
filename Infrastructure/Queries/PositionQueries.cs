namespace Infrastructure.Queries;

public class PositionQueries
{
    public const string FindAllQuery = """
        SELECT Id, PositionName, PositionLevel
        FROM Position
        ORDER BY PositionName
        """;

    public const string FindByIdQuery = """
        SELECT Id, PositionName, PositionLevel
        FROM Position
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Position (Id, PositionName, PositionLevel)
        VALUES (@Id, @PositionName, @PositionLevel)
        """;

    public const string UpdateQuery = """
        UPDATE Position SET
            PositionName = @PositionName,
            PositionLevel = @PositionLevel
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Position WHERE Id = @Id
        """;
}
