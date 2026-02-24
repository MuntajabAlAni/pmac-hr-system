namespace Infrastructure.Queries;

public class JobTitleQueries
{
    public const string FindAllQuery = """
        SELECT Job_Title_Id AS Id, Job_Title_Name AS Title
        FROM JobTitle
        ORDER BY Job_Title_Name
        """;

    public const string FindByIdQuery = """
        SELECT Job_Title_Id AS Id, Job_Title_Name AS Title
        FROM JobTitle
        WHERE Job_Title_Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO JobTitle (Job_Title_Id, Job_Title_Name)
        VALUES (@Id, @Title)
        """;

    public const string UpdateQuery = """
        UPDATE JobTitle SET
            Job_Title_Name = @Title
        WHERE Job_Title_Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM JobTitle WHERE Job_Title_Id = @Id
        """;
}
