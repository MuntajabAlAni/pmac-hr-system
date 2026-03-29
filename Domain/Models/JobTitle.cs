using System;
using Domain.Common.BaseEntities;
using Domain.Entities.EmploymentStructure.Enums;

namespace Domain.Entities.EmploymentStructure
{
    /// <summary>
    /// يمثل العنوان الوظيفي
    /// كل عنوان يجب أن يكون مرتبط بدرجة وظيفية (إجباري)
    /// </summary>
    public class JobTitle : Base<Guid>
    {
        /// <summary>
        /// اسم العنوان الوظيفي
        /// </summary>
        public string Title { get; private set; }

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
        // نوع العنوان الوظيفي
        // ======================================================

        /// <summary>
        /// تصنيف العنوان (رؤساء – وزراء – أطباء – ...)
        /// </summary>
        public JobTitleType JobTitleType { get; private set; }

        private JobTitle() { }

        // ======================================================
        // Constructor
        // ======================================================

        public JobTitle(
            string title,
            Guid gradeId,
            JobTitleType jobTitleType,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("اسم العنوان الوظيفي لا يمكن أن يكون فارغاً.");

            if (gradeId == Guid.Empty)
                throw new ArgumentException("معرف الدرجة غير صالح.");

            if (!Enum.IsDefined(typeof(JobTitleType), jobTitleType))
                throw new ArgumentException("نوع العنوان الوظيفي غير صالح.");

            Id = Guid.NewGuid();
            Title = title.Trim();
            GradeId = gradeId;
            JobTitleType = jobTitleType;

            SetCreated(userGuid);
        }

        // ======================================================
        // Update
        // ======================================================

        public void Update(
            string title,
            Guid gradeId,
            JobTitleType jobTitleType,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("اسم العنوان الوظيفي لا يمكن أن يكون فارغاً.");

            if (gradeId == Guid.Empty)
                throw new ArgumentException("معرف الدرجة غير صالح.");

            if (!Enum.IsDefined(typeof(JobTitleType), jobTitleType))
                throw new ArgumentException("نوع العنوان الوظيفي غير صالح.");

            Title = title.Trim();
            GradeId = gradeId;
            JobTitleType = jobTitleType;

            Touch(userGuid);
        }

        // ======================================================
        // تغيير الدرجة فقط
        // ======================================================

        public void ChangeGrade(Guid gradeId, Guid userGuid)
        {
            if (gradeId == Guid.Empty)
                throw new ArgumentException("معرف الدرجة غير صالح.");

            GradeId = gradeId;
            Touch(userGuid);
        }

        // ======================================================
        // تغيير النوع فقط
        // ======================================================

        public void ChangeType(JobTitleType jobTitleType, Guid userGuid)
        {
            if (!Enum.IsDefined(typeof(JobTitleType), jobTitleType))
                throw new ArgumentException("نوع العنوان الوظيفي غير صالح.");

            JobTitleType = jobTitleType;
            Touch(userGuid);
        }
    }
}