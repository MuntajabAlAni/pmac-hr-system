using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class EmployeeForCreationDto
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
    
    [MaxLength(200)]
    public string? Mother_Name_English { get; set; }
    
    public int? Gender_Id { get; set; }
    
    [MaxLength(10)]
    public string? Blood_Group { get; set; }
    
    [MaxLength(100)]
    public string? Nationality { get; set; }
    
    [MaxLength(100)]
    public string? Relegion { get; set; }
    
    [MaxLength(200)]
    public string? Place_Of_Birth { get; set; }
    
    public DateTime? Birth_Date { get; set; }
    
    public int? Marital_Status { get; set; }
    
    [MaxLength(10)]
    public string? No_Of_Children { get; set; }
    
    [MaxLength(200)]
    public string? Hus_Wif_Name { get; set; }
    
    [MaxLength(200)]
    public string? Hus_Wif_Job { get; set; }
    
    [Phone]
    [MaxLength(20)]
    public string? Phone_No { get; set; }
    
    [EmailAddress]
    [MaxLength(250)]
    public string? Email { get; set; }
    
    [MaxLength(500)]
    public string? Address { get; set; }
    
    [MaxLength(100)]
    public string? District { get; set; }
    
    [MaxLength(100)]
    public string? Alley { get; set; }
    
    [MaxLength(50)]
    public string? House_No { get; set; }
    
    [MaxLength(50)]
    public string? Civil_Id_No { get; set; }
    
    [MaxLength(50)]
    public string? Record_No { get; set; }
    
    [MaxLength(50)]
    public string? Page_No { get; set; }
    
    [MaxLength(200)]
    public string? Publisher { get; set; }
    
    public DateTime? Date_Of_Issuance { get; set; }
    
    [MaxLength(50)]
    public string? Nat_Card_No { get; set; }
    
    public DateTime? Nat_Issuance_Date { get; set; }
    
    [MaxLength(50)]
    public string? Id_Cert_No { get; set; }
    
    [MaxLength(50)]
    public string? Pocket_No { get; set; }
    
    [MaxLength(200)]
    public string? Cert_Publisher { get; set; }
    
    public DateTime? Cert_Issuance_Date { get; set; }
    
    public int Military { get; set; } = 0;
}
