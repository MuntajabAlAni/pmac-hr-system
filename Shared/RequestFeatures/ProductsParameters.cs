using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.RequestFeatures;

public class ProductsParameters : PaginationParameters
{
    public string? Description { get; set; } = string.Empty;
    public Guid? ProductTypeId { get; set; }
    public Guid? ProviderId { get; set; }
    public Guid? AddedByUserId { get; set; }
}
