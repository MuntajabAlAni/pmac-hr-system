using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class JobTitleDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
}

public class JobTitleForCreationDto
{
    [Required(ErrorMessage = "Job title is required")]
    [MaxLength(200)]
    public string? Title { get; set; }
}

public class JobTitleForUpdateDto
{
    [Required(ErrorMessage = "Job title is required")]
    [MaxLength(200)]
    public string? Title { get; set; }
}
