using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class VacationDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public Guid VacationTypeId { get; set; }
    public string? VacationTypeName { get; set; }
    public string? OrderIssueNumber { get; set; }
    public DateTime? OrderIssueDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int NumberOfDays { get; set; }
    public int NumberOfMonths { get; set; }
    public int NumberOfYears { get; set; }
    public int NumberOfDays2 { get; set; }
    public int NumberOfMonths2 { get; set; }
    public int NumberOfYears2 { get; set; }
    public string? VacationNotes { get; set; }
    public string? VacationDirectOrderNumber { get; set; }
    public string? BookNumber { get; set; }
    public string? ProceedingBookNumber { get; set; }
    public DateTime? ProceedingBookDate { get; set; }
    public int Running { get; set; }
    public string? FilePath { get; set; }
    public string? UserName { get; set; }
    public DateTime? EntryDate { get; set; }
}

public class VacationForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    [Required]
    public Guid VacationTypeId { get; set; }
    public string? OrderIssueNumber { get; set; }
    public DateTime? OrderIssueDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int NumberOfDays { get; set; }
    public int NumberOfMonths { get; set; }
    public int NumberOfYears { get; set; }
    public int NumberOfDays2 { get; set; }
    public int NumberOfMonths2 { get; set; }
    public int NumberOfYears2 { get; set; }
    public string? VacationNotes { get; set; }
    public string? VacationDirectOrderNumber { get; set; }
    public string? BookNumber { get; set; }
    public string? ProceedingBookNumber { get; set; }
    public DateTime? ProceedingBookDate { get; set; }
    public int Running { get; set; }
    public string? FilePath { get; set; }
    public string? UserName { get; set; }
}

public class VacationForUpdateDto : VacationForCreationDto
{
}
