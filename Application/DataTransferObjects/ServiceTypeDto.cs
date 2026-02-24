using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class ServiceTypeDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class ServiceTypeForCreationDto
{
    [Required]
    public string? Name { get; set; }
}

public class ServiceTypeForUpdateDto : ServiceTypeForCreationDto
{
}
