using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class DeligationDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public string? Destination { get; set; }
    public string? Sponsor { get; set; }
    public string? Subject { get; set; }
    public string? Title { get; set; }
    public string? Evaluator { get; set; }
    public string? ActualDays { get; set; }
    public string? TravelDays { get; set; }
    public DateTime? TravelDate { get; set; }
    public string? OrderNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? InitiationDate { get; set; }
    public string? Notes { get; set; }
    public string? FilePath { get; set; }
}

public class DeligationForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    public string? Destination { get; set; }
    public string? Sponsor { get; set; }
    public string? Subject { get; set; }
    public string? Title { get; set; }
    public string? Evaluator { get; set; }
    public string? ActualDays { get; set; }
    public string? TravelDays { get; set; }
    public DateTime? TravelDate { get; set; }
    public string? OrderNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? InitiationDate { get; set; }
    public string? Notes { get; set; }
    public string? FilePath { get; set; }
}

public class DeligationForUpdateDto : DeligationForCreationDto
{
}
