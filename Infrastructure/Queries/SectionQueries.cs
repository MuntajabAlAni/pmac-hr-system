namespace Infrastructure.Queries;

public class SectionQueries
{
    public const string FindAllQuery = """
        SELECT S.Section_Id AS Id, S.Section_Name AS Name, S.Department_Id AS DepartmentId,
               D.Deptartment_Name AS DepartmentName, D.Directorate_Id AS DirectorateId
        FROM Section S
        LEFT JOIN Department D ON S.Department_Id = D.Deptartment_Id
        ORDER BY S.Section_Name
        """;

    public const string FindByIdQuery = """
        SELECT S.Section_Id AS Id, S.Section_Name AS Name, S.Department_Id AS DepartmentId,
               D.Deptartment_Name AS DepartmentName, D.Directorate_Id AS DirectorateId
        FROM Section S
        LEFT JOIN Department D ON S.Department_Id = D.Deptartment_Id
        WHERE S.Section_Id = @Id
        """;

    public const string FindByDepartmentIdQuery = """
        SELECT Section_Id AS Id, Section_Name AS Name, Department_Id AS DepartmentId
        FROM Section
        WHERE Department_Id = @DepartmentId
        ORDER BY Section_Name
        """;

    public const string InsertQuery = """
        INSERT INTO Section (Section_Id, Section_Name, Department_Id)
        VALUES (@Section_Id, @Section_Name, @Department_Id)
        """;

    public const string UpdateQuery = """
        UPDATE Section SET
            Section_Name = @Section_Name,
            Department_Id = @Department_Id
        WHERE Section_Id = @Section_Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Section WHERE Section_Id = @Id
        """;
}
