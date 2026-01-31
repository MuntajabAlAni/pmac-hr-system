using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class VacationTotal
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("الرصيد المدور من الاجازات الاعتيادية")]
        [DefaultValue("0")]
        public string? OrdinaryVacationTotal { get; set; }

        [DisplayName("الرصيد المدور من الاجازات المرضية")]
        [DefaultValue("0")]
        public string? IllnessVacationTotal { get; set; }

        [DisplayName("الرصيد النهائي للاعتيادية")]
        [DefaultValue("0")]
        public string? OrdinaryFinalTotal { get; set; }

        [DisplayName("الرصيد النهائي للمرضية")]
        [DefaultValue("0")]
        public string? IllnessFinalTotal { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }

        [DisplayName("اسم الموظف")]
        public string? EmployeeName { get; set; }

        //--------------------------Relationships----------------------------------------
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
}