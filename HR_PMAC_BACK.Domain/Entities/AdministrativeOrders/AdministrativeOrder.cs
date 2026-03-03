using System;
using System.Collections.Generic;
using HR_PMAC_BACK.Domain.Common.BaseEntities;
using HR_PMAC_BACK.Domain.Entities.Employees;

namespace HR_PMAC_BACK.Domain.Entities.AdministrativeOrders
{
    /// <summary>
    /// يمثل أمر إداري رسمي في النظام
    /// يمكن أن يرتبط بلجنة، مكافأة، عقوبة، خدمة مضافة...
    /// </summary>
    public class AdministrativeOrder : Base<int>
    {
        // =====================================================
        // العلاقات
        // =====================================================

        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        public int AdministrativeOrderTypeId { get; private set; }
        public AdministrativeOrderType AdministrativeOrderType { get; private set; }

        // =====================================================
        // بيانات الأمر
        // =====================================================

        /// <summary>
        /// رقم الأمر
        /// </summary>
        public string OrderNumber { get; private set; }

        /// <summary>
        /// العدد
        /// </summary>
        public string? BookNumber { get; private set; }

        /// <summary>
        /// تاريخ الأمر
        /// </summary>
        public DateTime? OrderDate { get; private set; }

        /// <summary>
        /// موضوع الأمر
        /// </summary>
        public string? Subject { get; private set; }

        /// <summary>
        /// تاريخ المباشرة أو الانفكاك
        /// </summary>
        public DateTime? DirectDate { get; private set; }

        /// <summary>
        /// ملاحظات
        /// </summary>
        public string? Notes { get; private set; }

        /// <summary>
        /// ملف الأمر الرسمي
        /// </summary>
        public string FilePath { get; private set; }

        private AdministrativeOrder() { }

        public AdministrativeOrder(
            Guid employeeId,
            int administrativeOrderTypeId,
            string orderNumber,
            string filePath,
            Guid userGuid)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("رقم الموظف غير صالح.");

            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException("رقم الأمر مطلوب.");

            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("ملف الأمر مطلوب.");

            EmployeeId = employeeId;
            AdministrativeOrderTypeId = administrativeOrderTypeId;
            OrderNumber = orderNumber.Trim();
            FilePath = filePath.Trim();

            SetCreated(userGuid);
        }

        public void UpdateDetails(
            string? bookNumber,
            DateTime? orderDate,
            string? subject,
            DateTime? directDate,
            string? notes,
            Guid userGuid)
        {
            BookNumber = bookNumber?.Trim();
            OrderDate = orderDate;
            Subject = subject?.Trim();
            DirectDate = directDate;
            Notes = notes?.Trim();

            Touch(userGuid);
        }
    }
}