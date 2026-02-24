using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class CareerDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public string? EmployeeNationalNumber { get; set; }
    public Guid? DirectorateId { get; set; }
    public string? DirectorateName { get; set; }
    public Guid? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public Guid? SectionId { get; set; }
    public string? SectionName { get; set; }
    public Guid? JobTitleId { get; set; }
    public string? JobTitleName { get; set; }
    public Guid? PositionId { get; set; }
    public string? PositionName { get; set; }
    public Guid? RankId { get; set; }
    public string? RankName { get; set; }
    public Guid? GradeId { get; set; }
    public string? GradeName { get; set; }
    public Guid? StepId { get; set; }
    public string? StepName { get; set; }
    public Guid? ContinuationId { get; set; }
    public string? ContinuationName { get; set; }
    public Guid? WorkCareerTypeId { get; set; }
    public string? WorkCareerTypeName { get; set; }
    public Guid? SideId { get; set; }
    public string? CommingFromName { get; set; }
    public Guid? ExceptionTypeId { get; set; }
    public string? ExceptionTypeName { get; set; }
    public string? EmploymentStatus { get; set; }
    public DateTime? LastPromotionDate { get; set; }
    public DateTime? LastRaiseDate { get; set; }
    public DateTime? NextRaiseDate { get; set; }
    public string? BasicSalary { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool? IsCurrent { get; set; }
}

public class CareerForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    public string? EmployeeNationalNumber { get; set; }
    public Guid? DirectorateId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? SectionId { get; set; }
    public Guid? JobTitleId { get; set; }
    public Guid? PositionId { get; set; }
    public Guid? RankId { get; set; }
    public Guid? GradeId { get; set; }
    public Guid? StepId { get; set; }
    public Guid? ContinuationId { get; set; }
    public Guid? WorkCareerTypeId { get; set; }
    public Guid? SideId { get; set; }
    public Guid? ExceptionTypeId { get; set; }
    public string? EmploymentStatus { get; set; }
    public DateTime? LastPromotionDate { get; set; }
    public DateTime? LastRaiseDate { get; set; }
    public DateTime? NextRaiseDate { get; set; }
    public string? BasicSalary { get; set; }
    public string? Education { get; set; }
    public string? CareerNotes { get; set; }
    public string? ServiceSummaryNotes { get; set; }
    public string? AssignBookNumber { get; set; }
    public DateTime? AssignBookDate { get; set; }
    public string? InitiationBookNumber { get; set; }
    public DateTime? InitiationBookDate { get; set; }
    public DateTime? InitiationActualDate { get; set; }
    public string? InitiationAtOfficeBookNumber { get; set; }
    public DateTime? InitiationAtOfficeBookDate { get; set; }
    public string? AdditionalService { get; set; }
    public string? MartyreRelated { get; set; }
    public string? PoliticalPrisoner { get; set; }
    public string? PoliticalIsolation { get; set; }
    public DateTime? EndOfServiceDate { get; set; }
    public string? HasLeftEarlier { get; set; }
    public string? Transferred { get; set; }
    public string? DeletionBookNumber { get; set; }
    public string? UpdateBookNumber { get; set; }
    public string? PreviousDirectorate { get; set; }
    public string? NormalVacationCredit { get; set; }
    public string? IllnessVacationCredit { get; set; }
    public int? HasFingerprint { get; set; }
    public DateTime? FingerprintDate { get; set; }
    public string? MinistryFinanceApproval { get; set; }
    public string? ApprovalType { get; set; }
}

public class CareerForUpdateDto : CareerForCreationDto
{
    // Inherits everything from CreationDTO
}
