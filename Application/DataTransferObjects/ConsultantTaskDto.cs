using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class ConsultantTaskDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public string? Subject { get; set; }
    public Guid? TaskDescriptionId { get; set; }
    public string? TaskDescriptionName { get; set; }
    public DateTime? TaskDate { get; set; }
    public Guid? WorkNatureId { get; set; }
    public string? WorkNatureName { get; set; }
    public Guid? TaskStatusId { get; set; }
    public string? TaskStatusName { get; set; }
    public Guid? ProcedureDescriptionId { get; set; }
    public string? ProcedureDescriptionName { get; set; }
    public string? ProgressDescription { get; set; }
    public string? TaskRecommendations { get; set; }
    public string? TaskNotes { get; set; }
    public string? FilePath { get; set; }
}

public class ConsultantTaskForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    public string? Subject { get; set; }
    public Guid? TaskDescriptionId { get; set; }
    public DateTime? TaskDate { get; set; }
    public Guid? WorkNatureId { get; set; }
    public Guid? TaskStatusId { get; set; }
    public Guid? ProcedureDescriptionId { get; set; }
    public string? ProgressDescription { get; set; }
    public string? TaskRecommendations { get; set; }
    public string? TaskNotes { get; set; }
    public string? FilePath { get; set; }
}

public class ConsultantTaskForUpdateDto : ConsultantTaskForCreationDto
{
}
