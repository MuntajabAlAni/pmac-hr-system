using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class GradeDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class GradeForCreationDto
{
    [Required(ErrorMessage = "Grade name is required")]
    [MaxLength(100)]
    public string? Name { get; set; }
}

public class GradeForUpdateDto
{
    [Required(ErrorMessage = "Grade name is required")]
    [MaxLength(100)]
    public string? Name { get; set; }
}
