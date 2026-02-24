using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class CertificateDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int NoOfMonths { get; set; }
}

public class CertificateForCreationDto
{
    [Required]
    public string? Name { get; set; }
    public int NoOfMonths { get; set; }
}

public class CertificateForUpdateDto : CertificateForCreationDto
{
}
