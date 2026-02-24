namespace Infrastructure.Queries;

public class MaritalStatusQueries
{
    public const string FindAllQuery = "SELECT Id, Name FROM Marital_Status ORDER BY Name";
    public const string FindByIdQuery = "SELECT Id, Name FROM Marital_Status WHERE Id = @Id";
    public const string InsertQuery = "INSERT INTO Marital_Status (Id, Name) VALUES (@Id, @Name)";
    public const string UpdateQuery = "UPDATE Marital_Status SET Name = @Name WHERE Id = @Id";
    public const string DeleteQuery = "DELETE FROM Marital_Status WHERE Id = @Id";
}
