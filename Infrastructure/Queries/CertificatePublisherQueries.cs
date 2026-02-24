namespace Infrastructure.Queries;

public class CertificatePublisherQueries
{
    public const string FindAllQuery = "SELECT Id, Name FROM Certificate_Publisher ORDER BY Name";
    public const string FindByIdQuery = "SELECT Id, Name FROM Certificate_Publisher WHERE Id = @Id";
    public const string InsertQuery = "INSERT INTO Certificate_Publisher (Id, Name) VALUES (@Id, @Name)";
    public const string UpdateQuery = "UPDATE Certificate_Publisher SET Name = @Name WHERE Id = @Id";
    public const string DeleteQuery = "DELETE FROM Certificate_Publisher WHERE Id = @Id";
}
