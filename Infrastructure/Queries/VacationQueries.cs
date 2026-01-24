namespace Infrastructure.Queries;

public class VacationQueries
{
    public const string FindAllQuery = """
        SELECT V.*, VT.Vacation_Type_Name, E.Employee_F_Name
        FROM Vacation_Tbl V
        LEFT JOIN Vacation_Type_Tbl VT ON V.Vacation_Type_Id = VT.Vacation_Type_Id
        LEFT JOIN Employee_Tbl E ON V.Emp_Id = E.Emp_Id
        ORDER BY V.Start_Date DESC
        OFFSET @Skip ROWS FETCH NEXT @PageSize ROWS ONLY
        """;

    public const string FindByEmployeeIdQuery = """
        SELECT V.*, VT.Vacation_Type_Name
        FROM Vacation_Tbl V
        LEFT JOIN Vacation_Type_Tbl VT ON V.Vacation_Type_Id = VT.Vacation_Type_Id
        WHERE V.Emp_Id = @EmployeeId
        ORDER BY V.Start_Date DESC
        """;

    public const string FindByIdQuery = """
        SELECT V.*, VT.Vacation_Type_Name, E.Employee_F_Name
        FROM Vacation_Tbl V
        LEFT JOIN Vacation_Type_Tbl VT ON V.Vacation_Type_Id = VT.Vacation_Type_Id
        LEFT JOIN Employee_Tbl E ON V.Emp_Id = E.Emp_Id
        WHERE V.Vacation_Id = @Id
        """;

    public const string CountQuery = """
        SELECT COUNT(*) FROM Vacation_Tbl
        """;

    public const string InsertQuery = """
        INSERT INTO Vacation_Tbl (
            Emp_Id, Emp_Name, Vacation_Type_Id, Start_Date, End_Date,
            No_Of_Days, No_Of_Months, No_Of_Years,
            Order_Issue_No, Order_Issue_Date, Vac_Notes, UserName, EntryDate
        ) OUTPUT inserted.Vacation_Id VALUES (
            @Emp_Id, @Emp_Name, @Vacation_Type_Id, @Start_Date, @End_Date,
            @No_Of_Days, @No_Of_Months, @No_Of_Years,
            @Order_Issue_No, @Order_Issue_Date, @Vac_Notes, @UserName, GETDATE()
        )
        """;

    public const string UpdateQuery = """
        UPDATE Vacation_Tbl SET
            Vacation_Type_Id = @Vacation_Type_Id,
            Start_Date = @Start_Date,
            End_Date = @End_Date,
            No_Of_Days = @No_Of_Days,
            No_Of_Months = @No_Of_Months,
            No_Of_Years = @No_Of_Years,
            Order_Issue_No = @Order_Issue_No,
            Order_Issue_Date = @Order_Issue_Date,
            Vac_Notes = @Vac_Notes
        WHERE Vacation_Id = @Vacation_Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Vacation_Tbl WHERE Vacation_Id = @Id
        """;
}
