using Domain.Entities.Employees.Enums;

namespace Application.DataTransferObjects;

public class EmployeeDetailsDto
{
    public Guid Id { get; set; }

    // Core Identity
    public string? EmployeeNumber { get; set; }
    public string? ArchiveNumber { get; set; }
    public EmployeeStatus Status { get; set; }
    public SpecialEmpStatus SpecialEmpStatus { get; set; }

    // Hire Information
    public DateTime HireDate { get; set; }
    public string? HireBookNumber { get; set; }
    public DateTime? HireBookDate { get; set; }
    public string? HireBookFilePath { get; set; }
    public DateTime? StartWorkDate { get; set; }
    public DateTime? StartWorkBookDate { get; set; }
    public string? StartWorkBookFilePath { get; set; }

    // Arabic Name
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? ThirdName { get; set; }
    public string? FourthName { get; set; }
    public string? LastName { get; set; }
    public string? SureName { get; set; }
    public string? MotherName { get; set; }

    // English Name
    public string? FullNameEnglish { get; set; }

    // Personal Attributes
    public Gender Gender { get; set; }
    public Religion Religion { get; set; }
    public Ethnicity Ethnicity { get; set; }
    public BloodGroup? BloodGroup { get; set; }
    public DateTime? BirthDate { get; set; }

    // Family Info
    public MaritalStatus MaritalStatus { get; set; }

    // Contact Info
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
}
