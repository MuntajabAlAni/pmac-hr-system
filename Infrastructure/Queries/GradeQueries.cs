namespace Infrastructure.Queries;

public class GradeQueries
{
    public const string FindAllQuery = """
        SELECT Id, GradeName, GradeLevel
        FROM Grade
        ORDER BY GradeName
        """;

    public const string FindByIdQuery = """
        SELECT Id, GradeName, GradeLevel
        FROM Grade
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Grade (Id, GradeName, GradeLevel)
        VALUES (@Id, @GradeName, @GradeLevel)
        """;

    public const string UpdateQuery = """
        UPDATE Grade SET
            GradeName = @GradeName,
            GradeLevel = @GradeLevel
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Grade WHERE Id = @Id
        """;
}
