using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class WorkCareerType
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("نوع العمل ")]
        public required string Name { get; set; }

        public virtual ICollection<Career>? Careers { get; set; }
    }
}