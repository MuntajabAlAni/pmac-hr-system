using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class RaiseTypeDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class RaiseTypeForCreationDto
{
    [Required]
    public string? Name { get; set; }
}

public class RaiseTypeForUpdateDto
{
    [Required]
    public string? Name { get; set; }
}
