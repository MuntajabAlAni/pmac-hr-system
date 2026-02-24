using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Step
{
    [DisplayName("Id")]
    [Key]
    public Guid Id { get; set; }

    [DisplayName("المرحلة الوظيفية")]
    public required string Name { get; set; }

    public virtual ICollection<Career>? Careers { get; set; }
}
