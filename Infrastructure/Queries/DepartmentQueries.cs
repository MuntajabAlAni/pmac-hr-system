namespace Infrastructure.Queries;

public class DepartmentQueries
{
    public const string FindAllQuery = """
        SELECT D.Deptartment_Id AS Id, D.Deptartment_Name AS Name, D.Directorate_Id AS DirectorateId,
               Dir.Directorate_Name AS DirectorateName, D.Exception
        FROM Department D
        LEFT JOIN Directorate Dir ON D.Directorate_Id = Dir.Directorate_Id
        WHERE D.hidden = 0
        ORDER BY D.Deptartment_Name
        """;

    public const string FindByIdQuery = """
        SELECT D.Deptartment_Id AS Id, D.Deptartment_Name AS Name, D.Directorate_Id AS DirectorateId,
               Dir.Directorate_Name AS DirectorateName, D.Exception
        FROM Department D
        LEFT JOIN Directorate Dir ON D.Directorate_Id = Dir.Directorate_Id
        WHERE D.Deptartment_Id = @Id
        """;

    public const string FindByDirectorateIdQuery = """
        SELECT Deptartment_Id AS Id, Deptartment_Name AS Name, Directorate_Id AS DirectorateId, Exception
        FROM Department
        WHERE Directorate_Id = @DirectorateId AND hidden = 0
        ORDER BY Deptartment_Name
        """;

    public const string InsertQuery = """
        INSERT INTO Department (Deptartment_Id, Deptartment_Name, Directorate_Id, Exception, hidden)
        VALUES (@Deptartment_Id, @Deptartment_Name, @Directorate_Id, @Exception, 0)
        """;

    public const string UpdateQuery = """
        UPDATE Department SET
            Deptartment_Name = @Deptartment_Name,
            Directorate_Id = @Directorate_Id,
            Exception = @Exception
        WHERE Deptartment_Id = @Deptartment_Id
        """;

    public const string DeleteQuery = """
        UPDATE Department SET hidden = 1 WHERE Deptartment_Id = @Id
        """;
}
