using System;
using Domain.Common.BaseEntities;
using Domain.Entities.Employees;

namespace Domain.Entities.Rewards
{
    /// <summary>
    /// يمثل مكافأة مالية ممنوحة لموظف
    /// </summary>
    public class EmployeeReward : Base<Guid>
    {
        // =====================================================
        // العلاقات
        // =====================================================

        /// <summary>
        /// رقم الموظف
        /// </summary>
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        // =====================================================
        // معلومات المكافأة
        // =====================================================

        /// <summary>
        /// الجهة المانحة
        /// </summary>
        public string RewardGiver { get; private set; }

        /// <summary>
        /// مبلغ المكافأة بالدينار العراقي
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// سبب منح المكافأة
        /// </summary>
        public string Reason { get; private set; }

        /// <summary>
        /// نوع الأمر الإداري
        /// </summary>
        public string OrderType { get; private set; }

        /// <summary>
        /// رقم الأمر الإداري
        /// </summary>
        public string OrderNumber { get; private set; }

        /// <summary>
        /// تاريخ الأمر الإداري
        /// </summary>
        public DateTime? OrderDate { get; private set; }

        /// <summary>
        /// مسار ملف المرفق (إن وجد)
        /// </summary>
        public string? RewardFilePath { get; private set; }

        /// <summary>
        /// سنة الاحتساب (مهمة للتحقق من الحد السنوي)
        /// </summary>
        public int Year { get; private set; }

        public string? Notes { get; private set; }

        private EmployeeReward() { }

        public EmployeeReward(
            Guid employeeId,
            string rewardGiver,
            decimal amount,
            string reason,
            string orderType,
            string orderNumber,
            int year,
            Guid userGuid)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("رقم الموظف غير صالح.");

            if (amount <= 0)
                throw new ArgumentException("مبلغ المكافأة يجب أن يكون أكبر من صفر.");

            if (year < 2000)
                throw new ArgumentException("سنة غير صالحة.");

            EmployeeId = employeeId;
            RewardGiver = rewardGiver?.Trim();
            Amount = amount;
            Reason = reason?.Trim();
            OrderType = orderType?.Trim();
            OrderNumber = orderNumber?.Trim();
            Year = year;

            SetCreated(userGuid);
        }

        public void UpdateDetails(
            DateTime? orderDate,
            string? rewardFilePath,
            string? notes,
            Guid userGuid)
        {
            OrderDate = orderDate;
            RewardFilePath = rewardFilePath;
            Notes = notes?.Trim();

            Touch(userGuid);
        }
    }
}