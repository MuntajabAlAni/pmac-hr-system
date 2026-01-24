using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DataTransferObjects;

public class PermissionDto
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public string Tag { get; set; } = null!;
}
