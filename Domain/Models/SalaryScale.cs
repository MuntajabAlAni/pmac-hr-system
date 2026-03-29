using System;
using Domain.Common.BaseEntities;

namespace Domain.Entities.EmploymentStructure
{
    /// <summary>
    /// يمثل سلم الرواتب المرتبط بدرجة وظيفية
    /// كل سلم راتب يجب أن يكون مرتبطاً بدرجة (إجباري)
    /// </summary>
    public class SalaryScale : Base<Guid>
    {
        // ======================================================
        // العلاقة الإلزامية مع الدرجة
        // ======================================================

        /// <summary>
        /// معرف الدرجة الوظيفية (إجباري)
        /// </summary>
        public Guid GradeId { get; private set; }

        /// <summary>
        /// Navigation Property للدرجة
        /// </summary>
        public Grade Grade { get; private set; }

        // ======================================================
        // بيانات سلم الراتب
        // ======================================================

        /// <summary>
        /// رقم المرحلة داخل الدرجة
        /// </summary>
        public int Step { get; private set; }

        /// <summary>
        /// الراتب الاساسي
        /// </summary>
        public decimal BasicSalary { get; private set; }

        private SalaryScale() { }

        // ======================================================
        // Constructor
        // ======================================================

        public SalaryScale(
            Guid gradeId,
            int step,
            decimal basicSalary,
            Guid userGuid)
        {
            if (gradeId == Guid.Empty)
                throw new ArgumentException("معرف الدرجة غير صالح.");

            if (step <= 0)
                throw new ArgumentException("رقم المرحلة يجب أن يكون أكبر من صفر.");

            if (basicSalary < 0)
                throw new ArgumentException("الراتب الأساسي لا يمكن أن يكون سالباً.");

            GradeId = gradeId;
            Step = step;
            BasicSalary = basicSalary;

            SetCreated(userGuid);
        }

        // ======================================================
        // تعديل الراتب
        // ======================================================

        public void UpdateSalary(decimal basicSalary, Guid userGuid)
        {
            if (basicSalary < 0)
                throw new ArgumentException("الراتب الأساسي لا يمكن أن يكون سالباً.");

            BasicSalary = basicSalary;
            Touch(userGuid);
        }

        // ======================================================
        // تغيير المرحلة
        // ======================================================

        public void ChangeStep(int step, Guid userGuid)
        {
            if (step <= 0)
                throw new ArgumentException("رقم المرحلة يجب أن يكون أكبر من صفر.");

            Step = step;
            Touch(userGuid);
        }

        // ======================================================
        // تغيير الدرجة (اختياري إذا أردت السماح بذلك)
        // ======================================================

        public void ChangeGrade(Guid gradeId, Guid userGuid)
        {
            if (gradeId == Guid.Empty)
                throw new ArgumentException("معرف الدرجة غير صالح.");

            GradeId = gradeId;
            Touch(userGuid);
        }
    }
}