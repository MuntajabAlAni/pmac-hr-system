using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.RequestFeatures;

public class ProvidersParameters : PaginationParameters
{
    public string? Name { get; set; } = string.Empty;
    public Guid? AddedByUserId { get; set; }
}
