using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public class EmployeeForUpdateDto
{
    [Required(ErrorMessage = "Full name is required")]
    [MaxLength(250)]
    public string Employee_F_Name { get; set; } = null!;
    
    [Required(ErrorMessage = "First name is required")]
    [MaxLength(100)]
    public string Employee_First_Name { get; set; } = null!;
    
    [MaxLength(100)]
    public string? Employee_Second_Name { get; set; }
    
    [MaxLength(100)]
    public string? Employee_Third_Name { get; set; }
    
    [MaxLength(100)]
    public string? Employee_Forth_Name { get; set; }
    
    [MaxLength(100)]
    public string? Employee_Last_Name { get; set; }
    
    [MaxLength(200)]
    public string? Mother_Name { get; set; }
    
    public int? Gender_Id { get; set; }
    
    public DateTime? Birth_Date { get; set; }
    
    public int? Marital_Status { get; set; }
    
    [Phone]
    [MaxLength(20)]
    public string? Phone_No { get; set; }
    
    [EmailAddress]
    [MaxLength(250)]
    public string? Email { get; set; }
    
    [MaxLength(500)]
    public string? Address { get; set; }
    
    [MaxLength(50)]
    public string? Civil_Id_No { get; set; }
    
    [MaxLength(50)]
    public string? Nat_Card_No { get; set; }
}
