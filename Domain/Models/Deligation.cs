using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Deligation
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }

        [DisplayName("اسم الموظف")]
        public string? EmployeeName { get; set; }

        [DisplayName("وجهة الايفاد")]
        public string? Destination { get; set; }

        [DisplayName("الجهة الممولة")]
        public string? Sponsor { get; set; }

        [DisplayName("موضوع الايفاد")]
        public string? Subject { get; set; }

        [DisplayName("العنوان")]
        public string? Title { get; set; }

        [DisplayName("الجهة المقيمة لدورة")]
        public string? Evaluator { get; set; }

        [DisplayName("عدد ايام الايفاد الفعلية")]
        public string? ActualDays { get; set; }

        [DisplayName("عدد ايام السفر ")]
        public string? TravelDays { get; set; }

        [DisplayName("تأريخ السفر ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TravelDate { get; set; }

        [DisplayName("رقم الامر الاداري")]
        public string? OrderNumber { get; set; }

        [DisplayName("تاريخ الامر الاداري ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [DisplayName("تاريخ المباشرة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationDate { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string? FilePath { get; set; }

        //--------------------------Relationships----------------------------------------
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
}
