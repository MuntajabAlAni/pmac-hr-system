namespace Shared.DataTransferObjects;

public class EmployeeDto
{
    public int Emp_Id { get; set; }
    public string Employee_F_Name { get; set; } = null!;
    public string? Employee_First_Name { get; set; }
    public string? Employee_Second_Name { get; set; }
    public string? Employee_Third_Name { get; set; }
    public string? Employee_Forth_Name { get; set; }
    public string? Employee_Last_Name { get; set; }
    public string? Mother_Name { get; set; }
    public int? Gender_Id { get; set; }
    public string? Gender_Name { get; set; }
    public DateTime? Birth_Date { get; set; }
    public string? Phone_No { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Civil_Id_No { get; set; }
    public string? Nat_Card_No { get; set; }
    public int? Marital_Status { get; set; }
    public string? Marital_Status_Name { get; set; }
}
