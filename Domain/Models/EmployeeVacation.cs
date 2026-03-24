using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;
using HR_PMAC_BACK.Domain.Entities.Employees;

namespace HR_PMAC_BACK.Domain.Entities.Vacations
{
    /// <summary>
    /// يمثل إجازة ممنوحة لموظف
    /// </summary>
    public class EmployeeVacation : Base<int>
    {
        // =====================================================
        // العلاقات
        // =====================================================

        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        public int VacationTypeId { get; private set; }
        public VacationType VacationType { get; private set; }

        // =====================================================
        // معلومات الأمر الإداري
        // =====================================================

        public string OrderNumber { get; private set; }
        public DateTime? OrderDate { get; private set; }

        // =====================================================
        // مدة الإجازة
        // =====================================================

        /// <summary>
        /// عدد السنوات براتب
        /// </summary>
        public int PaidYears { get; private set; }

        /// <summary>
        /// عدد الأشهر براتب
        /// </summary>
        public int PaidMonths { get; private set; }

        /// <summary>
        /// عدد الأيام براتب
        /// </summary>
        public int PaidDays { get; private set; }

        /// <summary>
        /// عدد السنوات بدون راتب
        /// </summary>
        public int UnpaidYears { get; private set; }

        /// <summary>
        /// عدد الأشهر بدون راتب
        /// </summary>
        public int UnpaidMonths { get; private set; }

        /// <summary>
        /// عدد الأيام بدون راتب
        /// </summary>
        public int UnpaidDays { get; private set; }

        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        // =====================================================
        // المباشرة
        // =====================================================

        public string? ReturnOrderNumber { get; private set; }
        public DateTime? ReturnOrderDate { get; private set; }

        // =====================================================
        // معلومات إضافية
        // =====================================================

        public bool IsActive { get; private set; }

        public string? Notes { get; private set; }

        /// <summary>
        /// ملف أمر الإجازة (إلزامي)
        /// </summary>
        public string VacationFilePath { get; private set; }

        private EmployeeVacation() { }

        public EmployeeVacation(
            Guid employeeId,
            int vacationTypeId,
            string orderNumber,
            string vacationFilePath,
            Guid userGuid)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("رقم الموظف غير صالح.");

            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException("رقم الأمر الإداري مطلوب.");

            if (string.IsNullOrWhiteSpace(vacationFilePath))
                throw new ArgumentException("ملف الإجازة مطلوب.");

            EmployeeId = employeeId;
            VacationTypeId = vacationTypeId;
            OrderNumber = orderNumber.Trim();
            VacationFilePath = vacationFilePath.Trim();
            IsActive = true;

            SetCreated(userGuid);
        }

        public void UpdateDetails(
            DateTime? orderDate,
            int paidYears,
            int paidMonths,
            int paidDays,
            int unpaidYears,
            int unpaidMonths,
            int unpaidDays,
            DateTime? startDate,
            DateTime? endDate,
            string? returnOrderNumber,
            DateTime? returnOrderDate,
            string? notes,
            bool isActive,
            Guid userGuid)
        {
            if (startDate.HasValue && endDate.HasValue && endDate < startDate)
                throw new ArgumentException("تاريخ انتهاء الإجازة لا يمكن أن يكون قبل تاريخ البدء.");

            OrderDate = orderDate;

            PaidYears = paidYears;
            PaidMonths = paidMonths;
            PaidDays = paidDays;

            UnpaidYears = unpaidYears;
            UnpaidMonths = unpaidMonths;
            UnpaidDays = unpaidDays;

            StartDate = startDate;
            EndDate = endDate;

            ReturnOrderNumber = returnOrderNumber?.Trim();
            ReturnOrderDate = returnOrderDate;
            Notes = notes?.Trim();
            IsActive = isActive;

            Touch(userGuid);
        }

        public void UpdateAttachment(string newFilePath, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(newFilePath))
                throw new ArgumentException("مسار الملف غير صالح.");

            VacationFilePath = newFilePath.Trim();
            Touch(userGuid);
        }
    }
}