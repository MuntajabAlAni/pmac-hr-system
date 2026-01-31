using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class FingerPrintViewModel
    {
        [DisplayName("الاسم  الكامل")]
        public string? EmployeeName { get; set; }

        [DisplayName("نوع الخدمة")]
        public int? Military { get; set; }

        [DisplayName("اسم الدائرة")]
        public Guid? DirectorateId { get; set; }

        [DisplayName("اسم القسم")]
        public Guid? DepartmentId { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? CareerNotes { get; set; }

        [DisplayName("المهام")]
        [DataType(DataType.MultilineText)]
        public string? WorkType { get; set; }

        [DisplayName("لديه بصمة الكترونية")]
        public int? HasFingerprint { get; set; }

        [DisplayName("حالة الاستثناء")]
        public int? ExceptionType { get; set; }

        [DisplayName("تأريخ تسجيل البصمة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FingerprintDate { get; set; }
    }
}
