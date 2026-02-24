using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class OfficialDocumentTypeDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class OfficialDocumentTypeForCreationDto
{
    [Required]
    public string? Name { get; set; }
}

public class OfficialDocumentTypeForUpdateDto : OfficialDocumentTypeForCreationDto
{
}
