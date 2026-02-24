using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class AdministrativeActionDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeFullName { get; set; }
    public Guid ActionTypeId { get; set; }
    public string? ActionTypeName { get; set; }
    public string? IssueNumber { get; set; }
    public DateTime? IssueDate { get; set; }
    public string? Issuer { get; set; }
    public string? Reason { get; set; }
    public string? Notes { get; set; }
    public string? OldOrderNumber { get; set; }
    public DateTime? OldOrderDate { get; set; }
    public string? FilePath { get; set; }
}

public class AdministrativeActionForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    [Required]
    public Guid ActionTypeId { get; set; }
    public string? IssueNumber { get; set; }
    public DateTime? IssueDate { get; set; }
    public string? Issuer { get; set; }
    public string? Reason { get; set; }
    public string? Notes { get; set; }
    public string? OldOrderNumber { get; set; }
    public DateTime? OldOrderDate { get; set; }
    public string? FilePath { get; set; }
}

public class AdministrativeActionForUpdateDto : AdministrativeActionForCreationDto
{
}
