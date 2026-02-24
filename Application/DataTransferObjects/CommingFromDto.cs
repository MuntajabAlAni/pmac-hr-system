using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class CommingFromDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class CommingFromForCreationDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
}

public class CommingFromForUpdateDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
}
