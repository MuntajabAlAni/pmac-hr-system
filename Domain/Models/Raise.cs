using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Models
{
    public class Raise
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }



        [DisplayName("رقم الامر")]
        public string? OrderNumber { get; set; }

        [DisplayName("العدد")]
        public string? OrderCountNumber { get; set; }

        [DisplayName("تاريخ الامر")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [DisplayName("نوع الامر")]
        public Guid RaiseTypeId { get; set; }

        [DisplayName("الدرجة السابقة")]
        public Guid GradeId { get; set; }

        [DisplayName("المرحلة السابقة")]
        public Guid StepId { get; set; }

        [DisplayName("الراتب السابق")]
        public string? Salary { get; set; }

        [DisplayName("العنوان الوظيفي السابق")]
        public Guid JobTitleId { get; set; }

        [DisplayName("تاريخ الاستحقاق السابق")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastRaiseDate { get; set; }

        [DisplayName("الدرجة الحالية")]
        public int NewGrade { get; set; }

        [DisplayName("الدرجة الحالية")]
        public string? NewGradeString { get; set; }

        [DisplayName("المرحلة الحالية")]
        public int NewStep { get; set; }

        [DisplayName("المرحلة الحالية")]
        public string? NewStepString { get; set; }

        //----------------
        [DisplayName("الدرجة القادمة")]
        public string? NextGradeString { get; set; }

        [DisplayName("المرحلة القادمة")]
        public string? NextStepString { get; set; }

        //-------------------
        [DisplayName("الراتب الحالي")]
        public string? NewSalary { get; set; }

        [DisplayName("العنوان الوظيفي الحالي")]
        public Guid NewJobTitleId { get; set; }

        [DisplayName("العنوان الوظيفي الحالي")]
        public string? NewJobTitleString { get; set; }

        [DisplayName("العنوان الوظيفي القادم")]
        public string? NextJobTitleString { get; set; }

        [DisplayName("تاريخ الاستحقاق الحالي")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CurrentRaiseDate { get; set; }

        [DisplayName("تاريخ الاستحقاق القادم")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NextRaiseDate { get; set; }

        [DisplayName("احتساب يدوي/ تلقائي")]
        [DefaultValue("تلقائي")]
        public string? AutoManual { get; set; }

        [DisplayName("الاستحقاق القادم (علاوة/ ترفيع)")]
        public string? NextRaisePromotion { get; set; }

        [DisplayName("عدد الايام المدورة")]
        public string? CycledDays { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string? FilePath { get; set; }

        [DisplayName("اخر علاوة أو ترفيع")]
        [DefaultValue(false)]
        public bool IsLastRP { get; set; }

        [DisplayName("يطبع في المحضر القادم؟")]
        [DefaultValue(false)]
        public bool IsRecord { get; set; }

        [DisplayName("العلاوة أة الترقية معلقة؟")]
        [DefaultValue(false)]
        public bool IsSuspended { get; set; }

        [DisplayName("الشهادة لهذه الترقية")]
        public string? Education { get; set; }

        //--------------------------Relationships----------------------------------------
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        [ForeignKey("RaiseTypeId")]
        public virtual RaiseType? RaiseType { get; set; }

        [ForeignKey("GradeId")]
        public virtual Grade? Grade { get; set; }

        [ForeignKey("StepId")]
        public virtual Step? Step { get; set; }

        [ForeignKey("JobTitleId")]
        public virtual JobTitle? JobTitle { get; set; }
    }
}
