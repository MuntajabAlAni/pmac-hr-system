using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class StepDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class StepForCreationDto
{
    [Required(ErrorMessage = "Step name is required")]
    [MaxLength(100)]
    public string? Name { get; set; }
}

public class StepForUpdateDto
{
    [Required(ErrorMessage = "Step name is required")]
    [MaxLength(100)]
    public string? Name { get; set; }
}
