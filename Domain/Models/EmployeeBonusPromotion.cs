using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;
using HR_PMAC_BACK.Domain.Entities.Employees;
using HR_PMAC_BACK.Domain.Entities.EmploymentStructure;
using HR_PMAC_BACK.Domain.Entities.EmployeeCertifications;
using HR_PMAC_BACK.Domain.Entities.BonusPromotions.Enums;

namespace HR_PMAC_BACK.Domain.Entities.BonusPromotions
{
    /// <summary>
    /// يمثل حركة علاوة أو ترفيع تخص موظف
    /// يحتوي على Snapshot للحالة السابقة والحالية
    /// </summary>
    public class EmployeeBonusPromotion : Base<int>
    {
        // =====================================================
        // العلاقات الأساسية
        // =====================================================

        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        public BonusPromotionType Type { get; private set; }

        public int? EmployeeCertificationId { get; private set; }
        public EmployeeCertification? EmployeeCertification { get; private set; }

        // =====================================================
        // معلومات القرار الإداري
        // =====================================================

        /// <summary>
        /// رقم القرار (علاوة / ترفيع)
        /// </summary>
        public string CommandNumber { get; private set; }

        /// <summary>
        /// تاريخ القرار
        /// </summary>
        public DateTime CommandDate { get; private set; }

        /// <summary>
        /// رقم الأمر الإداري
        /// </summary>
        public string BookNumber { get; private set; }

        public DateTime BookDate { get; private set; }

        /// <summary>
        /// مسار ملف الأمر الإداري (إجباري)
        /// </summary>
        public string BookFilePath { get; private set; }

        // =====================================================
        // Snapshot — الحالة السابقة
        // =====================================================

        public string PreviousGrade { get; private set; }
        public string PreviousStep { get; private set; }
        public decimal PreviousSalary { get; private set; }

        public Guid PreviousJobTitleId { get; private set; }
        public JobTitle PreviousJobTitle { get; private set; }
        public string PreviousJobTitleTitle { get; private set; }

        // تاريخ الاستحقاق السابق
        public DateTime? PreviousEntitlementDate { get; private set; }

        // =====================================================
        // Snapshot — الحالة الحالية
        // =====================================================

        public string CurrentGrade { get; private set; }
        public string CurrentStep { get; private set; }
        public decimal CurrentSalary { get; private set; }

        public Guid CurrentJobTitleId { get; private set; }
        public JobTitle CurrentJobTitle { get; private set; }
        public string CurrentJobTitleTitle { get; private set; }

        // تاريخ الاستحقاق الحالي
        public DateTime? CurrentEntitlementDate { get; private set; }

        // تاريخ الاستحقاق القادم
        public DateTime? NextEntitlementDate { get; private set; }

        // =====================================================
        // مسكن بالدرجة مالته
        // =====================================================

        /// <summary>
        /// هل الموظف مسكن على درجته حالياً
        /// </summary>
        public bool IsGradeFrozen { get; private set; }

        /// <summary>
        /// سبب التسكين
        /// </summary>
        public string? GradeFreezeReason { get; private set; }

        public DateTime? GradeFreezeStartDate { get; private set; }
        public DateTime? GradeFreezeEndDate { get; private set; }

        // =====================================================
        // الحالة الإدارية
        // =====================================================

        /// <summary>
        /// معلق العلاوة أو الترفيع مؤقتاً
        /// </summary>
        public bool IsSuspended { get; private set; }

        /// <summary>
        /// تاريخ بدء التعليق
        /// </summary>
        public DateTime? SuspensionStartDate { get; private set; }

        /// <summary>
        /// تاريخ انتهاء التعليق المؤقت
        /// </summary>
        public DateTime? SuspensionEndDate { get; private set; }
        //احتساب يدوي
        public bool IsManualCalculation { get; private set; }
        //عدد الايام المدورة
        public int? CycledDays { get; private set; }

        public string? Notes { get; private set; }

        private EmployeeBonusPromotion() { }

        // =====================================================
        // Constructor
        // =====================================================

