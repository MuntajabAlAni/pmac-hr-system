using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ProcedureDescription
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("توصيف الاجراء")]
        public required string Description { get; set; }

        public virtual ICollection<ConsultantTask>? ConsultantTasks { get; set; }
    }
}