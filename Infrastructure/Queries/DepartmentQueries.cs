namespace Infrastructure.Queries;

public class DepartmentQueries
{
    public const string FindAllQuery = """
        SELECT D.Deptartment_Id, D.Deptartment_Name, D.Directorate_Id,
               Dir.Directorate_Name, D.Exception
        FROM Department_tbl D
        LEFT JOIN Directorate_tbl Dir ON D.Directorate_Id = Dir.Directorate_Id
        WHERE D.hidden = 0
        ORDER BY D.Deptartment_Name
        """;

    public const string FindByIdQuery = """
        SELECT D.Deptartment_Id, D.Deptartment_Name, D.Directorate_Id,
               Dir.Directorate_Name, D.Exception
        FROM Department_tbl D
        LEFT JOIN Directorate_tbl Dir ON D.Directorate_Id = Dir.Directorate_Id
        WHERE D.Deptartment_Id = @Id
        """;

    public const string FindByDirectorateIdQuery = """
        SELECT Deptartment_Id, Deptartment_Name, Directorate_Id, Exception
        FROM Department_tbl
        WHERE Directorate_Id = @DirectorateId AND hidden = 0
        ORDER BY Deptartment_Name
        """;

    public const string InsertQuery = """
        INSERT INTO Department_tbl (Deptartment_Name, Directorate_Id, Exception, hidden)
        OUTPUT inserted.Deptartment_Id
        VALUES (@Deptartment_Name, @Directorate_Id, @Exception, 0)
        """;

    public const string UpdateQuery = """
        UPDATE Department_tbl SET
            Deptartment_Name = @Deptartment_Name,
            Directorate_Id = @Directorate_Id,
            Exception = @Exception
        WHERE Deptartment_Id = @Deptartment_Id
        """;

    public const string DeleteQuery = """
        UPDATE Department_tbl SET hidden = 1 WHERE Deptartment_Id = @Id
        """;
}
