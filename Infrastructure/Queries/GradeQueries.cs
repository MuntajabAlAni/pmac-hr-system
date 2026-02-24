namespace Infrastructure.Queries;

public class GradeQueries
{
    public const string FindAllQuery = """
        SELECT Grade_Id AS Id, Grade_Name AS Name
        FROM Grade
        ORDER BY Grade_Name
        """;

    public const string FindByIdQuery = """
        SELECT Grade_Id AS Id, Grade_Name AS Name
        FROM Grade
        WHERE Grade_Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Grade (Grade_Id, Grade_Name)
        VALUES (@Id, @Name)
        """;

    public const string UpdateQuery = """
        UPDATE Grade SET
            Grade_Name = @Name
        WHERE Grade_Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Grade WHERE Grade_Id = @Id
        """;
}
