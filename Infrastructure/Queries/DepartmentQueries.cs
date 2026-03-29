namespace Infrastructure.Queries;

public class DepartmentQueries
{
    public const string FindAllQuery = """
        SELECT D.Id, D.Name, D.HighAuthorityId, D.SubHighAuthorityId,
               D.DirectorateId, D.SubDirectorateId
        FROM Department D
        WHERE D.IsDeleted = 0
        ORDER BY D.Name
        """;

    public const string FindByIdQuery = """
        SELECT D.Id, D.Name, D.HighAuthorityId, D.SubHighAuthorityId,
               D.DirectorateId, D.SubDirectorateId
        FROM Department D
        WHERE D.Id = @Id
        """;

    public const string FindByDirectorateIdQuery = """
        SELECT Id, Name, HighAuthorityId, SubHighAuthorityId,
               DirectorateId, SubDirectorateId
        FROM Department
        WHERE DirectorateId = @DirectorateId AND IsDeleted = 0
        ORDER BY Name
        """;

    public const string InsertQuery = """
        INSERT INTO Department (Id, Name, HighAuthorityId, SubHighAuthorityId, DirectorateId, SubDirectorateId)
        VALUES (@Id, @Name, @HighAuthorityId, @SubHighAuthorityId, @DirectorateId, @SubDirectorateId)
        """;

    public const string UpdateQuery = """
        UPDATE Department SET
            Name = @Name
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        UPDATE Department SET IsDeleted = 1 WHERE Id = @Id
        """;
}
