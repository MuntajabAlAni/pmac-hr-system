using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class PersonalCardDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public string? CardNumber { get; set; }
    public DateTime? IssuanceDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? FilePath { get; set; }
}

public class PersonalCardForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    public string? CardNumber { get; set; }
    public DateTime? IssuanceDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? FilePath { get; set; }
}

public class PersonalCardForUpdateDto : PersonalCardForCreationDto
{
}
