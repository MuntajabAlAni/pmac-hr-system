using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class WorkCareerTypeDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class WorkCareerTypeForCreationDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
}

public class WorkCareerTypeForUpdateDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
}
