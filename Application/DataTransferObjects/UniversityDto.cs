using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class UniversityDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class UniversityForCreationDto
{
    [Required]
    public string? Name { get; set; }
}

public class UniversityForUpdateDto
{
    [Required]
    public string? Name { get; set; }
}
