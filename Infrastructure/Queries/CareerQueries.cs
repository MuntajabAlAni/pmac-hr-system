namespace Infrastructure.Queries;

public class CareerQueries
{
    public const string FindByEmployeeIdQuery = """
        SELECT C.*, 
               D.Directorate_Name, Dept.Deptartment_Name, S.Section_Name,
               JT.Job_Title, P.Position_Name, G.Grade_Name, St.Step_Name,
               R.Rank_Name
        FROM Career_Tbl C
        LEFT JOIN Directorate_tbl D ON C.Directorate_Id = D.Directorate_Id
        LEFT JOIN Department_tbl Dept ON C.Department_Id = Dept.Deptartment_Id
        LEFT JOIN Section_tbl S ON C.Section_Id = S.Section_Id
        LEFT JOIN Job_Title_Tbl JT ON C.Job_Title_Id = JT.Job_Title_Id
        LEFT JOIN Position_Tbl P ON C.Position_Id = P.Position_Id
        LEFT JOIN Grade_Tbl G ON C.Grade = G.Grade_Id
        LEFT JOIN Step_Tbl St ON C.Step = St.Step_Id
        LEFT JOIN Ranks_Tbl R ON C.Rank_Id = R.Rank_Id
        WHERE C.Emp_Id = @EmployeeId
        """;

    public const string FindByIdQuery = """
        SELECT C.*, 
               D.Directorate_Name, Dept.Deptartment_Name, S.Section_Name,
               JT.Job_Title, P.Position_Name
        FROM Career_Tbl C
        LEFT JOIN Directorate_tbl D ON C.Directorate_Id = D.Directorate_Id
        LEFT JOIN Department_tbl Dept ON C.Department_Id = Dept.Deptartment_Id
        LEFT JOIN Section_tbl S ON C.Section_Id = S.Section_Id
        LEFT JOIN Job_Title_Tbl JT ON C.Job_Title_Id = JT.Job_Title_Id
        LEFT JOIN Position_Tbl P ON C.Position_Id = P.Position_Id
        WHERE C.Career_Emp_Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Career_Tbl (
            Emp_Id, Emp_Name, Employee_National_Num, Directorate_Id, Department_Id,
            Section_Id, Job_Title_Id, Grade, Step, Position_Id, Employment_Status,
            Last_Promotion_Date, Last_Raise_Date, Next_Raise_Date, Basic_Salary,
            Work_Career_Type_Id, Rank_Id, Initiation_Actual_Date
        ) OUTPUT inserted.Career_Emp_Id VALUES (
            @Emp_Id, @Emp_Name, @Employee_National_Num, @Directorate_Id, @Department_Id,
            @Section_Id, @Job_Title_Id, @Grade, @Step, @Position_Id, @Employment_Status,
            @Last_Promotion_Date, @Last_Raise_Date, @Next_Raise_Date, @Basic_Salary,
            @Work_Career_Type_Id, @Rank_Id, @Initiation_Actual_Date
        )
        """;

    public const string UpdateQuery = """
        UPDATE Career_Tbl SET
            Directorate_Id = @Directorate_Id,
            Department_Id = @Department_Id,
            Section_Id = @Section_Id,
            Job_Title_Id = @Job_Title_Id,
            Grade = @Grade,
            Step = @Step,
            Position_Id = @Position_Id,
            Employment_Status = @Employment_Status,
            Basic_Salary = @Basic_Salary,
            Work_Career_Type_Id = @Work_Career_Type_Id,
            Rank_Id = @Rank_Id
        WHERE Career_Emp_Id = @Career_Emp_Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Career_Tbl WHERE Career_Emp_Id = @Id
        """;
}
