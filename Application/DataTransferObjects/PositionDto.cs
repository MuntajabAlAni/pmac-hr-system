using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class PositionDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
}

public class PositionForCreationDto
{
    [Required(ErrorMessage = "Position title is required")]
    [MaxLength(200)]
    public string? Title { get; set; }
}

public class PositionForUpdateDto
{
    [Required(ErrorMessage = "Position title is required")]
    [MaxLength(200)]
    public string? Title { get; set; }
}
