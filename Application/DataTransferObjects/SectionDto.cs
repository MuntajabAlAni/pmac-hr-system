using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class SectionDto
{
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public Guid DirectorateId { get; set; }
    public string? Name { get; set; }
}

public class SectionForCreationDto
{
    [Required(ErrorMessage = "Department ID is required")]
    public Guid DepartmentId { get; set; }

    [Required(ErrorMessage = "Section name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
}

public class SectionForUpdateDto
{
    [Required(ErrorMessage = "Department ID is required")]
    public Guid DepartmentId { get; set; }

    [Required(ErrorMessage = "Section name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
}
