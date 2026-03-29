using System.ComponentModel.DataAnnotations;
using Domain.Entities.EmploymentStructure.Enums;

namespace Application.DataTransferObjects;

public class JobTitleDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public Guid GradeId { get; set; }
    public string? GradeName { get; set; }
    public JobTitleType JobTitleType { get; set; }
}

public class JobTitleForCreationDto
{
    [Required(ErrorMessage = "Job title is required")]
    [MaxLength(200)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Grade ID is required")]
    public Guid GradeId { get; set; }

    [Required]
    public JobTitleType JobTitleType { get; set; }
}

public class JobTitleForUpdateDto
{
    [Required(ErrorMessage = "Job title is required")]
    [MaxLength(200)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Grade ID is required")]
    public Guid GradeId { get; set; }

    [Required]
    public JobTitleType JobTitleType { get; set; }
}
