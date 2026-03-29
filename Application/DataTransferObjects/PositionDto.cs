using System.ComponentModel.DataAnnotations;
using Domain.Entities.EmploymentStructure.Enums;

namespace Application.DataTransferObjects;

public class PositionDto
{
    public Guid Id { get; set; }
    public string? PositionName { get; set; }
    public PositionLevel PositionLevel { get; set; }
}

public class PositionForCreationDto
{
    [Required(ErrorMessage = "Position name is required")]
    [MaxLength(200)]
    public string PositionName { get; set; } = null!;

    [Required]
    public PositionLevel PositionLevel { get; set; }
}

public class PositionForUpdateDto
{
    [Required(ErrorMessage = "Position name is required")]
    [MaxLength(200)]
    public string PositionName { get; set; } = null!;

    [Required]
    public PositionLevel PositionLevel { get; set; }
}
