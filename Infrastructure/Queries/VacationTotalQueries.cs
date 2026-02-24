namespace Infrastructure.Queries;

public class VacationTotalQueries
{
    public const string FindAllQuery = """
        SELECT 
            VT.Id,
            VT.EmployeeId,
            VT.OrdinaryVacationTotal,
            VT.IllnessVacationTotal,
            VT.OrdinaryFinalTotal,
            VT.IllnessFinalTotal,
            E.Employee_F_Name AS EmployeeName
        FROM Vacation_Total VT
        LEFT JOIN Employee E ON VT.EmployeeId = E.Emp_Id
        ORDER BY E.Employee_F_Name
        """;

    public const string FindByIdQuery = """
        SELECT 
            VT.Id,
            VT.EmployeeId,
            VT.OrdinaryVacationTotal,
            VT.IllnessVacationTotal,
            VT.OrdinaryFinalTotal,
            VT.IllnessFinalTotal,
            E.Employee_F_Name AS EmployeeName
        FROM Vacation_Total VT
        LEFT JOIN Employee E ON VT.EmployeeId = E.Emp_Id
        WHERE VT.Id = @Id
        """;

    public const string FindByEmployeeIdQuery = """
        SELECT 
            VT.Id,
            VT.EmployeeId,
            VT.OrdinaryVacationTotal,
            VT.IllnessVacationTotal,
            VT.OrdinaryFinalTotal,
            VT.IllnessFinalTotal,
            E.Employee_F_Name AS EmployeeName
        FROM Vacation_Total VT
        LEFT JOIN Employee E ON VT.EmployeeId = E.Emp_Id
        WHERE VT.EmployeeId = @EmployeeId
        """;

    public const string InsertQuery = """
        INSERT INTO Vacation_Total (
            Id, EmployeeId, OrdinaryVacationTotal, IllnessVacationTotal, 
            OrdinaryFinalTotal, IllnessFinalTotal
        )
        VALUES (
            @Id, @EmployeeId, @OrdinaryVacationTotal, @IllnessVacationTotal, 
            @OrdinaryFinalTotal, @IllnessFinalTotal
        )
        """;

    public const string UpdateQuery = """
        UPDATE Vacation_Total SET
            EmployeeId = @EmployeeId,
            OrdinaryVacationTotal = @OrdinaryVacationTotal,
            IllnessVacationTotal = @IllnessVacationTotal,
            OrdinaryFinalTotal = @OrdinaryFinalTotal,
            IllnessFinalTotal = @IllnessFinalTotal
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Vacation_Total WHERE Id = @Id
        """;
}
