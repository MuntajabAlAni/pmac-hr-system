using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class DirectorateDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Exception { get; set; }
}

public class DirectorateForCreationDto
{
    [Required(ErrorMessage = "Directorate name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
    public int Exception { get; set; } = 0;
}

public class DirectorateForUpdateDto
{
    [Required(ErrorMessage = "Directorate name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
    public int Exception { get; set; }
}
