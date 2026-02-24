namespace Infrastructure.Queries;

public class CertificateQueries
{
    public const string FindAllQuery = """
        SELECT Id, Name, NoOfMonths FROM Certificate ORDER BY Name
        """;

    public const string FindByIdQuery = """
        SELECT Id, Name, NoOfMonths FROM Certificate WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Certificate (Id, Name, NoOfMonths) VALUES (@Id, @Name, @NoOfMonths)
        """;

    public const string UpdateQuery = """
        UPDATE Certificate SET Name = @Name, NoOfMonths = @NoOfMonths WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Certificate WHERE Id = @Id
        """;
}
