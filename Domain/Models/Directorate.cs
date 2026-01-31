using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Directorate
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Directorate_Name")]
        public required string Name { get; set; }

        [DisplayName("Exception")]
        [DefaultValue(0)]
        public int Exception { get; set; }

        public virtual ICollection<Department>? Departments { get; set; }

        public virtual ICollection<Career>? Careers { get; set; }
    }
}
