using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class VacationType
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("نوع الاجازة ")]
        public required string Name { get; set; }

        [DisplayName("Is_Condition")]
        [DefaultValue(false)]
        public bool? IsCondition { get; set; }

        [DisplayName("خدمة فعلية مع تفعيل عداد الرصيد؟")]
        [DefaultValue(false)]
        public bool? Rsed { get; set; }

        [DisplayName("يؤثر على العلاوة؟")]
        [DefaultValue(false)]
        public bool? RaiseAffected { get; set; }

        public virtual ICollection<Vacation>? Vacations { get; set; }
    }
}