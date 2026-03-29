namespace Infrastructure.Queries;

public class DirectorateQueries
{
    public const string FindAllQuery = """
        SELECT D.Id, D.Name, D.HighAuthorityId, D.SubHighAuthorityId
        FROM Directorate D
        WHERE D.IsDeleted = 0
        ORDER BY D.Name
        """;

    public const string FindByIdQuery = """
        SELECT D.Id, D.Name, D.HighAuthorityId, D.SubHighAuthorityId
        FROM Directorate D
        WHERE D.Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Directorate (Id, Name, HighAuthorityId, SubHighAuthorityId)
        VALUES (@Id, @Name, @HighAuthorityId, @SubHighAuthorityId)
        """;

    public const string UpdateQuery = """
        UPDATE Directorate SET
            Name = @Name
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        UPDATE Directorate SET IsDeleted = 1 WHERE Id = @Id
        """;
}
