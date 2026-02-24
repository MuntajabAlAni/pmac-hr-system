using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Grade
{
    [DisplayName("Id")]
    [Key]
    public Guid Id { get; set; }

    [DisplayName("الدرجة الوظيفية")]
    public required string Name { get; set; }

    public virtual ICollection<Career>? Careers { get; set; }
}
