namespace Repositories.Queries;

public class DirectorateQueries
{
    public const string FindAllQuery = """
        SELECT Directorate_Id, Directorate_Name, Exception
        FROM Directorate_tbl
        WHERE hidden = 0
        ORDER BY Directorate_Name
        """;

    public const string FindByIdQuery = """
        SELECT Directorate_Id, Directorate_Name, Exception
        FROM Directorate_tbl
        WHERE Directorate_Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Directorate_tbl (Directorate_Name, Exception, hidden)
        OUTPUT inserted.Directorate_Id
        VALUES (@Directorate_Name, @Exception, 0)
        """;

    public const string UpdateQuery = """
        UPDATE Directorate_tbl SET
            Directorate_Name = @Directorate_Name,
            Exception = @Exception
        WHERE Directorate_Id = @Directorate_Id
        """;

    public const string DeleteQuery = """
        UPDATE Directorate_tbl SET hidden = 1 WHERE Directorate_Id = @Id
        """;
}
