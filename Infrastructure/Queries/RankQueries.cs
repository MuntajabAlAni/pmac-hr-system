namespace Infrastructure.Queries;

public class RankQueries
{
    public const string FindAllQuery = """
        SELECT Rank_Id AS Id, Rank_Name AS Description
        FROM Rank
        ORDER BY Rank_Name
        """;

    public const string FindByIdQuery = """
        SELECT Rank_Id AS Id, Rank_Name AS Description
        FROM Rank
        WHERE Rank_Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Rank (Rank_Id, Rank_Name)
        VALUES (@Id, @Description)
        """;

    public const string UpdateQuery = """
        UPDATE Rank SET
            Rank_Name = @Description
        WHERE Rank_Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Rank WHERE Rank_Id = @Id
        """;
}
