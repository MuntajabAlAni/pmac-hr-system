namespace Application.DataTransferObjects;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? NationalNum { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public Guid? GenderId { get; set; }
    public string? GenderName { get; set; }
    public DateTime? BirthDate { get; set; }
    public Guid? MaritalStatusId { get; set; }
    public string? MaritalStatusName { get; set; }
}
