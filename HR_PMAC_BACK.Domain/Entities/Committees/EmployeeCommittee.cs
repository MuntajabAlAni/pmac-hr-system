using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;
using HR_PMAC_BACK.Domain.Entities.Employees;

namespace HR_PMAC_BACK.Domain.Entities.Committees
{
    /// <summary>
    /// يمثل اشتراك موظف في لجنة
    /// لا يرتبط بجدول الأوامر الإدارية
    /// ويحتوي على رقم وتاريخ الكتاب الرسمي
    /// ولا يمكن إنشاء لجنة بدون ملف رسمي مرفق
    /// </summary>
    public class EmployeeCommittee : Base<int>
    {
        // =====================================================
        // العلاقات
        // =====================================================

        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        public int CommitteeTypeId { get; private set; }
        public CommitteeType CommitteeType { get; private set; }

        // =====================================================
        // بيانات الكتاب الرسمي
        // =====================================================

        /// <summary>
        /// رقم الكتاب الرسمي
        /// </summary>
        public string BookNumber { get; private set; }

        /// <summary>
        /// تاريخ الكتاب الرسمي
        /// </summary>
        public DateTime BookDate { get; private set; }

        // =====================================================
        // ملف اللجنة (إلزامي)
        // =====================================================

        /// <summary>
        /// مسار ملف قرار اللجنة الرسمي
        /// </summary>
        public string CommitteeFilePath { get; private set; }

        // =====================================================
        // مدة اللجنة
        // =====================================================

        /// <summary>
        /// نوع مدة اللجنة (مؤقتة / دائمة)
        /// </summary>
        public string DurationType { get; private set; }

        /// <summary>
        /// من تاريخ
        /// </summary>
        public DateTime? FromDate { get; private set; }

        /// <summary>
        /// إلى تاريخ
        /// </summary>
        public DateTime? ToDate { get; private set; }

        /// <summary>
        /// هل اللجنة فعالة حالياً؟
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// ملاحظات إضافية
        /// </summary>
        public string? Notes { get; private set; }

        private EmployeeCommittee() { }

        // =====================================================
        // Constructor
        // =====================================================

        public EmployeeCommittee(
            Guid employeeId,
            int committeeTypeId,
            string bookNumber,
            DateTime bookDate,
            string durationType,
            string committeeFilePath,
            Guid userGuid)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("رقم الموظف غير صالح.");

            if (committeeTypeId <= 0)
                throw new ArgumentException("نوع اللجنة غير صالح.");

            if (string.IsNullOrWhiteSpace(bookNumber))
                throw new ArgumentException("رقم الكتاب مطلوب.");

            if (bookDate == default)
                throw new ArgumentException("تاريخ الكتاب غير صالح.");

            if (string.IsNullOrWhiteSpace(durationType))
                throw new ArgumentException("نوع مدة اللجنة مطلوب.");

            if (string.IsNullOrWhiteSpace(committeeFilePath))
                throw new ArgumentException("يجب إرفاق ملف قرار اللجنة.");

            EmployeeId = employeeId;
            CommitteeTypeId = committeeTypeId;

            BookNumber = bookNumber.Trim();
            BookDate = bookDate;

            DurationType = durationType.Trim();
            CommitteeFilePath = committeeFilePath.Trim();

            IsActive = true;

            SetCreated(userGuid);
        }

        // =====================================================
        // Business Methods
        // =====================================================

        public void UpdateDetails(
            DateTime? fromDate,
            DateTime? toDate,
            bool isActive,
            string? notes,
            Guid userGuid)
        {
            FromDate = fromDate;
            ToDate = toDate;
            IsActive = isActive;
            Notes = notes?.Trim();

            Touch(userGuid);
        }

        public void UpdateBookInfo(
            string bookNumber,
            DateTime bookDate,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(bookNumber))
                throw new ArgumentException("رقم الكتاب مطلوب.");

            if (bookDate == default)
                throw new ArgumentException("تاريخ الكتاب غير صالح.");

            BookNumber = bookNumber.Trim();
            BookDate = bookDate;

            Touch(userGuid);
        }

        public void UpdateAttachment(string newFilePath, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(newFilePath))
                throw new ArgumentException("مسار ملف اللجنة غير صالح.");

            CommitteeFilePath = newFilePath.Trim();
            Touch(userGuid);
        }

        public void Deactivate(Guid userGuid)
        {
            IsActive = false;
            Touch(userGuid);
        }
    }
}