using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class RewardDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public string? RewardGiver { get; set; }
    public string? RewardAmount { get; set; }
    public string? RewardReason { get; set; }
    public string? OrderType { get; set; }
    public string? OrderNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public string? FilePath { get; set; }
}

public class RewardForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    public string? RewardGiver { get; set; }
    public string? RewardAmount { get; set; }
    public string? RewardReason { get; set; }
    public string? OrderType { get; set; }
    public string? OrderNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public string? FilePath { get; set; }
}

public class RewardForUpdateDto : RewardForCreationDto
{
}
