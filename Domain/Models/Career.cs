using System;
using Domain.Common.BaseEntities;
using Domain.Entities.Employees;

namespace Domain.Entities.Career
{
    /// <summary>
    /// يمثل السيرة الوظيفية للموظف
    /// //خلاصة الخدمة
    /// يسجل كل حركة أو تغيير تنظيمي أو وظيفي
    /// Snapshot كامل للهيكل الوظيفي وقت الحركة
    /// </summary>
    public class Career : Base<Guid>
    {
        // =====================================================
        // العلاقة مع الموظف
        // =====================================================

        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        // =====================================================
        // معلومات الحركة
        // =====================================================

        /// <summary>
        /// تاريخ الحركة الوظيفية
        /// </summary>
        public DateTime MovementDate { get; private set; }

        /// <summary>
        /// نوع الحركة (تعيين، نقل، ترفيع، إعادة توزيع...)
        /// </summary>
        public string MovementType { get; private set; }

        public string? Notes { get; private set; }

        // =====================================================
        // Snapshot الهيكل التنظيمي
        // =====================================================

        public string AuthorityName { get; private set; }
        public string? SubAuthorityName { get; private set; }

        public string DirectorateName { get; private set; }
        public string? SubDirectorateName { get; private set; }

        public string DepartmentName { get; private set; }
        public string SectionName { get; private set; }
        public string? UnitName { get; private set; }

        // =====================================================
        // Snapshot الوظيفة
        // =====================================================

        /// <summary>
        /// العنوان الوظيفي وقت الحركة
        /// </summary>
        public string JobTitle { get; private set; }

        /// <summary>
        /// اسم الدرجة الوظيفية
        /// </summary>
        public string GradeName { get; private set; }

        /// <summary>
        /// الراتب الاسمي وقت الحركة
        /// </summary>
        public decimal BasicSalary { get; private set; }

        private Career() { }

        // =====================================================
        // Constructor
        // =====================================================

        public Career(
            Guid employeeId,
            DateTime movementDate,
            string movementType,
            string authorityName,
            string directorateName,
            string departmentName,
            string sectionName,
            string jobTitle,
            string gradeName,
            decimal basicSalary,
            Guid userGuid,
            string? subAuthorityName = null,
            string? subDirectorateName = null,
            string? unitName = null,
            string? notes = null)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("رقم الموظف غير صالح.");

            if (movementDate == default)
                throw new ArgumentException("تاريخ الحركة مطلوب.");

            if (string.IsNullOrWhiteSpace(movementType))
                throw new ArgumentException("نوع الحركة مطلوب.");

            if (string.IsNullOrWhiteSpace(authorityName))
                throw new ArgumentException("اسم الجهة العليا مطلوب.");

            if (string.IsNullOrWhiteSpace(directorateName))
                throw new ArgumentException("اسم الدائرة مطلوب.");

            if (string.IsNullOrWhiteSpace(departmentName))
                throw new ArgumentException("اسم القسم مطلوب.");

            if (string.IsNullOrWhiteSpace(sectionName))
                throw new ArgumentException("اسم الشعبة مطلوب.");

            if (string.IsNullOrWhiteSpace(jobTitle))
                throw new ArgumentException("العنوان الوظيفي مطلوب.");

            if (string.IsNullOrWhiteSpace(gradeName))
                throw new ArgumentException("اسم الدرجة مطلوب.");

            if (basicSalary < 0)
                throw new ArgumentException("الراتب الاسمي غير صحيح.");

            EmployeeId = employeeId;

            MovementDate = movementDate;
            MovementType = movementType.Trim();
            Notes = notes?.Trim();

            AuthorityName = authorityName.Trim();
            SubAuthorityName = subAuthorityName?.Trim();

            DirectorateName = directorateName.Trim();
            SubDirectorateName = subDirectorateName?.Trim();

            DepartmentName = departmentName.Trim();
            SectionName = sectionName.Trim();
            UnitName = unitName?.Trim();

            JobTitle = jobTitle.Trim();
            GradeName = gradeName.Trim();
            BasicSalary = basicSalary;

            SetCreated(userGuid);
        }

        // =====================================================
        // تحديث الملاحظات فقط
        // =====================================================

        public void UpdateNotes(string? notes, Guid userGuid)
        {
            Notes = notes?.Trim();
            Touch(userGuid);
        }
    }
}