using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class EmployeeForCreationDto
{
    [Required(ErrorMessage = "Full name is required")]
    [MaxLength(500)]
    public string? FullName { get; set; }

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

    [MaxLength(200)]
    public string? MotherName { get; set; }

    [MaxLength(200)]
    public string? MotherNameEnglish { get; set; }

    public Guid? GenderId { get; set; }

    [MaxLength(10)]
    public string? BloodGroup { get; set; }

    [MaxLength(100)]
    public string? Nationality { get; set; }

    [MaxLength(100)]
    public string? Religion { get; set; }

    [MaxLength(200)]
    public string? PlaceOfBirth { get; set; }

    public DateTime? BirthDate { get; set; }

    public Guid? MaritalStatusId { get; set; }

    [MaxLength(50)]
    public string? NumberOfChildren { get; set; }

    [MaxLength(200)]
    public string? SpouseName { get; set; }

    [MaxLength(200)]
    public string? SpouseJob { get; set; }

    [Phone]
    [MaxLength(50)]
    public string? PhoneNumber { get; set; }

    [EmailAddress]
    [MaxLength(250)]
    public string? Email { get; set; }

    public string? FullAddress { get; set; }

    [MaxLength(50)]
    public string? CivilIdNumber { get; set; }

    [MaxLength(50)]
    public string? RecordNumber { get; set; }

    [MaxLength(50)]
    public string? PageNumber { get; set; }

    [MaxLength(200)]
    public string? Publisher { get; set; }

    public DateTime? DateOfIssuance { get; set; }

    [MaxLength(50)]
    public string? NationalCardNumber { get; set; }

    public DateTime? NationalCardIssuanceDate { get; set; }

    [MaxLength(100)]
    public string? CertificateNumber { get; set; }

    [MaxLength(100)]
    public string? PocketNumber { get; set; }

    [MaxLength(200)]
    public string? CertificatePublisher { get; set; }

    public DateTime? CertificateIssuanceDate { get; set; }

    [MaxLength(200)]
    public string? InformationOfficeName { get; set; }

    [MaxLength(100)]
    public string? HousingCardNumber { get; set; }

    public DateTime? HousingCardIssuanceDate { get; set; }

    [MaxLength(100)]
    public string? SupplyingCardNumber { get; set; }

    [MaxLength(200)]
    public string? SupplyCenterName { get; set; }

    [MaxLength(100)]
    public string? SupplyCenterNumber { get; set; }

    public string? SupplyNotes { get; set; }

    public string? FilePath { get; set; }

    public string? ProfilePicture { get; set; }

    public int Military { get; set; } = 0;
}
