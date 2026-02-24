namespace Infrastructure.Queries;

public class PositionQueries
{
    public const string FindAllQuery = """
        SELECT Position_Id AS Id, Position_Name AS Title
        FROM Position
        ORDER BY Position_Name
        """;

    public const string FindByIdQuery = """
        SELECT Position_Id AS Id, Position_Name AS Title
        FROM Position
        WHERE Position_Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Position (Position_Id, Position_Name)
        VALUES (@Id, @Title)
        """;

    public const string UpdateQuery = """
        UPDATE Position SET
            Position_Name = @Title
        WHERE Position_Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Position WHERE Position_Id = @Id
        """;
}
