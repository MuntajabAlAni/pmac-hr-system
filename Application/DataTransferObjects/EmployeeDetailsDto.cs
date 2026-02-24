namespace Application.DataTransferObjects;

public class EmployeeDetailsDto
{
    public Guid Id { get; set; }
    public Guid StoreEmployeeId { get; set; }
    public string? FullName { get; set; }

    // Personal Information
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? ThirdName { get; set; }
    public string? FourthName { get; set; }
    public string? LastName { get; set; }
    public string? MotherName { get; set; }
    public string? MotherNameEnglish { get; set; }

    // Demographics
    public Guid? GenderId { get; set; }
    public string? GenderName { get; set; }
    public string? BloodGroup { get; set; }
    public string? Nationality { get; set; }
    public string? Religion { get; set; }
    public string? PlaceOfBirth { get; set; }
    public DateTime? BirthDate { get; set; }

    // Marital Status
    public Guid? MaritalStatusId { get; set; }
    public string? MaritalStatusName { get; set; }
    public string? NumberOfChildren { get; set; }
    public string? SpouseName { get; set; }
    public string? SpouseJob { get; set; }

    // Contact Information
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? FullAddress { get; set; }

    // Identification Information
    public string? CivilIdNumber { get; set; }
    public string? RecordNumber { get; set; }
    public string? PageNumber { get; set; }
    public string? Publisher { get; set; }
    public DateTime? DateOfIssuance { get; set; }
    public string? NationalCardNumber { get; set; }
    public DateTime? NationalCardIssuanceDate { get; set; }

    // Nationality Certificate
    public string? CertificateNumber { get; set; }
    public string? PocketNumber { get; set; }
    public string? CertificatePublisher { get; set; }
    public DateTime? CertificateIssuanceDate { get; set; }

    // Housing & Supplying
    public string? InformationOfficeName { get; set; }
    public string? HousingCardNumber { get; set; }
    public DateTime? HousingCardIssuanceDate { get; set; }
    public string? SupplyingCardNumber { get; set; }
    public string? SupplyCenterName { get; set; }
    public string? SupplyCenterNumber { get; set; }
    public string? SupplyNotes { get; set; }

    // Additional
    public string? FilePath { get; set; }
    public string? ProfilePicture { get; set; }
    public bool IsSelected { get; set; }
    public bool IsSelectedThanks { get; set; }
    public bool IsSelectedLetters { get; set; }
    public int Military { get; set; }
}
