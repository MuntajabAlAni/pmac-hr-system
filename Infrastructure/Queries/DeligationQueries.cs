namespace Infrastructure.Queries;

public class DeligationQueries
{
    public const string FindAllQuery = """
        SELECT 
            D.Id,
            D.EmployeeId,
            D.EmployeeName,
            D.Destination,
            D.Sponsor,
            D.Subject,
            D.Title,
            D.Evaluator,
            D.ActualDays,
            D.TravelDays,
            D.TravelDate,
            D.OrderNumber,
            D.OrderDate,
            D.InitiationDate,
            D.Notes,
            D.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName
        FROM Deligation D
        LEFT JOIN Employee E ON D.EmployeeId = E.Emp_Id
        ORDER BY D.OrderDate DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            D.Id,
            D.EmployeeId,
            D.EmployeeName,
            D.Destination,
            D.Sponsor,
            D.Subject,
            D.Title,
            D.Evaluator,
            D.ActualDays,
            D.TravelDays,
            D.TravelDate,
            D.OrderNumber,
            D.OrderDate,
            D.InitiationDate,
            D.Notes,
            D.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeFullName
        FROM Deligation D
        LEFT JOIN Employee E ON D.EmployeeId = E.Emp_Id
        WHERE D.Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Deligation (
            Id, EmployeeId, EmployeeName, Destination, Sponsor, Subject, Title, Evaluator,
            ActualDays, TravelDays, TravelDate, OrderNumber, OrderDate, InitiationDate,
            Notes, FilePath
        )
        VALUES (
            @Id, @EmployeeId, @EmployeeName, @Destination, @Sponsor, @Subject, @Title, @Evaluator,
            @ActualDays, @TravelDays, @TravelDate, @OrderNumber, @OrderDate, @InitiationDate,
            @Notes, @FilePath
        )
        """;

    public const string UpdateQuery = """
        UPDATE Deligation SET
            EmployeeId = @EmployeeId,
            EmployeeName = @EmployeeName,
            Destination = @Destination,
            Sponsor = @Sponsor,
            Subject = @Subject,
            Title = @Title,
            Evaluator = @Evaluator,
            ActualDays = @ActualDays,
            TravelDays = @TravelDays,
            TravelDate = @TravelDate,
            OrderNumber = @OrderNumber,
            OrderDate = @OrderDate,
            InitiationDate = @InitiationDate,
            Notes = @Notes,
            FilePath = @FilePath
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Deligation WHERE Id = @Id
        """;
}
