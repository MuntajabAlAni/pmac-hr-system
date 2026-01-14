namespace Shared.RequestFeatures;

public class PaginationParameters
{
    private const int MaxPageSize = 110;
    public int PageNumber { get; set; } = 1;

    private int _pageSize = 16;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}