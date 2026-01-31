namespace Infrastructure.Queries;

public class DirectorateQueries
{
    public const string FindAllQuery = """
        SELECT Directorate_Id, Directorate_Name, Exception
        FROM Directorate
        WHERE hidden = 0
        ORDER BY Directorate_Name
        """;

    public const string FindByIdQuery = """
        SELECT Directorate_Id, Directorate_Name, Exception
        FROM Directorate
        WHERE Directorate_Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Directorate (Directorate_Id, Directorate_Name, Exception, hidden)
        VALUES (@Directorate_Id, @Directorate_Name, @Exception, 0)
        """;

    public const string UpdateQuery = """
        UPDATE Directorate SET
            Directorate_Name = @Directorate_Name,
            Exception = @Exception
        WHERE Directorate_Id = @Directorate_Id
        """;

    public const string DeleteQuery = """
        UPDATE Directorate SET hidden = 1 WHERE Directorate_Id = @Id
        """;
}
