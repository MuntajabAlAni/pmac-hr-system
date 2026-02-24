namespace Infrastructure.Queries;

public class FingerPrintExceptionTypeQueries
{
    public const string FindAllQuery = """
        SELECT Id, Name
        FROM FingerPrintExceptionType
        ORDER BY Name
        """;

    public const string FindByIdQuery = """
        SELECT Id, Name
        FROM FingerPrintExceptionType
        WHERE Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO FingerPrintExceptionType (Id, Name)
        VALUES (@Id, @Name)
        """;

    public const string UpdateQuery = """
        UPDATE FingerPrintExceptionType SET
            Name = @Name
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM FingerPrintExceptionType WHERE Id = @Id
        """;
}
