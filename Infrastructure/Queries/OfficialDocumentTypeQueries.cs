namespace Infrastructure.Queries;

public class OfficialDocumentTypeQueries
{
    public const string FindAllQuery = """
        SELECT Id, Name FROM Official_Document_Type ORDER BY Name
        """;

    public const string FindByIdQuery = """
        SELECT Id, Name FROM Official_Document_Type WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Official_Document_Type (Id, Name) VALUES (@Id, @Name)
        """;

    public const string UpdateQuery = """
        UPDATE Official_Document_Type SET Name = @Name WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Official_Document_Type WHERE Id = @Id
        """;
}
