using System.ComponentModel.DataAnnotations;
using Domain.Entities.Employees.Enums;

namespace Application.DataTransferObjects;

public class EmployeeForCreationDto
{
    [Required(ErrorMessage = "Employee number is required")]
    [MaxLength(50)]
    public string EmployeeNumber { get; set; } = null!;

    [Required(ErrorMessage = "Archive number is required")]
    [MaxLength(50)]
    public string ArchiveNumber { get; set; } = null!;

    [Required(ErrorMessage = "First name is required")]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;

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

    [Required]
    public Gender Gender { get; set; }

    [Required]
    public Religion Religion { get; set; }

    [Required]
    public Ethnicity Ethnicity { get; set; }

    public BloodGroup? BloodGroup { get; set; }

    public DateTime? BirthDate { get; set; }

    public MaritalStatus MaritalStatus { get; set; }

    [Required]
    public DateTime HireDate { get; set; }

    public string? HireBookNumber { get; set; }
    public DateTime? HireBookDate { get; set; }

    [Phone]
    [MaxLength(50)]
    public string? PhoneNumber { get; set; }

    [EmailAddress]
    [MaxLength(250)]
    public string? Email { get; set; }
}
