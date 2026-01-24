using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.RequestFeatures;

public class ProductTypesParameters : PaginationParameters
{
    public string? Description { get; set; } = string.Empty;
    public Guid? ParentTypeId { get; set; }
    public Guid? AddedByUserId { get; set; }
}
