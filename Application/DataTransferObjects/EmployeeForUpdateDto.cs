using System.ComponentModel.DataAnnotations;
using Domain.Entities.Employees.Enums;

namespace Application.DataTransferObjects;

public class EmployeeForUpdateDto
{
    [MaxLength(100)]
    public string? FirstName { get; set; }

    [MaxLength(100)]
    public string? SecondName { get; set; }

    [MaxLength(100)]
    public string? ThirdName { get; set; }

    [MaxLength(100)]
    public string? FourthName { get; set; }

    [MaxLength(100)]
    public string? LastName { get; set; }

    [MaxLength(100)]
    public string? SureName { get; set; }

    [MaxLength(200)]
    public string? MotherName { get; set; }

    [MaxLength(500)]
    public string? FullNameEnglish { get; set; }

    public Gender? Gender { get; set; }
    public Religion? Religion { get; set; }
    public Ethnicity? Ethnicity { get; set; }
    public BloodGroup? BloodGroup { get; set; }
    public DateTime? BirthDate { get; set; }
    public MaritalStatus? MaritalStatus { get; set; }

    // Hire Info
    public DateTime? HireDate { get; set; }
    public string? HireBookNumber { get; set; }
    public DateTime? HireBookDate { get; set; }
    public string? HireBookFilePath { get; set; }
    public DateTime? StartWorkDate { get; set; }
    public DateTime? StartWorkBookDate { get; set; }
    public string? StartWorkBookFilePath { get; set; }

    [Phone]
    [MaxLength(50)]
    public string? PhoneNumber { get; set; }

    [EmailAddress]
    [MaxLength(250)]
    public string? Email { get; set; }

    public SpecialEmpStatus? SpecialEmpStatus { get; set; }
    public EmployeeStatus? Status { get; set; }
}
