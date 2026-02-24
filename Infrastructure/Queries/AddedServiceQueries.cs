namespace Infrastructure.Queries;

public class AddedServiceQueries
{
    public const string FindAllQuery = """
        SELECT 
            A.*,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeName,
            S.Name AS ServiceTypeName
        FROM Added_Service A
        LEFT JOIN Employee E ON A.EmployeeId = E.Emp_Id
        LEFT JOIN Service_Type S ON A.ServiceTypeId = S.Id
        ORDER BY A.OrderDate DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            A.*,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeName,
            S.Name AS ServiceTypeName
        FROM Added_Service A
        LEFT JOIN Employee E ON A.EmployeeId = E.Emp_Id
        LEFT JOIN Service_Type S ON A.ServiceTypeId = S.Id
        WHERE A.Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Added_Service (
            Id, EmployeeId, OrderNumber, BookNumber, OrderDate, OrderTypeId, 
            FromDate, ToDate, TotalDays, Years, Months, Days, AddedType, Notes, 
            IsRunning, FilePath, ServiceTypeId
        ) VALUES (
            @Id, @EmployeeId, @OrderNumber, @BookNumber, @OrderDate, @OrderTypeId, 
            @FromDate, @ToDate, @TotalDays, @Years, @Months, @Days, @AddedType, @Notes, 
            @IsRunning, @FilePath, @ServiceTypeId
        )
        """;

    public const string UpdateQuery = """
        UPDATE Added_Service SET 
            EmployeeId = @EmployeeId,
            OrderNumber = @OrderNumber,
            BookNumber = @BookNumber,
            OrderDate = @OrderDate,
            OrderTypeId = @OrderTypeId,
            FromDate = @FromDate,
            ToDate = @ToDate,
            TotalDays = @TotalDays,
            Years = @Years,
            Months = @Months,
            Days = @Days,
            AddedType = @AddedType,
            Notes = @Notes,
            IsRunning = @IsRunning,
            FilePath = @FilePath,
            ServiceTypeId = @ServiceTypeId
        WHERE Id = @Id
        """;

    public const string DeleteQuery = "DELETE FROM Added_Service WHERE Id = @Id";
}
