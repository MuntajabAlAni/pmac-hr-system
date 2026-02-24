namespace Infrastructure.Queries;

public class RewardQueries
{
    public const string FindAllQuery = """
        SELECT 
            R.Id,
            R.EmployeeId,
            R.RewardGiver,
            R.RewardAmount,
            R.RewardReason,
            R.OrderType,
            R.OrderNumber,
            R.OrderDate,
            R.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeName
        FROM Reward R
        LEFT JOIN Employee E ON R.EmployeeId = E.Emp_Id
        ORDER BY R.OrderDate DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            R.Id,
            R.EmployeeId,
            R.RewardGiver,
            R.RewardAmount,
            R.RewardReason,
            R.OrderType,
            R.OrderNumber,
            R.OrderDate,
            R.FilePath,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeName
        FROM Reward R
        LEFT JOIN Employee E ON R.EmployeeId = E.Emp_Id
        WHERE R.Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Reward (
            Id, EmployeeId, RewardGiver, RewardAmount, RewardReason,
            OrderType, OrderNumber, OrderDate, FilePath
        )
        VALUES (
            @Id, @EmployeeId, @RewardGiver, @RewardAmount, @RewardReason,
            @OrderType, @OrderNumber, @OrderDate, @FilePath
        )
        """;

    public const string UpdateQuery = """
        UPDATE Reward SET
            EmployeeId = @EmployeeId,
            RewardGiver = @RewardGiver,
            RewardAmount = @RewardAmount,
            RewardReason = @RewardReason,
            OrderType = @OrderType,
            OrderNumber = @OrderNumber,
            OrderDate = @OrderDate,
            FilePath = @FilePath
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Reward WHERE Id = @Id
        """;
}
