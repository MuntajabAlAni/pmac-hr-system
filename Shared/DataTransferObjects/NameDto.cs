using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects;
public class NameDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}
