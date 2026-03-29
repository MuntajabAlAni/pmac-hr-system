using System;
using Domain.Common.BaseEntities;
using Domain.Entities.Employees;

namespace Domain.Entities.EmploymentHistory
{
    /// <summary>
    /// يمثل خدمة مضافة لموظف يتم احتسابها ضمن الخدمة الفعلية
    /// ولا يمكن اعتمادها بدون مستند رسمي مرفق
    /// </summary>
    public class EmployeeAddedService : Base<Guid>
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
        /// نوع الخدمة المضافة
        /// </summary>
        public Guid AddedServiceTypeId { get; private set; }
        public AddedServiceType AddedServiceType { get; private set; }

        // =====================================================
        // معلومات الأمر الإداري
        // =====================================================

        /// <summary>
        /// رقم الأمر الإداري
        /// </summary>
        public string OrderNumber { get; private set; }

        /// <summary>
        /// العدد / رقم الكتاب
        /// </summary>
        public string? BookNumber { get; private set; }

        /// <summary>
        /// تاريخ الأمر الإداري
        /// </summary>
        public DateTime? OrderDate { get; private set; }

        // =====================================================
        // فترة الخدمة المضافة
        // =====================================================

        /// <summary>
        /// من تاريخ
        /// </summary>
        public DateTime? FromDate { get; private set; }

        /// <summary>
        /// إلى تاريخ
        /// </summary>
        public DateTime? ToDate { get; private set; }

        /// <summary>
        /// مجموع الأيام المحتسبة
        /// </summary>
        public int TotalDays { get; private set; }

        /// <summary>
        /// عدد السنوات المحتسبة
        /// </summary>
        public int Years { get; private set; }

        /// <summary>
        /// عدد الأشهر المحتسبة
        /// </summary>
        public int Months { get; private set; }

        /// <summary>
        /// عدد الأيام المحتسبة
        /// </summary>
        public int Days { get; private set; }

        // =====================================================
        // الحالة الإدارية
        // =====================================================

        /// <summary>
        /// هل الخدمة فعالة حالياً ضمن الاستحقاق؟
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// ملاحظات إضافية
        /// </summary>
        public string? Notes { get; private set; }

        /// <summary>
        /// مسار ملف المرفق الرسمي (إلزامي)
        /// </summary>
        public string EmployeeAddedServiceFilePath { get; private set; }

        private EmployeeAddedService() { }

        /// <summary>
        /// إنشاء خدمة مضافة جديدة
        /// لا يمكن إنشاء الخدمة بدون ملف رسمي
        /// </summary>
        public EmployeeAddedService(
            Guid employeeId,
            Guid addedServiceTypeId,
            string orderNumber,
            string employeeAddedServiceFilePath,
            int totalDays,
            int years,
            int months,
            int days,
            Guid userGuid)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("رقم الموظف غير صالح.");

            if (addedServiceTypeId == Guid.Empty)
                throw new ArgumentException("نوع الخدمة غير صالح.");

            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException("رقم الأمر الإداري مطلوب.");

            if (string.IsNullOrWhiteSpace(employeeAddedServiceFilePath))
                throw new ArgumentException("يجب إرفاق مستند رسمي لإضافة الخدمة.");

            if (totalDays < 0 || years < 0 || months < 0 || days < 0)
                throw new ArgumentException("قيم مدد الخدمة غير صالحة.");

            EmployeeId = employeeId;
            AddedServiceTypeId = addedServiceTypeId;
            OrderNumber = orderNumber.Trim();
            EmployeeAddedServiceFilePath = employeeAddedServiceFilePath.Trim();

            TotalDays = totalDays;
            Years = years;
            Months = months;
            Days = days;

            IsActive = true;

            SetCreated(userGuid);
        }

        /// <summary>
        /// تحديث تفاصيل الخدمة المضافة
        /// </summary>
        public void UpdateDetails(
            DateTime? orderDate,
            string? bookNumber,
            DateTime? fromDate,
            DateTime? toDate,
            bool isActive,
            string? notes,
            Guid userGuid)
        {
            OrderDate = orderDate;
            BookNumber = bookNumber?.Trim();
            FromDate = fromDate;
            ToDate = toDate;
            IsActive = isActive;
            Notes = notes?.Trim();

            Touch(userGuid);
        }

        /// <summary>
        /// تحديث أو استبدال ملف المرفق
        /// </summary>
        public void UpdateAttachment(string newFilePath, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(newFilePath))
                throw new ArgumentException("مسار الملف غير صالح.");

            EmployeeAddedServiceFilePath = newFilePath.Trim();
            Touch(userGuid);
        }

        /// <summary>
        /// تعطيل الخدمة المضافة
        /// </summary>
        public void Deactivate(Guid userGuid)
        {
            IsActive = false;
            Touch(userGuid);
        }
    }
}