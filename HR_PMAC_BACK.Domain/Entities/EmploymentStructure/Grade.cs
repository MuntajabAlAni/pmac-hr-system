using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;
using HR_PMAC_BACK.Domain.Entities.EmploymentStructure.Enums;

namespace HR_PMAC_BACK.Domain.Entities.EmploymentStructure
{
    /// <summary>
    /// يمثل الدرجة الوظيفية الرسمية
    /// (عليا أ – عليا ب – الأولى – الثانية – ... )
    /// </summary>
    public class Grade : Base<int>
    {
        /// <summary>
        /// الاسم الوصفي للدرجة (مثلاً: الدرجة الأولى / عليا أ)
        /// يستخدم للعرض فقط
        /// </summary>
        public string GradeName { get; private set; }

        /// <summary>
        /// مستوى الدرجة (Enum رسمي)
        /// </summary>
        public GradeLevel GradeLevel { get; private set; }

        private Grade() { }

        // ======================================================
        // Constructor
        // ======================================================

        public Grade(
            string gradeName,
            GradeLevel gradeLevel,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(gradeName))
                throw new ArgumentException("اسم الدرجة لا يمكن أن يكون فارغاً.");

            if (!Enum.IsDefined(typeof(GradeLevel), gradeLevel))
                throw new ArgumentException("مستوى الدرجة غير صالح.");

            GradeName = gradeName.Trim();
            GradeLevel = gradeLevel;

            SetCreated(userGuid);
        }

        // ======================================================
        // Update
        // ======================================================

        public void Update(
            string gradeName,
            GradeLevel gradeLevel,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(gradeName))
                throw new ArgumentException("اسم الدرجة لا يمكن أن يكون فارغاً.");

            if (!Enum.IsDefined(typeof(GradeLevel), gradeLevel))
                throw new ArgumentException("مستوى الدرجة غير صالح.");

            GradeName = gradeName.Trim();
            GradeLevel = gradeLevel;

            Touch(userGuid);
        }

        // ======================================================
        // تغيير المستوى فقط (اختياري للفصل بين العمليات)
        // ======================================================

        public void ChangeLevel(GradeLevel gradeLevel, Guid userGuid)
        {
            if (!Enum.IsDefined(typeof(GradeLevel), gradeLevel))
                throw new ArgumentException("مستوى الدرجة غير صالح.");

            GradeLevel = gradeLevel;
            Touch(userGuid);
        }
    }
}