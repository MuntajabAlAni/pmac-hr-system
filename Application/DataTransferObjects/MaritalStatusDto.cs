using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class MaritalStatusDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class MaritalStatusForCreationDto
{
    [Required]
    public string? Name { get; set; }
}

public class MaritalStatusForUpdateDto : MaritalStatusForCreationDto
{
}
