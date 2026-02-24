using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class RankDto
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
}

public class RankForCreationDto
{
    [Required(ErrorMessage = "Rank description is required")]
    [MaxLength(200)]
    public string? Description { get; set; }
}

public class RankForUpdateDto
{
    [Required(ErrorMessage = "Rank description is required")]
    [MaxLength(200)]
    public string? Description { get; set; }
}
