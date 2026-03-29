namespace Infrastructure.Queries;

public class SectionQueries
{
    public const string FindAllQuery = """
        SELECT S.Id, S.Name, S.HighAuthorityId, S.SubHighAuthorityId,
               S.DirectorateId, S.SubDirectorateId, S.DepartmentId
        FROM Section S
        WHERE S.IsDeleted = 0
        ORDER BY S.Name
        """;

    public const string FindByIdQuery = """
        SELECT S.Id, S.Name, S.HighAuthorityId, S.SubHighAuthorityId,
               S.DirectorateId, S.SubDirectorateId, S.DepartmentId
        FROM Section S
        WHERE S.Id = @Id
        """;

    public const string FindByDepartmentIdQuery = """
        SELECT Id, Name, HighAuthorityId, SubHighAuthorityId,
               DirectorateId, SubDirectorateId, DepartmentId
        FROM Section
        WHERE DepartmentId = @DepartmentId AND IsDeleted = 0
        ORDER BY Name
        """;

    public const string InsertQuery = """
        INSERT INTO Section (Id, Name, HighAuthorityId, SubHighAuthorityId, DirectorateId, SubDirectorateId, DepartmentId)
        VALUES (@Id, @Name, @HighAuthorityId, @SubHighAuthorityId, @DirectorateId, @SubDirectorateId, @DepartmentId)
        """;

    public const string UpdateQuery = """
        UPDATE Section SET
            Name = @Name
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        UPDATE Section SET IsDeleted = 1 WHERE Id = @Id
        """;
}
