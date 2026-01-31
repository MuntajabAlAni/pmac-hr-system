using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class TaskDescription
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("وصف المهمة")]
        public required string Description { get; set; }

        public virtual ICollection<ConsultantTask>? ConsultantTasks { get; set; }
    }
}