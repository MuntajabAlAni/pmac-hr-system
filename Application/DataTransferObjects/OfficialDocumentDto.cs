using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class OfficialDocumentDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public Guid DocumentTypeId { get; set; }
    public string? DocumentTypeName { get; set; }
    public string? IssueNumber { get; set; }
    public DateTime? IssueDate { get; set; }
    public string? DestinationOrSubject { get; set; }
    public string? Subject { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string? Notes { get; set; }
    public string? FilePath { get; set; }
}

public class OfficialDocumentForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    [Required]
    public Guid DocumentTypeId { get; set; }
    public string? IssueNumber { get; set; }
    public DateTime? IssueDate { get; set; }
    public string? DestinationOrSubject { get; set; }
    public string? Subject { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string? Notes { get; set; }
    public string? FilePath { get; set; }
}

public class OfficialDocumentForUpdateDto : OfficialDocumentForCreationDto
{
}
