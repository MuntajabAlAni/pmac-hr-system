using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class PersonalCard
    {
        public string? Pic { get; set; }

        [DisplayName("اسم الموظف")]
        public string? EmployeeName { get; set; }

        [DisplayName("تأريخ الولادة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [DisplayName("الدرجة الوظيفية")]
        public string? Grade { get; set; }

        [DisplayName("المرحلة")]
        public string? Step { get; set; }

        [DisplayName("العنوان الوظيفي")]
        public string? JobTitle { get; set; }

        [DisplayName("اسم الدائرة")]
        public string? Directorate { get; set; }

        [DisplayName("اسم القسم")]
        public string? Department { get; set; }

        [DisplayName("رقم الموظف الوطني")]
        public string? EmployeeNationalNumber { get; set; }

        [DisplayName("الحالة الوظيفية")]
        public string? EmploymentStatus { get; set; }

        [DisplayName("المنصب")]
        public string? PositionId { get; set; }

        [DisplayName("تاريخ كتاب التعيين")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AssignBookDate { get; set; }

        [DisplayName("تأريخ المباشرة في الوظيفة العامة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationActualDate { get; set; }

        [DisplayName("تأريخ  المباشرة في المكتب")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationAtOfficeBookDate { get; set; }

        [DisplayName("تأريخ  المباشرة في المكتب")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndOfServiceDate { get; set; }

        [DisplayName("التحصيل الدراسي")]
        public string? Education { get; set; }

        [DisplayName("الجهة المانحة")]
        public string? CertificatePublisherId { get; set; }

        [DisplayName("التخصص")]
        [DefaultValue("لم يذكر")]
        public string? Major { get; set; }

        [DisplayName("سنة التخرج")]
        public string? YearOfGraduate { get; set; }

        [DisplayName("نوع العمل")]
        public string? WorkCareerTypeId { get; set; }

        //مدة الخدمة يوم-شهر-سنة
        [DisplayName("سنوات")]
        public int? Years { get; set; }

        [DisplayName("أشهر")]
        public int? Months { get; set; }

        [DisplayName("أيام")]
        public int? Days { get; set; }

        [DisplayName("عدد كتب الشكر من السيد رئيس مجلس الوزراء")]
        public int? ThanksPM { get; set; }

        [DisplayName("عدد كتب الشكر من السيد مدير المكتب")]
        public int? ThanksOM { get; set; }
    }
}
