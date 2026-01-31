using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Vacation
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }



        [DisplayName("رقم الامر الاداري")]
        public string? OrderIssueNumber { get; set; }

        [DisplayName("تاريخ الامر الاداري")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderIssueDate { get; set; }

        [DisplayName("نوع الاجازة")]
        public Guid VacationTypeId { get; set; }

        //--------------------------Relationships----------------------------------------
        [ForeignKey("VacationTypeId")]
        public virtual VacationType? VacationType { get; set; }

        //------salary
        [DisplayName("الايام")]
        [DefaultValue(0)]
        public int NumberOfDays { get; set; }

        [DisplayName("الاشهر")]
        [DefaultValue(0)]
        public int NumberOfMonths { get; set; }

        [DisplayName("السنوات")]
        [DefaultValue(0)]
        public int NumberOfYears { get; set; }

        //------ without salary
        [DisplayName("الايام")]
        [DefaultValue(0)]
        public int NumberOfDays2 { get; set; }

        [DisplayName("الاشهر")]
        [DefaultValue(0)]
        public int NumberOfMonths2 { get; set; }

        [DisplayName("السنوات")]
        [DefaultValue(0)]
        public int NumberOfYears2 { get; set; }

        [DisplayName("تاريخ التمتع بالاجازة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [DisplayName("رقم أمر المباشرة")]
        public string? VacationDirectOrderNumber { get; set; }

        [DisplayName("العدد")]
        public string? BookNumber { get; set; }

        [DisplayName("تاريخ المباشرة الفعلي")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [DisplayName("رقم كتاب المباشرة")]
        public string? ProceedingBookNumber { get; set; }

        [DisplayName("تاريخ كتاب المباشرة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ProceedingBookDate { get; set; }

        [DisplayName("سارية التأثير على الاستحقاق الحالي؟")]
        [DefaultValue(1)]
        public int Running { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? VacationNotes { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string? FilePath { get; set; }

        [DisplayName("اسم مدخل القيد")]
        public string? UserName { get; set; }

        [DisplayName("تاريخ ادخال القيد")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EntryDate { get; set; }

        //--------------------------Relationships----------------------------------------
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
}
