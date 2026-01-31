using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ServiceContinuation
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("حالة استمرارية الخدمة")]
        public required string Name { get; set; }

        public virtual ICollection<Career>? Careers { get; set; }
    }
}