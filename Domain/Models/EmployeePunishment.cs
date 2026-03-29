using System;
using Domain.Common.BaseEntities;
using Domain.Entities.Employees;

namespace Domain.Entities.Punishments
{
    /// <summary>
    /// يمثل عقوبة ممنوحة لموظف
    /// </summary>
    public class EmployeePunishment : Base<Guid>
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
        /// نوع العقوبة
        /// </summary>
        public Guid PunishmentTypeId { get; private set; }
        public PunishmentType PunishmentType { get; private set; }

        // =====================================================
        // معلومات العقوبة
        // =====================================================

        /// <summary>
        /// جهة إصدار العقوبة
        /// </summary>
        public string Issuer { get; private set; }

        /// <summary>
        /// رقم الأمر الإداري
        /// </summary>
        public string OrderNumber { get; private set; }

        /// <summary>
        /// تاريخ الأمر الإداري
        /// </summary>
        public DateTime? OrderDate { get; private set; }

        /// <summary>
        /// سبب العقوبة
        /// </summary>
        public string? Reason { get; private set; }

        /// <summary>
        /// عدد الأيام المحرومة فعلياً (Snapshot من نوع العقوبة)
        /// </summary>
        public int DeductedDaysSnapshot { get; private set; }

        /// <summary>
        /// هل العقوبة فعالة حالياً؟
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// ملف مرفق (إن وجد)
        /// </summary>
        public string? PunishmentFilePath { get; private set; }

        // =====================================================
        // ملاحظات إضافية
        // =====================================================

        /// <summary>
        /// ملاحظات إضافية تخص العقوبة
        /// </summary>
        public string? Notes { get; private set; }

        private EmployeePunishment() { }

        public EmployeePunishment(
            Guid employeeId,
            Guid punishmentTypeId,
            string issuer,
            string orderNumber,
            int deductedDaysSnapshot,
            Guid userGuid)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("رقم الموظف غير صالح.");

            if (string.IsNullOrWhiteSpace(issuer))
                throw new ArgumentException("جهة الإصدار مطلوبة.");

            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException("رقم الأمر مطلوب.");

            EmployeeId = employeeId;
            PunishmentTypeId = punishmentTypeId;
            Issuer = issuer.Trim();
            OrderNumber = orderNumber.Trim();
            DeductedDaysSnapshot = deductedDaysSnapshot;
            IsActive = true;

            SetCreated(userGuid);
        }

        /// <summary>
        /// تحديث تفاصيل العقوبة
        /// </summary>
        public void UpdateDetails(
            DateTime? orderDate,
            string? reason,
            string? punishmentFilePath,
            bool isActive,
            string? notes,
            Guid userGuid)
        {
            OrderDate = orderDate;
            Reason = reason?.Trim();
            PunishmentFilePath = punishmentFilePath;
            IsActive = isActive;
            Notes = notes?.Trim();

            Touch(userGuid);
        }
    }
}