namespace Infrastructure.Queries;

public class JobTitleQueries
{
    public const string FindAllQuery = """
        SELECT Id, Title, GradeId, JobTitleType
        FROM JobTitle
        ORDER BY Title
        """;

    public const string FindByIdQuery = """
        SELECT Id, Title, GradeId, JobTitleType
        FROM JobTitle
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO JobTitle (Id, Title, GradeId, JobTitleType)
        VALUES (@Id, @Title, @GradeId, @JobTitleType)
        """;

    public const string UpdateQuery = """
        UPDATE JobTitle SET
            Title = @Title,
            GradeId = @GradeId,
            JobTitleType = @JobTitleType
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM JobTitle WHERE Id = @Id
        """;
}
