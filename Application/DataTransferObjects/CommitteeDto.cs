using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class CommitteeDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public string? CommitteeType { get; set; }
    public string? CommitteeOrderNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public string? CommitteeDurationType { get; set; }
    public string? NumberOfDays { get; set; }
    public string? CommitteeNotes { get; set; }
    public string? FilePath { get; set; }
}

public class CommitteeForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    [Required]
    public string? CommitteeType { get; set; }
    [Required]
    public string? CommitteeOrderNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public string? CommitteeDurationType { get; set; }
    public string? NumberOfDays { get; set; }
    public string? CommitteeNotes { get; set; }
    public string? FilePath { get; set; }
}

public class CommitteeForUpdateDto : CommitteeForCreationDto
{
}
