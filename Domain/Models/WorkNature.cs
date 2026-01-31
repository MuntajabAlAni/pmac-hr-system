using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class WorkNature
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("طبيعة العمل")]
        public required string Name { get; set; }

        public virtual ICollection<ConsultantTask>? ConsultantTasks { get; set; }
    }
}