using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class ServiceContinuationDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class ServiceContinuationForCreationDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
}

public class ServiceContinuationForUpdateDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
}
