using Action = Domain.Enums.Action;

namespace Domain.RequestFeatures;

public class ActivityLogParameters : PaginationParameters
{
    public Action Action { get; set; } = Action.All;
    public DateTime FromDate { get; set; } = new(1753, 1, 1);
    public DateTime ToDate { get; set; } = new(9999, 12, 31);
}