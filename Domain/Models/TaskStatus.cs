using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class TaskStatus
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("حالة الاجراء")]
        public required string Status { get; set; }

        public virtual ICollection<ConsultantTask>? ConsultantTasks { get; set; }
    }
}