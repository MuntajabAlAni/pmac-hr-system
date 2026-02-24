namespace Infrastructure.Queries;

public class TaskStatusQueries
{
    public const string FindAllQuery = "SELECT Id, Name FROM Task_Status ORDER BY Name";
    public const string FindByIdQuery = "SELECT Id, Name FROM Task_Status WHERE Id = @Id";
    public const string InsertQuery = "INSERT INTO Task_Status (Id, Name) VALUES (@Id, @Name)";
    public const string UpdateQuery = "UPDATE Task_Status SET Name = @Name WHERE Id = @Id";
    public const string DeleteQuery = "DELETE FROM Task_Status WHERE Id = @Id";
}
