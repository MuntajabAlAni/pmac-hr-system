using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Models
{
    public class Career
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }



        //------------------------------------------------Career info

        [DisplayName("رقم الموظف الوطني")]
        public string? EmployeeNationalNumber { get; set; }

        [DisplayName("اسم الدائرة")]
        public Guid? DirectorateId { get; set; }

        [DisplayName("اسم القسم")]
        public Guid? DepartmentId { get; set; }

        [DisplayName("اسم الشعبة")]
        public Guid? SectionId { get; set; }

        [DisplayName("استمرارية الخدمة")]
        public Guid? ContinuationId { get; set; }

        [DisplayName("التحصيل الدراسي")]
        public string? Education { get; set; }

        [DisplayName("العنوان الوظيفي")]
        public Guid? JobTitleId { get; set; }

        [DisplayName("الدرجة الوظيفية")]
        public Guid? GradeId { get; set; }

        [DisplayName("المرحلة")]
        public Guid? StepId { get; set; }

        [DisplayName("الحالة الوظيفية")]
        public string? EmploymentStatus { get; set; }

        [DisplayName("المنصب")]
        public Guid? PositionId { get; set; }

        [DisplayName("تأريخ اخر ترفيع")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastPromotionDate { get; set; }

        [DisplayName("تأريخ أخر علاوة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastRaiseDate { get; set; }

        [DisplayName("تأريخ الاستحقاق القادم")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NextRaiseDate { get; set; }

        [DisplayName("Dead_Line_Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeadLineDate { get; set; }

        [DisplayName("No_Deserver_Months")]
        [DefaultValue(0)]
        public int NoDeserverMonths { get; set; }

        [DisplayName("No_Deserved_Thanks")]
        [DefaultValue(0)]
        public int NoDeservedThanks { get; set; }

        [DisplayName("الراتب الاسمي")]
        public string? BasicSalary { get; set; }

        [DisplayName("دائرة المستشارين")]
        public string? ConsultantAgency { get; set; }

        [DisplayName("نوع العمل")]
        public Guid? WorkCareerTypeId { get; set; }

        [DisplayName("المهام")]
        [DataType(DataType.MultilineText)]
        public string? WorkType { get; set; }

        [DisplayName("ملاحظات خلاصة الخدمة")]
        [DataType(DataType.MultilineText)]
        public string? CareerNotes { get; set; }


        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? ServiceSummaryNotes { get; set; }

        //------------------------------------------------Assignment info

        [DisplayName("رقم كتاب التعيين")]
        public string? AssignBookNumber { get; set; }

        [DisplayName("تاريخ كتاب التعيين")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AssignBookDate { get; set; }

        [DisplayName("رقم كتاب المباشرة")]
        public string? InitiationBookNumber { get; set; }

        [DisplayName("تأريخ كتاب المباشرة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationBookDate { get; set; }

        [DisplayName("تأريخ المباشرة الفعلي")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationActualDate { get; set; }

        [DisplayName("رقم كتاب المباشرة في المكتب")]
        public string? InitiationAtOfficeBookNumber { get; set; }

        [DisplayName("تأريخ كتاب المباشرة في المكتب")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationAtOfficeBookDate { get; set; }

        [DisplayName("هل لديك خدمة مضافة")]
        public string? AdditionalService { get; set; }

        [DisplayName("من ذوي الشهداء")]
        public string? MartyreRelated { get; set; }

        [DisplayName("سجين سياسي")]
        public string? PoliticalPrisoner { get; set; }

        [DisplayName("فصل سياسي")]
        public string? PoliticalIsolation { get; set; }

        [DisplayName("تأريخ انتهاء الخدمة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndOfServiceDate { get; set; }

        [DisplayName("هل الموظف تارك للعمل سابقا")]
        public string? HasLeftEarlier { get; set; }

        [DisplayName("هل الموظف منقول")]
        public string? Transferred { get; set; }

        [DisplayName("رقم كتاب الحذف")]
        public string? DeletionBookNumber { get; set; }

        [DisplayName("رقم كتاب الاستحداث")]
        public string? UpdateBookNumber { get; set; }

        [DisplayName("الدائرة السابقة")]
        public string? PreviousDirectorate { get; set; }

        [DisplayName("رصيد الاعتيادية المدور")]
        public string? NormalVacationCredit { get; set; }

        [DisplayName("رصيد المرضية المدور")]
        public string? IllnessVacationCredit { get; set; }

        //-------------

        [DisplayName("الرصيد النهائي للاعتيادية")]
        [DefaultValue("0")]
        public string? OrdinaryFinalTotal { get; set; }

        [DisplayName("الرصيد النهائي للمرضية")]
        [DefaultValue("0")]
        public string? IllnessFinalTotal { get; set; }

        [DisplayName("no_sal_vac")]
        [DefaultValue("0")]
        public string? NoSalaryVacation { get; set; }

        [DisplayName("Other_vacs")]
        [DefaultValue("0")]
        public string? OtherVacations { get; set; }

        [DisplayName("illness_vacs_consumed")]
        [DefaultValue("0")]
        public string? IllnessVacationsConsumed { get; set; }

        [DisplayName("ordinary_vacs_consumed")]
        [DefaultValue("0")]
        public string? OrdinaryVacationsConsumed { get; set; }

        //-----------------

        [DisplayName("هل تم تدقيق البيانات؟")]
        public string? DataValidated { get; set; }

        //------------------------------------------------Certificate info

        [DisplayName("الجهة المانحة")]
        public Guid? CertificatePublisherId { get; set; }

        [DisplayName("التخصص")]
        [DefaultValue("لم يذكر")]
        public string? Major { get; set; }

        [DisplayName("سنة التخرج")]
        public string? YearOfGraduate { get; set; }

        [DisplayName("رقم صحة الصدور")]
        public string? ApproveCertificateNumber { get; set; }

        [DisplayName("تأريخ صحة الصدور")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ApproveCertificateDate { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string? FilePath { get; set; }

        [DisplayName("years")]
        [DefaultValue(0)]
        public int? Years { get; set; }

        [DisplayName("months")]
        [DefaultValue(0)]
        public int? Months { get; set; }

        [DisplayName("days")]
        [DefaultValue(0)]
        public int? Days { get; set; }

        [DisplayName("الاستحقاق القادم (علاوة/ ترفيع)")]
        public string? NextRaisePromotion { get; set; }

        //--------------------------Relationships----------------------------------------
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        [ForeignKey("JobTitleId")]
        public virtual JobTitle? JobTitle { get; set; }

        [ForeignKey("PositionId")]
        public virtual Position? Position { get; set; }

        [ForeignKey("DirectorateId")]
        public virtual Directorate? Directorate { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section? Section { get; set; }

        [DisplayName("الرتبة ")]
        public Guid? RankId { get; set; }

        [ForeignKey("RankId")]
        public virtual Rank? Rank { get; set; }

        [DisplayName("الجهة المكلف منها ")]
        public Guid? SideId { get; set; }

        [ForeignKey("SideId")]
        public virtual CommingFrom? CommingFrom { get; set; }

        [DisplayName("لديه بصمة الكترونية")]
        [DefaultValue(0)]
        public int? HasFingerprint { get; set; }

        [DisplayName("تأريخ تسجيل البصمة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FingerprintDate { get; set; }

        //------------------
        [DisplayName("مصادقة وزارة المالية")]
        public string? MinistryFinanceApproval { get; set; }

        [DisplayName("نوع المصادقة")]
        public string? ApprovalType { get; set; }

        //-----------------

        [DisplayName("حالة الاستثناء")]
        public Guid? ExceptionTypeId { get; set; }

        [ForeignKey("ExceptionTypeId")]
        public virtual FingerPrintExceptionType? FingerPrintExceptionType { get; set; }

        [ForeignKey("ContinuationId")]
        public virtual ServiceContinuation? ServiceContinuation { get; set; }

        [ForeignKey("GradeId")]
        public virtual Grade? Grade { get; set; }

        [ForeignKey("StepId")]
        public virtual Step? Step { get; set; }

        [ForeignKey("WorkCareerTypeId")]
        public virtual WorkCareerType? WorkCareerType { get; set; }

        //[ForeignKey("CertificatePublisherId")]
        //public virtual CertificatePublisher? CertificatePublisher { get; set; }
    }
}
