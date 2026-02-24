using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class AdministrativeActionTypeDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int ImpactInDays { get; set; }
    public bool IsPenalty { get; set; }
    public bool RaiseAffected { get; set; }
}

public class AdministrativeActionTypeForCreationDto
{
    [Required]
    public string? Name { get; set; }
    public int ImpactInDays { get; set; }
    public bool IsPenalty { get; set; }
    public bool RaiseAffected { get; set; }
}

public class AdministrativeActionTypeForUpdateDto : AdministrativeActionTypeForCreationDto
{
}
