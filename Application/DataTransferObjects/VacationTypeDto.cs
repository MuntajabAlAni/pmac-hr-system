using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class VacationTypeDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool IsConditional { get; set; }
    public bool IsCountedInBalance { get; set; }
    public bool BonusAffect { get; set; }
    public bool PromotionAffect { get; set; }
}

public class VacationTypeForCreationDto
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    public bool IsConditional { get; set; }
    public bool IsCountedInBalance { get; set; }
    public bool BonusAffect { get; set; }
    public bool PromotionAffect { get; set; }
}

public class VacationTypeForUpdateDto
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    public bool IsConditional { get; set; }
    public bool IsCountedInBalance { get; set; }
    public bool BonusAffect { get; set; }
    public bool PromotionAffect { get; set; }
}
