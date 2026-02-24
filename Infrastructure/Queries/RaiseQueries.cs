namespace Infrastructure.Queries;

public class RaiseQueries
{
    public const string FindAllQuery = """
        SELECT 
            R.Id, R.EmployeeId, R.RaiseTypeId, R.OrderNumber, R.OrderDate, 
            R.EffectiveDate, R.OldSalary, R.NewSalary, R.OldGradeId, R.NewGradeId, 
            R.OldStepId, R.NewStepId, R.Notes,
            E.Employee_First_Name + ' ' + E.Employee_Last_Name AS EmployeeName,
            RT.Name AS RaiseTypeName,
            OG.Grade_Name AS OldGradeName,
            NG.Grade_Name AS NewGradeName,
            OS.Step_Name AS OldStepName,
            NS.Step_Name AS NewStepName
        FROM Raise R
        LEFT JOIN Employee E ON R.EmployeeId = E.Emp_Id
        LEFT JOIN Raise_Type RT ON R.RaiseTypeId = RT.Id
        LEFT JOIN Grade OG ON R.OldGradeId = OG.Grade_Id
        LEFT JOIN Grade NG ON R.NewGradeId = NG.Grade_Id
        LEFT JOIN Step OS ON R.OldStepId = OS.Step_Id
        LEFT JOIN Step NS ON R.NewStepId = NS.Step_Id
        ORDER BY R.EffectiveDate DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            R.Id, R.EmployeeId, R.RaiseTypeId, R.OrderNumber, R.OrderDate, 
            R.EffectiveDate, R.OldSalary, R.NewSalary, R.OldGradeId, R.NewGradeId, 
            R.OldStepId, R.NewStepId, R.Notes
        FROM Raise R
        WHERE R.Id = @Id
        """;

    public const string FindByEmployeeIdQuery = """
        SELECT 
            R.Id, R.EmployeeId, R.RaiseTypeId, R.OrderNumber, R.OrderDate, 
            R.EffectiveDate, R.OldSalary, R.NewSalary, R.OldGradeId, R.NewGradeId, 
            R.OldStepId, R.NewStepId, R.Notes,
            RT.Name AS RaiseTypeName,
            OG.Grade_Name AS OldGradeName,
            NG.Grade_Name AS NewGradeName,
            OS.Step_Name AS OldStepName,
            NS.Step_Name AS NewStepName
        FROM Raise R
        LEFT JOIN Raise_Type RT ON R.RaiseTypeId = RT.Id
        LEFT JOIN Grade OG ON R.OldGradeId = OG.Grade_Id
        LEFT JOIN Grade NG ON R.NewGradeId = NG.Grade_Id
        LEFT JOIN Step OS ON R.OldStepId = OS.Step_Id
        LEFT JOIN Step NS ON R.NewStepId = NS.Step_Id
        WHERE R.EmployeeId = @EmployeeId
        ORDER BY R.EffectiveDate DESC
        """;

    public const string InsertQuery = """
        INSERT INTO Raise (
            Id, EmployeeId, RaiseTypeId, OrderNumber, OrderDate, EffectiveDate, 
            OldSalary, NewSalary, OldGradeId, NewGradeId, OldStepId, NewStepId, Notes
        )
        VALUES (
            @Id, @EmployeeId, @RaiseTypeId, @OrderNumber, @OrderDate, @EffectiveDate, 
            @OldSalary, @NewSalary, @OldGradeId, @NewGradeId, @OldStepId, @NewStepId, @Notes
        )
        """;

    public const string UpdateQuery = """
        UPDATE Raise SET
            EmployeeId = @EmployeeId,
            RaiseTypeId = @RaiseTypeId,
            OrderNumber = @OrderNumber,
            OrderDate = @OrderDate,
            EffectiveDate = @EffectiveDate,
            OldSalary = @OldSalary,
            NewSalary = @NewSalary,
            OldGradeId = @OldGradeId,
            NewGradeId = @NewGradeId,
            OldStepId = @OldStepId,
            NewStepId = @NewStepId,
            Notes = @Notes
        WHERE Id = @Id
        """;

    public const string DeleteQuery = """
        DELETE FROM Raise WHERE Id = @Id
        """;
}
