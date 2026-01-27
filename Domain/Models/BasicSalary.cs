using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class BasicSalary
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Salary")]
        public required string Salary { get; set; }

        //public virtual ICollection<Raise_Tbl> Salary_To_Raise_rel { get; set; }
    }
}
