using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class EducationCertificate
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }

        [DisplayName("اسم الموظف")]
        public string? EmployeeName { get; set; }

        [DisplayName("التحصيل الدراسي")]
        public Guid CertificateId { get; set; }

        [DisplayName("عدد أشهر الخدمة المضافة")]
        [DefaultValue(0)]
        public int NumberOfMonths { get; set; }

        [DisplayName("اسم الجامعة/ المعهد")]
        public string? InstituteName { get; set; }

        [DisplayName("اسم الكلية")]
        public string? CollegeName { get; set; }

        [DisplayName("اسم القسم")]
        public string? DepartmentName { get; set; }

        [DisplayName("التخصص")]
        public string? Major { get; set; }

        [DisplayName("رقم الوثيقة")]
        public string? CertificateNumber { get; set; }

        [DisplayName("تأريخ اصدار الوثيقة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [DisplayName("سنة التخرج")]
        public string? YearOfGraduate { get; set; }

        [DisplayName("رقم صحة الصدور")]
        public string? ApproveCertificateNumber { get; set; }

        [DisplayName("تأريخ صحة الصدور")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ApproveCertificateDate { get; set; }

        [DisplayName("البلد المانح للشهادة")]
        public string? CountryOfGraduate { get; set; }

        [DisplayName("التسلسل")]
        public string? Sequence { get; set; }

        [DisplayName("المعدل")]
        public string? Average { get; set; }

        [DisplayName("يؤثر على العلاوة")]
        [Required]
        public string? AffectRaise { get; set; }

        [DisplayName("تأريخ احتساب الشهادة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ConsiderationDate { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? EducationNotes { get; set; }

        [DisplayName("سارية التأثير على الاستحقاق الحالي؟")]
        [DefaultValue(1)]
        public int Running { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string? FilePath { get; set; }

        //--------------------------Relationships----------------------------------------
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        [ForeignKey("CertificateId")]
        public virtual Certificate? Certificate { get; set; }
    }
}
