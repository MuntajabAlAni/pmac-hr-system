using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class AddedServiceDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public string? OrderNumber { get; set; }
    public string? BookNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public Guid OrderTypeId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public double? TotalDays { get; set; }
    public int? Years { get; set; }
    public int? Months { get; set; }
    public int? Days { get; set; }
    public string? AddedType { get; set; }
    public string? Notes { get; set; }
    public bool IsRunning { get; set; }
    public string? FilePath { get; set; }
    public Guid ServiceTypeId { get; set; }
    public string? ServiceTypeName { get; set; }
}

public class AddedServiceForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    public string? OrderNumber { get; set; }
    public string? BookNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public Guid OrderTypeId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public double? TotalDays { get; set; }
    public int? Years { get; set; }
    public int? Months { get; set; }
    public int? Days { get; set; }
    public string? AddedType { get; set; }
    public string? Notes { get; set; }
    public bool IsRunning { get; set; }
    public string? FilePath { get; set; }
    public Guid ServiceTypeId { get; set; }
}

public class AddedServiceForUpdateDto : AddedServiceForCreationDto
{
}