        public EmployeeBonusPromotion(
            Guid employeeId,
            BonusPromotionType type,
            string commandNumber,
            DateTime commandDate,
            string bookNumber,
            DateTime bookDate,
            string bookFilePath,
            string previousGrade,
            string previousStep,
            decimal previousSalary,
            Guid previousJobTitleId,
            string previousJobTitleTitle,
            string currentGrade,
            string currentStep,
            decimal currentSalary,
            Guid currentJobTitleId,
            string currentJobTitleTitle,
            int? employeeCertificationId,
            Guid userGuid)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("رقم الموظف غير صالح.");

            if (!Enum.IsDefined(typeof(BonusPromotionType), type))
                throw new ArgumentException("نوع الحركة غير صالح.");

            if (string.IsNullOrWhiteSpace(commandNumber))
                throw new ArgumentException("رقم القرار مطلوب.");

            if (string.IsNullOrWhiteSpace(bookNumber))
                throw new ArgumentException("رقم الأمر الإداري مطلوب.");

            if (string.IsNullOrWhiteSpace(bookFilePath))
                throw new ArgumentException("ملف الأمر الإداري مطلوب.");

            if (previousSalary < 0 || currentSalary < 0)
                throw new ArgumentException("قيمة الراتب غير صحيحة.");

            EmployeeId = employeeId;
            Type = type;

            CommandNumber = commandNumber.Trim();
            CommandDate = commandDate;

            BookNumber = bookNumber.Trim();
            BookDate = bookDate;
            BookFilePath = bookFilePath.Trim();

            // الحالة السابقة
            PreviousGrade = previousGrade;
            PreviousStep = previousStep;
            PreviousSalary = previousSalary;
            PreviousJobTitleId = previousJobTitleId;
            PreviousJobTitleTitle = previousJobTitleTitle;

            // الحالة الحالية
            CurrentGrade = currentGrade;
            CurrentStep = currentStep;
            CurrentSalary = currentSalary;
            CurrentJobTitleId = currentJobTitleId;
            CurrentJobTitleTitle = currentJobTitleTitle;

            EmployeeCertificationId = employeeCertificationId;

            SetCreated(userGuid);
        }

        // =====================================================
        // تحديث تاريخ الاستحقاق القادم
        // =====================================================

        public void SetNextEntitlementDate(DateTime nextDate, Guid userGuid)
        {
            NextEntitlementDate = nextDate;
            Touch(userGuid);
        }

        // =====================================================
        // إدارة التسكين
        // =====================================================

        public void FreezeGrade(string reason, DateTime startDate, DateTime? endDate, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("سبب التسكين مطلوب.");

            IsGradeFrozen = true;
            GradeFreezeReason = reason.Trim();
            GradeFreezeStartDate = startDate;
            GradeFreezeEndDate = endDate;

            Touch(userGuid);
        }

        public void UnfreezeGrade(Guid userGuid)
        {
            IsGradeFrozen = false;
            GradeFreezeReason = null;
            GradeFreezeStartDate = null;
            GradeFreezeEndDate = null;

            Touch(userGuid);
        }

        // =====================================================
        // إدارة التعليق المؤقت
        // =====================================================

        public void Suspend(DateTime startDate, DateTime? endDate, Guid userGuid)
        {
            IsSuspended = true;
            SuspensionStartDate = startDate;
            SuspensionEndDate = endDate;

            Touch(userGuid);
        }

        public void Activate(Guid userGuid)
        {
            IsSuspended = false;
            SuspensionStartDate = null;
            SuspensionEndDate = null;

            Touch(userGuid);
        }

        // =====================================================
        // إعدادات إضافية
        // =====================================================

        public void SetManualCalculation(bool isManual, Guid userGuid)
        {
            IsManualCalculation = isManual;
            Touch(userGuid);
        }

        public void SetCycledDays(int? days, Guid userGuid)
        {
            CycledDays = days;
            Touch(userGuid);
        }

        public void AddNotes(string? notes, Guid userGuid)
        {
            Notes = notes?.Trim();
            Touch(userGuid);
        }
    }
}