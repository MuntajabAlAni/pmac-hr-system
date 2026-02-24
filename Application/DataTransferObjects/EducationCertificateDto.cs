using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class EducationCertificateDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public Guid CertificateId { get; set; }
    public string? CertificateName { get; set; }
    public int NumberOfMonths { get; set; }
    public string? InstituteName { get; set; }
    public string? CollegeName { get; set; }
    public string? DepartmentName { get; set; }
    public string? Major { get; set; }
    public string? CertificateNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public string? YearOfGraduate { get; set; }
    public string? ApproveCertificateNumber { get; set; }
    public DateTime? ApproveCertificateDate { get; set; }
    public string? CountryOfGraduate { get; set; }
    public string? Sequence { get; set; }
    public string? Average { get; set; }
    public string? AffectRaise { get; set; }
    public DateTime? ConsiderationDate { get; set; }
    public string? EducationNotes { get; set; }
    public int Running { get; set; }
    public string? FilePath { get; set; }
}

public class EducationCertificateForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    [Required]
    public Guid CertificateId { get; set; }
    public int NumberOfMonths { get; set; }
    public string? InstituteName { get; set; }
    public string? CollegeName { get; set; }
    public string? DepartmentName { get; set; }
    public string? Major { get; set; }
    public string? CertificateNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public string? YearOfGraduate { get; set; }
    public string? ApproveCertificateNumber { get; set; }
    public DateTime? ApproveCertificateDate { get; set; }
    public string? CountryOfGraduate { get; set; }
    public string? Sequence { get; set; }
    public string? Average { get; set; }
    [Required]
    public string? AffectRaise { get; set; }
    public DateTime? ConsiderationDate { get; set; }
    public string? EducationNotes { get; set; }
    public int Running { get; set; } = 1;
    public string? FilePath { get; set; }
}

public class EducationCertificateForUpdateDto : EducationCertificateForCreationDto
{
}
