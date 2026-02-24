using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class TrainingCourseDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeFullName { get; set; }
    public string? OrderNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public string? CourseName { get; set; }
    public string? Sponsor { get; set; }
    public string? CourseEvaluator { get; set; }
    public string? NumberOfDays { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? DetachmentDate { get; set; }
    public DateTime? InitiationDate { get; set; }
    public string? Evaluation { get; set; }
    public string? CourseNotes { get; set; }
    public string? FilePath { get; set; }
}

public class TrainingCourseForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; } // Often redundant if we have Id, but keeping for compatibility
    public string? OrderNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    [Required]
    public string? CourseName { get; set; }
    public string? Sponsor { get; set; }
    public string? CourseEvaluator { get; set; }
    public string? NumberOfDays { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? DetachmentDate { get; set; }
    public DateTime? InitiationDate { get; set; }
    public string? Evaluation { get; set; }
    public string? CourseNotes { get; set; }
    public string? FilePath { get; set; }
}

public class TrainingCourseForUpdateDto : TrainingCourseForCreationDto
{
}
