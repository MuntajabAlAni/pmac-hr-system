namespace Infrastructure.Queries;

public class EmployeeQueries
{
    public const string FindByIdQuery = """
        SELECT E.*, G.Gender_Name, MS.Marital_Status_Name
        FROM Employee E
        LEFT JOIN Gender G ON E.Gender_Id = G.Gender_Id
        LEFT JOIN Marital_Status MS ON E.Marital_Status = MS.Marital_Status_Id
        WHERE E.Emp_Id = @Id
        """;

    public const string FindAllQuery = """
        SELECT E.Emp_Id, E.Employee_F_Name, E.Employee_National_Num, E.Phone_No, E.Email,
               E.Gender_Id, G.Gender_Name, E.Birth_Date, E.Marital_Status, MS.Marital_Status_Name
        FROM Employee E
        LEFT JOIN Gender G ON E.Gender_Id = G.Gender_Id
        LEFT JOIN Marital_Status MS ON E.Marital_Status = MS.Marital_Status_Id
        WHERE E.IsDeleted = 0
        ORDER BY E.Employee_F_Name
        OFFSET @Skip ROWS FETCH NEXT @PageSize ROWS ONLY
        """;

    public const string CountQuery = """
        SELECT COUNT(*) FROM Employee WHERE IsDeleted = 0
        """;

    public const string SearchQuery = """
        SELECT E.Emp_Id, E.Employee_F_Name, E.Employee_National_Num, E.Phone_No, E.Email
        FROM Employee E
        WHERE E.IsDeleted = 0 AND (
            E.Employee_F_Name LIKE '%' + @SearchTerm + '%' OR
            E.Employee_National_Num LIKE '%' + @SearchTerm + '%' OR
            E.Phone_No LIKE '%' + @SearchTerm + '%'
        )
        ORDER BY E.Employee_F_Name
        OFFSET @Skip ROWS FETCH NEXT @PageSize ROWS ONLY
        """;

    public const string InsertQuery = """
        INSERT INTO Employee (
            Emp_Id, Employee_F_Name, Employee_First_Name, Employee_Second_Name,
            Employee_Third_Name, Employee_Forth_Name, Employee_Last_Name,
            Mother_Name, Gender_Id, Birth_Date, Phone_No, Email,
            Civil_Id_No, Nat_Card_No, Address, Marital_Status
        ) VALUES (
            @Id, @Employee_F_Name, @Employee_First_Name, @Employee_Second_Name,
            @Employee_Third_Name, @Employee_Forth_Name, @Employee_Last_Name,
            @Mother_Name, @Gender_Id, @Birth_Date, @Phone_No, @Email,
            @Civil_Id_No, @Nat_Card_No, @Address, @Marital_Status
        )
        """;

    public const string UpdateQuery = """
        UPDATE Employee SET
            Employee_F_Name = @Employee_F_Name,
            Employee_First_Name = @Employee_First_Name,
            Employee_Second_Name = @Employee_Second_Name,
            Employee_Third_Name = @Employee_Third_Name,
            Employee_Forth_Name = @Employee_Forth_Name,
            Employee_Last_Name = @Employee_Last_Name,
            Mother_Name = @Mother_Name,
            Gender_Id = @Gender_Id,
            Birth_Date = @Birth_Date,
            Phone_No = @Phone_No,
            Email = @Email,
            Address = @Address,
            Marital_Status = @Marital_Status
        WHERE Emp_Id = @Emp_Id
        """;

    public const string DeleteQuery = """
        UPDATE Employee SET IsDeleted = 1 WHERE Emp_Id = @Id
        """;
}
