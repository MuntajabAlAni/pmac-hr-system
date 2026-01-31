using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class ConsultantTask
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }

        [DisplayName("اسم الموظف")]
        public string? EmployeeName { get; set; }

        [DisplayName("الموضوع")]
        [DataType(DataType.MultilineText)]
        public string? Subject { get; set; }

        [DisplayName("وصف المهمة")]
        public Guid? TaskDescriptionId { get; set; }

        [DisplayName("تاريخ الاحالة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TaskDate { get; set; }

        [DisplayName("طبيعة العمل")]
        public Guid? WorkNatureId { get; set; }

        [DisplayName("حالة الاجراء")]
        public Guid? TaskStatusId { get; set; }

        [DisplayName("توصيف الاجراء")]
        public Guid? ProcedureDescriptionId { get; set; }

        [DisplayName("وصف تقدم العمل")]
        [DataType(DataType.MultilineText)]
        public string? ProgressDescription { get; set; }

        [DisplayName("التوصيات")]
        [DataType(DataType.MultilineText)]
        public string? TaskRecommendations { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? TaskNotes { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string? FilePath { get; set; }

        //--------------------------Relationships----------------------------------------
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        [ForeignKey("TaskDescriptionId")]
        public virtual TaskDescription? TaskDescription { get; set; }

        [ForeignKey("WorkNatureId")]
        public virtual WorkNature? WorkNature { get; set; }

        [ForeignKey("TaskStatusId")]
        public virtual TaskStatus? TaskStatus { get; set; }

        [ForeignKey("ProcedureDescriptionId")]
        public virtual ProcedureDescription? ProcedureDescription { get; set; }
    }
}
