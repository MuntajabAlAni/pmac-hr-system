using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class DepartmentDto
{
    public Guid Id { get; set; }
    public Guid DirectorateId { get; set; }
    public string? DirectorateName { get; set; }
    public string? Name { get; set; }
    public int Exception { get; set; }
    public int Hidden { get; set; }
}

public class DepartmentForCreationDto
{
    [Required(ErrorMessage = "Directorate ID is required")]
    public Guid DirectorateId { get; set; }

    [Required(ErrorMessage = "Department name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
    public int Exception { get; set; } = 0;
}

public class DepartmentForUpdateDto
{
    [Required(ErrorMessage = "Directorate ID is required")]
    public Guid DirectorateId { get; set; }

    [Required(ErrorMessage = "Department name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
    public int Exception { get; set; }
}
