using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class AdministrativeAction
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("الموظف")]
        public Guid EmployeeId { get; set; }

        [DisplayName("نوع الاجراء")]
        public Guid ActionTypeId { get; set; }

        [DisplayName("العدد")]
        public string? IssueNumber { get; set; }

        [DisplayName("التاريخ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? IssueDate { get; set; }

        [DisplayName("الجهة المصدرة")] // Donor / Punisher
        public string? Issuer { get; set; }

        [DisplayName("السبب")]
        [DataType(DataType.MultilineText)]
        public string? Reason { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }

        // Specific fields from Thank (Qadam)
        [DisplayName("رقم امر القدم")]
        public string? OldOrderNumber { get; set; }

        [DisplayName("تاريخ امر القدم")]
        [DataType(DataType.Date)]
        public DateTime? OldOrderDate { get; set; }

        [DisplayName("الملف المرفق")]
        public string? FilePath { get; set; }

        // Relationships
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        [ForeignKey("ActionTypeId")]
        public virtual AdministrativeActionType? ActionType { get; set; }
    }
}
