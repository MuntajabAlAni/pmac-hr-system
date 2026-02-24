using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class RaiseDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public Guid RaiseTypeId { get; set; }
    public string? RaiseTypeName { get; set; }
    public string? OrderNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string? OldSalary { get; set; }
    public string? NewSalary { get; set; }
    public Guid? OldGradeId { get; set; }
    public string? OldGradeName { get; set; }
    public Guid? NewGradeId { get; set; }
    public string? NewGradeName { get; set; }
    public Guid? OldStepId { get; set; }
    public string? OldStepName { get; set; }
    public Guid? NewStepId { get; set; }
    public string? NewStepName { get; set; }
    public string? Notes { get; set; }
}

public class RaiseForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    [Required]
    public Guid RaiseTypeId { get; set; }
    public string? OrderNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string? OldSalary { get; set; }
    public string? NewSalary { get; set; }
    public Guid? OldGradeId { get; set; }
    public Guid? NewGradeId { get; set; }
    public Guid? OldStepId { get; set; }
    public Guid? NewStepId { get; set; }
    public string? Notes { get; set; }
    
    // Additional fields from original model that might be sent by client but ignored if not in DB
    public string? NewGradeString { get; set; }
    public string? NewStepString { get; set; }
    public string? NextGradeString { get; set; }
    public string? NextStepString { get; set; }
    public Guid? NewJobTitleId { get; set; }
    public string? NewJobTitleString { get; set; }
    public string? NextJobTitleString { get; set; }
    public DateTime? NextRaiseDate { get; set; }
    public string? AutoManual { get; set; }
    public string? NextRaisePromotion { get; set; }
    public string? CycledDays { get; set; }
    public string? FilePath { get; set; }
    public bool IsLastRP { get; set; }
    public bool IsRecord { get; set; }
    public bool IsSuspended { get; set; }
    public string? Education { get; set; }
}

public class RaiseForUpdateDto : RaiseForCreationDto
{
}
