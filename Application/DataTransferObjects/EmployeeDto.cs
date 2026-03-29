using Domain.Entities.Employees.Enums;

namespace Application.DataTransferObjects;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string? EmployeeNumber { get; set; }
    public string? ArchiveNumber { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? ThirdName { get; set; }
    public string? FourthName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public Gender Gender { get; set; }
    public EmployeeStatus Status { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime HireDate { get; set; }
}
