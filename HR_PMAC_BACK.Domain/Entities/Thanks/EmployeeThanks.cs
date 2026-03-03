using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;
using HR_PMAC_BACK.Domain.Entities.Employees;

namespace HR_PMAC_BACK.Domain.Entities.Thanks
{
    /// <summary>
    /// يمثل كتاب شكر ممنوح لموظف
    /// </summary>
    public class EmployeeThanks : Base<int>
    {
        // =====================================================
        // العلاقات
        // =====================================================

        /// <summary>
        /// رقم الموظف
        /// </summary>
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        /// <summary>
        /// نوع كتاب الشكر
        /// </summary>
        public int ThanksTypeId { get; private set; }
        public ThanksType ThanksType { get; private set; }

        // =====================================================
        // معلومات كتاب الشكر
        // =====================================================

        /// <summary>
        /// الجهة المانحة
        /// </summary>
        public string Donor { get; private set; }

        /// <summary>
        /// نوع الأمر (وزاري، إداري، ديواني...)
        /// </summary>
        public string OrderType { get; private set; }

        /// <summary>
        /// رقم الأمر
        /// </summary>
        public string OrderNumber { get; private set; }

        /// <summary>
        /// العدد
        /// </summary>
        public string? OrderReferenceNumber { get; private set; }

        /// <summary>
        /// تاريخ الأمر
        /// </summary>
        public DateTime? OrderDate { get; private set; }

        // =====================================================
        // تأثيره على الاستحقاق
        // =====================================================

        /// <summary>
        /// هل هذا الكتاب مؤثر حالياً؟
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// عدد الأيام المحتسبة فعلياً (Snapshot من النوع)
        /// </summary>
        public int AddedDaysSnapshot { get; private set; }

        // =====================================================
        // معلومات أمر القدم (إن وجد)
        // =====================================================

        public string? PreviousOrderNumber { get; private set; }
        public DateTime? PreviousOrderDate { get; private set; }

        // =====================================================
        // معلومات إضافية
        // =====================================================

        public string? Reason { get; private set; }
        public string? Notes { get; private set; }
        public string? AttachmentFilePath { get; private set; }

        private EmployeeThanks() { }

        public EmployeeThanks(
            Guid employeeId,
            int thanksTypeId,
            string donor,
            string orderType,
            string orderNumber,
            int addedDaysSnapshot,
            Guid userGuid)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("رقم الموظف غير صالح.");

            if (string.IsNullOrWhiteSpace(donor))
                throw new ArgumentException("الجهة المانحة مطلوبة.");

            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException("رقم الأمر مطلوب.");

            EmployeeId = employeeId;
            ThanksTypeId = thanksTypeId;

            Donor = donor.Trim();
            OrderType = orderType?.Trim();
            OrderNumber = orderNumber.Trim();
            AddedDaysSnapshot = addedDaysSnapshot;
            IsActive = true;

            SetCreated(userGuid);
        }

        public void UpdateDetails(
            DateTime? orderDate,
            string? orderReferenceNumber,
            string? previousOrderNumber,
            DateTime? previousOrderDate,
            string? reason,
            string? notes,
            string? attachmentFilePath,
            bool isActive,
            Guid userGuid)
        {
            OrderDate = orderDate;
            OrderReferenceNumber = orderReferenceNumber?.Trim();
            PreviousOrderNumber = previousOrderNumber?.Trim();
            PreviousOrderDate = previousOrderDate;
            Reason = reason?.Trim();
            Notes = notes?.Trim();
            AttachmentFilePath = attachmentFilePath;
            IsActive = isActive;

            Touch(userGuid);
        }
    }
}