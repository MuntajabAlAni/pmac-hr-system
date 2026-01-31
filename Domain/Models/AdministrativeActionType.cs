using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class AdministrativeActionType
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("نوع الاجراء")]
        public required string Name { get; set; }

        [DisplayName("التأثير (بالايام)")]
        [DefaultValue(0)]
        public int ImpactInDays { get; set; } // Positive for Thanks, Negative for Punishment

        [DisplayName("هل هو عقوبة؟")]
        [DefaultValue(false)]
        public bool IsPenalty { get; set; }

        [DisplayName("يؤثر على العلاوة؟")]
        [DefaultValue(false)]
        public bool RaiseAffected { get; set; }

        public virtual ICollection<AdministrativeAction>? AdministrativeActions { get; set; }
    }
}
