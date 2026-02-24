namespace Infrastructure.Queries;

public class VacationQueries
{
    public const string FindAllQuery = """
        SELECT 
            V.Vacation_Id AS Id,
            V.Emp_Id AS EmployeeId,
            V.Vacation_Type_Id AS VacationTypeId,
            V.Order_Issue_No AS OrderIssueNumber,
            V.Order_Issue_Date AS OrderIssueDate,
            V.Start_Date AS StartDate,
            V.End_Date AS EndDate,
            V.No_Of_Days AS NumberOfDays,
            V.No_Of_Months AS NumberOfMonths,
            V.No_Of_Years AS NumberOfYears,
            V.No_Of_Days2 AS NumberOfDays2,
            V.No_Of_Months2 AS NumberOfMonths2,
            V.No_Of_Years2 AS NumberOfYears2,
            V.Vac_Notes AS VacationNotes,
            V.Vacation_Direct_Order_Number AS VacationDirectOrderNumber,
            V.Book_Number AS BookNumber,
            V.Proceeding_Book_Number AS ProceedingBookNumber,
            V.Proceeding_Book_Date AS ProceedingBookDate,
            V.Running,
            V.File_Path AS FilePath,
            V.UserName,
            V.EntryDate,
            E.Employee_First_Name + ' ' + E.Employee_Last_Name AS EmployeeName,
            VT.Vacation_Type_Name AS VacationTypeName
        FROM Vacation V
        LEFT JOIN Employee E ON V.Emp_Id = E.Emp_Id
        LEFT JOIN Vacation_Type VT ON V.Vacation_Type_Id = VT.Vacation_Type_Id
        ORDER BY V.Start_Date DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            V.Vacation_Id AS Id,
            V.Emp_Id AS EmployeeId,
            V.Vacation_Type_Id AS VacationTypeId,
            V.Order_Issue_No AS OrderIssueNumber,
            V.Order_Issue_Date AS OrderIssueDate,
            V.Start_Date AS StartDate,
            V.End_Date AS EndDate,
            V.No_Of_Days AS NumberOfDays,
            V.No_Of_Months AS NumberOfMonths,
            V.No_Of_Years AS NumberOfYears,
            V.No_Of_Days2 AS NumberOfDays2,
            V.No_Of_Months2 AS NumberOfMonths2,
            V.No_Of_Years2 AS NumberOfYears2,
            V.Vac_Notes AS VacationNotes,
            V.Vacation_Direct_Order_Number AS VacationDirectOrderNumber,
            V.Book_Number AS BookNumber,
            V.Proceeding_Book_Number AS ProceedingBookNumber,
            V.Proceeding_Book_Date AS ProceedingBookDate,
            V.Running,
            V.File_Path AS FilePath,
            V.UserName,
            V.EntryDate
        FROM Vacation V
        WHERE V.Vacation_Id = @Id
        """;

    public const string FindByEmployeeIdQuery = """
        SELECT 
            V.Vacation_Id AS Id,
            V.Emp_Id AS EmployeeId,
            V.Vacation_Type_Id AS VacationTypeId,
            V.Order_Issue_No AS OrderIssueNumber,
            V.Order_Issue_Date AS OrderIssueDate,
            V.Start_Date AS StartDate,
            V.End_Date AS EndDate,
            V.No_Of_Days AS NumberOfDays,
            V.No_Of_Months AS NumberOfMonths,
            V.No_Of_Years AS NumberOfYears,
            V.No_Of_Days2 AS NumberOfDays2,
            V.No_Of_Months2 AS NumberOfMonths2,
            V.No_Of_Years2 AS NumberOfYears2,
            V.Vac_Notes AS VacationNotes,
            V.Vacation_Direct_Order_Number AS VacationDirectOrderNumber,
            V.Book_Number AS BookNumber,
            V.Proceeding_Book_Number AS ProceedingBookNumber,
            V.Proceeding_Book_Date AS ProceedingBookDate,
            V.Running,
            V.File_Path AS FilePath,
            V.UserName,
            V.EntryDate,
            VT.Vacation_Type_Name AS VacationTypeName
        FROM Vacation V
        LEFT JOIN Vacation_Type VT ON V.Vacation_Type_Id = VT.Vacation_Type_Id
        WHERE V.Emp_Id = @EmployeeId
        ORDER BY V.Start_Date DESC
        """;

    public const string InsertQuery = """
        INSERT INTO Vacation (
            Vacation_Id, Emp_Id, Vacation_Type_Id, Order_Issue_No, Order_Issue_Date,
            Start_Date, End_Date, No_Of_Days, No_Of_Months, No_Of_Years,
            No_Of_Days2, No_Of_Months2, No_Of_Years2, Vac_Notes,
            Vacation_Direct_Order_Number, Book_Number, Proceeding_Book_Number, Proceeding_Book_Date,
            Running, File_Path, UserName, EntryDate
        )
        VALUES (
            @Id, @EmployeeId, @VacationTypeId, @OrderIssueNumber, @OrderIssueDate,
            @StartDate, @EndDate, @NumberOfDays, @NumberOfMonths, @NumberOfYears,
            @NumberOfDays2, @NumberOfMonths2, @NumberOfYears2, @VacationNotes,
            @VacationDirectOrderNumber, @BookNumber, @ProceedingBookNumber, @ProceedingBookDate,
            @Running, @FilePath, @UserName, @EntryDate
        )
        """;

    public const string UpdateQuery = """
        UPDATE Vacation SET
            Emp_Id = @EmployeeId,
            Vacation_Type_Id = @VacationTypeId,
            Order_Issue_No = @OrderIssueNumber,
            Order_Issue_Date = @OrderIssueDate,
            Start_Date = @StartDate,
            End_Date = @EndDate,
            No_Of_Days = @NumberOfDays,
            No_Of_Months = @NumberOfMonths,
            No_Of_Years = @NumberOfYears,
            No_Of_Days2 = @NumberOfDays2,
            No_Of_Months2 = @NumberOfMonths2,
            No_Of_Years2 = @NumberOfYears2,
            Vac_Notes = @VacationNotes,
            Vacation_Direct_Order_Number = @VacationDirectOrderNumber,
            Book_Number = @BookNumber,
            Proceeding_Book_Number = @ProceedingBookNumber,
            Proceeding_Book_Date = @ProceedingBookDate,
            Running = @Running,
            File_Path = @FilePath
        WHERE Vacation_Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Vacation WHERE Vacation_Id = @Id
        """;
}
