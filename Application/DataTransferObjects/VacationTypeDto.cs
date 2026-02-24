using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class VacationTypeDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool? IsCondition { get; set; }
    public bool? Rsed { get; set; }
    public bool? RaiseAffected { get; set; }
}

public class VacationTypeForCreationDto
{
    [Required]
    public string? Name { get; set; }
    public bool? IsCondition { get; set; }
    public bool? Rsed { get; set; }
    public bool? RaiseAffected { get; set; }
}

public class VacationTypeForUpdateDto
{
    [Required]
    public string? Name { get; set; }
    public bool? IsCondition { get; set; }
    public bool? Rsed { get; set; }
    public bool? RaiseAffected { get; set; }
}
