namespace Shared.DataTransferObjects;

public class EmployeeDetailsDto
{
    public int Emp_Id { get; set; }
    
    // Personal Information
    public string Employee_F_Name { get; set; } = null!;
    public string? Employee_First_Name { get; set; }
    public string? Employee_Second_Name { get; set; }
    public string? Employee_Third_Name { get; set; }
    public string? Employee_Forth_Name { get; set; }
    public string? Employee_Last_Name { get; set; }
    public string? Mother_Name { get; set; }
    public string? Mother_Name_English { get; set; }
    
    // Demographics
    public int? Gender_Id { get; set; }
    public string? Blood_Group { get; set; }
    public string? Nationality { get; set; }
    public string? Relegion { get; set; }
    public string? Place_Of_Birth { get; set; }
    public DateTime? Birth_Date { get; set; }
    
    // Marital Status
    public int? Marital_Status { get; set; }
    public string? No_Of_Children { get; set; }
    public string? Hus_Wif_Name { get; set; }
    public string? Hus_Wif_Job { get; set; }
    
    // Contact Information
    public string? Phone_No { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? District { get; set; }
    public string? Alley { get; set; }
    public string? House_No { get; set; }
    
    // Civil ID Information
    public string? Civil_Id_No { get; set; }
    public string? Record_No { get; set; }
    public string? Page_No { get; set; }
    public string? Publisher { get; set; }
    public DateTime? Date_Of_Issuance { get; set; }
    
    // National Card
    public string? Nat_Card_No { get; set; }
    public DateTime? Nat_Issuance_Date { get; set; }
    
    // Nationality Certificate
    public string? Id_Cert_No { get; set; }
    public string? Pocket_No { get; set; }
    public string? Cert_Publisher { get; set; }
    public DateTime? Cert_Issuance_Date { get; set; }
    
    // Additional
    public string? Prof_Pic { get; set; }
    public string? File_Path { get; set; }
    public int Military { get; set; }
}
