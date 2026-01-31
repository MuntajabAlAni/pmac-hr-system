using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Reward
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }

        [DisplayName("اسم الموظف")]
        public string? EmployeeName { get; set; }

        [DisplayName("الجهة المانحة")]
        public string? RewardGiver { get; set; }

        [DisplayName("مبلغ المكافأة")]
        public string? RewardAmount { get; set; }

        [DisplayName("سبب المكافئة")]
        public string? RewardReason { get; set; }

        [DisplayName("نوع الامر")]
        public string? OrderType { get; set; }

        [DisplayName("رقم الامر الاداري")]
        public string? OrderNumber { get; set; }

        [DisplayName("تاريخ الامر الاداري")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string? FilePath { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
}
