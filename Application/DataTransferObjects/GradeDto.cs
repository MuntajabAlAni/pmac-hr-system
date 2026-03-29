using System.ComponentModel.DataAnnotations;
using Domain.Entities.EmploymentStructure.Enums;

namespace Application.DataTransferObjects;

public class GradeDto
{
    public Guid Id { get; set; }
    public string? GradeName { get; set; }
    public GradeLevel GradeLevel { get; set; }
}

public class GradeForCreationDto
{
    [Required(ErrorMessage = "Grade name is required")]
    [MaxLength(100)]
    public string GradeName { get; set; } = null!;

    [Required]
    public GradeLevel GradeLevel { get; set; }
}

public class GradeForUpdateDto
{
    [Required(ErrorMessage = "Grade name is required")]
    [MaxLength(100)]
    public string GradeName { get; set; } = null!;

    [Required]
    public GradeLevel GradeLevel { get; set; }
}
