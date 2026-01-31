using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class TrainingCourse
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }

        [DisplayName("اسم الموظف")]
        public string? EmployeeName { get; set; }

        [DisplayName("رقم الامر الخاص بالدورة")]
        public string? OrderNumber { get; set; }

        [DisplayName(" تأريخ الامر الاداري ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [DisplayName("اسم الدورة")]
        public string? CourseName { get; set; }

        [DisplayName("الجهة الممولة للدورة")]
        public string? Sponsor { get; set; }

        [DisplayName("الجهة المقيمة للدورة")]
        public string? CourseEvaluator { get; set; }

        [DisplayName("عدد أيام الدورة")]
        public string? NumberOfDays { get; set; }

        [DisplayName(" تأريخ بدأ الدورة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [DisplayName(" تأريخ انتهاء الدورة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [DisplayName(" تأريخ الانفكاك ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DetachmentDate { get; set; }

        [DisplayName(" تأريخ المباشرة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationDate { get; set; }

        [DisplayName("التقييم")]
        public string? Evaluation { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? CourseNotes { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string? FilePath { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
}
