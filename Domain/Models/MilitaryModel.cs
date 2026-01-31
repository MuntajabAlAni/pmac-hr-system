using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class MilitaryModel
    {
        [DisplayName("Emp_Id")]
        [Key]
        public Guid Id { get; set; }

        //employee-------------------------------------

        [DisplayName("الاسم  الكامل")]
        [Required]
        public required string EmployeeFullName { get; set; }

        //---career -----------------------------------------------

        [DisplayName("الرتبة")]
        public Guid? RankId { get; set; }

        [ForeignKey("RankId")]
        public virtual Rank? Rank { get; set; }


        [DisplayName("الجهة المكلف منها")]
        [DataType(DataType.MultilineText)]
        public string? PreviousDirectorate { get; set; }

        [DisplayName("اسم الدائرة")]
        public Guid? DirectorateId { get; set; }

        [DisplayName("اسم القسم")]
        public Guid? DepartmentId { get; set; }

        [DisplayName("اسم الشعبة")]
        public Guid? SectionId { get; set; }

        [DisplayName("استمرارية الخدمة")]
        public int Continuation { get; set; }

        [DisplayName("الحالة الوظيفية")]
        public string? EmploymentStatus { get; set; }

        [DisplayName("رقم كتاب المباشرة")]
        public string? InitiationBookNumber { get; set; }

        [DisplayName("تأريخ كتاب المباشرة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationBookDate { get; set; }

        [DisplayName("تأريخ المباشرة الفعلي في المكتب")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationAtOfficeBookDate { get; set; }

        [DisplayName("تأريخ انتهاء الخدمة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndOfServiceDate { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? CareerNotes { get; set; }

        [DisplayName("لديه بصمة الكترونية")]
        [DefaultValue(0)]
        public int? HasFingerprint { get; set; }

        [DisplayName("تأريخ تسجيل البصمة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FingerprintDate { get; set; }

        [DisplayName("Military")]
        [DefaultValue(1)]
        public int? Military { get; set; }

        [DisplayName("تفاصيل الجهة المكلف منها ")]
        public Guid? SideId { get; set; }

        [ForeignKey("SideId")]
        public virtual CommingFrom? CommingFrom { get; set; }
    }
}
