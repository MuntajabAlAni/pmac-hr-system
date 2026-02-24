using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class FingerPrintExceptionTypeDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class FingerPrintExceptionTypeForCreationDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
}

public class FingerPrintExceptionTypeForUpdateDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200)]
    public string? Name { get; set; }
}
