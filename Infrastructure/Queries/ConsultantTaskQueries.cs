namespace Infrastructure.Queries;

public class ConsultantTaskQueries
{
    public const string FindAllQuery = """
        SELECT 
            C.*,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeName,
            TD.Name AS TaskDescriptionName,
            WN.Name AS WorkNatureName,
            TS.Name AS TaskStatusName,
            PD.Name AS ProcedureDescriptionName
        FROM Consultant_Task C
        LEFT JOIN Employee E ON C.EmployeeId = E.Emp_Id
        LEFT JOIN Task_Description TD ON C.TaskDescriptionId = TD.Id
        LEFT JOIN Work_Nature WN ON C.WorkNatureId = WN.Id
        LEFT JOIN Task_Status TS ON C.TaskStatusId = TS.Id
        LEFT JOIN Procedure_Description PD ON C.ProcedureDescriptionId = PD.Id
        ORDER BY C.TaskDate DESC
        """;

    public const string FindByIdQuery = """
        SELECT 
            C.*,
            E.Employee_F_Name + ' ' + E.Employee_L_Name AS EmployeeName,
            TD.Name AS TaskDescriptionName,
            WN.Name AS WorkNatureName,
            TS.Name AS TaskStatusName,
            PD.Name AS ProcedureDescriptionName
        FROM Consultant_Task C
        LEFT JOIN Employee E ON C.EmployeeId = E.Emp_Id
        LEFT JOIN Task_Description TD ON C.TaskDescriptionId = TD.Id
        LEFT JOIN Work_Nature WN ON C.WorkNatureId = WN.Id
        LEFT JOIN Task_Status TS ON C.TaskStatusId = TS.Id
        LEFT JOIN Procedure_Description PD ON C.ProcedureDescriptionId = PD.Id
        WHERE C.Id = @Id
        """;

    public const string InsertQuery = """
        INSERT INTO Consultant_Task (
            Id, EmployeeId, Subject, TaskDescriptionId, TaskDate, WorkNatureId, 
            TaskStatusId, ProcedureDescriptionId, ProgressDescription, 
            TaskRecommendations, TaskNotes, FilePath
        ) VALUES (
            @Id, @EmployeeId, @Subject, @TaskDescriptionId, @TaskDate, @WorkNatureId, 
            @TaskStatusId, @ProcedureDescriptionId, @ProgressDescription, 
            @TaskRecommendations, @TaskNotes, @FilePath
        )
        """;

    public const string UpdateQuery = """
        UPDATE Consultant_Task SET 
            EmployeeId = @EmployeeId,
            Subject = @Subject,
            TaskDescriptionId = @TaskDescriptionId,
            TaskDate = @TaskDate,
            WorkNatureId = @WorkNatureId,
            TaskStatusId = @TaskStatusId,
            ProcedureDescriptionId = @ProcedureDescriptionId,
            ProgressDescription = @ProgressDescription,
            TaskRecommendations = @TaskRecommendations,
            TaskNotes = @TaskNotes,
            FilePath = @FilePath
        WHERE Id = @Id
        """;

    public const string DeleteQuery = "DELETE FROM Consultant_Task WHERE Id = @Id";
}
