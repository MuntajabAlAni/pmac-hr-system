using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class CertificatePublisherDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class CertificatePublisherForCreationDto
{
    [Required]
    public string? Name { get; set; }
}

public class CertificatePublisherForUpdateDto : CertificatePublisherForCreationDto
{
}
