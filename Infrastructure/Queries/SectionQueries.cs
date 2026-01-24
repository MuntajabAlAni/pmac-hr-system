namespace Infrastructure.Queries;

public class SectionQueries
{
    public const string FindAllQuery = """
        SELECT S.Section_Id, S.Section_Name, S.Department_Id,
               D.Deptartment_Name, D.Directorate_Id
        FROM Section_tbl S
        LEFT JOIN Department_tbl D ON S.Department_Id = D.Deptartment_Id
        ORDER BY S.Section_Name
        """;

    public const string FindByIdQuery = """
        SELECT S.Section_Id, S.Section_Name, S.Department_Id,
               D.Deptartment_Name, D.Directorate_Id
        FROM Section_tbl S
        LEFT JOIN Department_tbl D ON S.Department_Id = D.Deptartment_Id
        WHERE S.Section_Id = @Id
        """;

    public const string FindByDepartmentIdQuery = """
        SELECT Section_Id, Section_Name, Department_Id
        FROM Section_tbl
        WHERE Department_Id = @DepartmentId
        ORDER BY Section_Name
        """;

    public const string InsertQuery = """
        INSERT INTO Section_tbl (Section_Name, Department_Id)
        OUTPUT inserted.Section_Id
        VALUES (@Section_Name, @Department_Id)
        """;

    public const string UpdateQuery = """
        UPDATE Section_tbl SET
            Section_Name = @Section_Name,
            Department_Id = @Department_Id
        WHERE Section_Id = @Section_Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Section_tbl WHERE Section_Id = @Id
        """;
}
