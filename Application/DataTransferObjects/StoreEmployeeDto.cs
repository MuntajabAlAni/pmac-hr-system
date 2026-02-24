using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class StoreEmployeeDto
{
    public Guid Id { get; set; }
    public int HREmployeeId { get; set; }
    public string? FullName { get; set; }
    public string? Directorate { get; set; }
    public string? Department { get; set; }
    public DateTime? DateOfEmployment { get; set; }
    public DateTime? DateOfInitiation { get; set; }
    public string? Malak { get; set; }
    public int? Continuation { get; set; }
}

public class StoreEmployeeForCreationDto
{
    [Required]
    public int HREmployeeId { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string? FullName { get; set; }
    
    [MaxLength(200)]
    public string? Directorate { get; set; }
    
    [MaxLength(200)]
    public string? Department { get; set; }
    
    public DateTime? DateOfEmployment { get; set; }
    public DateTime? DateOfInitiation { get; set; }
    
    [MaxLength(100)]
    public string? Malak { get; set; }
    
    public int? Continuation { get; set; }
}

public class StoreEmployeeForUpdateDto
{
    [Required]
    public int HREmployeeId { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string? FullName { get; set; }
    
    [MaxLength(200)]
    public string? Directorate { get; set; }
    
    [MaxLength(200)]
    public string? Department { get; set; }
    
    public DateTime? DateOfEmployment { get; set; }
    public DateTime? DateOfInitiation { get; set; }
    
    [MaxLength(100)]
    public string? Malak { get; set; }
    
    public int? Continuation { get; set; }
}
