namespace Infrastructure.Queries;

public class ServiceTypeQueries
{
    public const string FindAllQuery = "SELECT Id, Name FROM Service_Type ORDER BY Name";
    public const string FindByIdQuery = "SELECT Id, Name FROM Service_Type WHERE Id = @Id";
    public const string InsertQuery = "INSERT INTO Service_Type (Id, Name) VALUES (@Id, @Name)";
    public const string UpdateQuery = "UPDATE Service_Type SET Name = @Name WHERE Id = @Id";
    public const string DeleteQuery = "DELETE FROM Service_Type WHERE Id = @Id";
}
