namespace Domain.RequestFeatures;

public class UsersParameters : PaginationParameters
{
    public string? FullName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public Guid? RoleId { get; set; }
    public Guid? ProviderId { get; set; }
    public Guid? AddedByUserId { get; set; }
}