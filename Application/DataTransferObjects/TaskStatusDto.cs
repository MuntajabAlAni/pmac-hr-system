using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class TaskStatusDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class TaskStatusForCreationDto
{
    [Required]
    public string? Name { get; set; }
}

public class TaskStatusForUpdateDto : TaskStatusForCreationDto
{
}
