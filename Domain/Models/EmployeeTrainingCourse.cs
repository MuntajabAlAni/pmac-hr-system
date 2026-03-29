using System;
using Domain.Common.BaseEntities;
using Domain.Entities.Employees;

namespace Domain.Entities.Trainings
{
    /// <summary>
    /// يمثل دورة تدريبية شارك بها الموظف
    /// </summary>
    public class EmployeeTrainingCourse : Base<Guid>
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
        // معلومات الكتاب الإداري للدورة
        // =====================================================

        /// <summary>
        /// رقم الكتاب
        /// </summary>
        public string? BookNumber { get; private set; }

        /// <summary>
        /// تاريخ الكتاب
        /// </summary>
        public DateTime? BookDate { get; private set; }

        // =====================================================
        // معلومات الدورة
        // =====================================================

        /// <summary>
        /// اسم الدورة
        /// </summary>
        public string CourseName { get; private set; }

        /// <summary>
        /// الجهة الممولة
        /// </summary>
        public string? Sponsor { get; private set; }

        /// <summary>
        /// الجهة المقيمة للدورة
        /// </summary>
        public string? CourseEvaluator { get; private set; }

        /// <summary>
        /// عدد أيام الدورة
        /// </summary>
        public int DurationDays { get; private set; }

        /// <summary>
        /// تاريخ بدء الدورة
        /// </summary>
        public DateTime? StartDate { get; private set; }

        /// <summary>
        /// تاريخ انتهاء الدورة
        /// </summary>
        public DateTime? EndDate { get; private set; }

        /// <summary>
        /// تاريخ الانفكاك
        /// </summary>
        public DateTime? DetachmentDate { get; private set; }

        /// <summary>
        /// تاريخ المباشرة بعد الدورة
        /// </summary>
        public DateTime? InitiationDate { get; private set; }

        /// <summary>
        /// تقييم الدورة
        /// </summary>
        public string? Evaluation { get; private set; }

        /// <summary>
        /// هل الدورة لغرض الترفيع؟
        /// </summary>
        public bool IsForPromotion { get; private set; }

        /// <summary>
        /// ملاحظات إضافية
        /// </summary>
        public string? Notes { get; private set; }

        /// <summary>
        /// ملف شهادة الدورة أو كتاب المشاركة (إلزامي)
        /// </summary>
        public string TrainingFilePath { get; private set; }

        /// <summary>
        /// هل الدورة فعالة ضمن السجل الوظيفي؟
        /// </summary>
        public bool IsActive { get; private set; }

        private EmployeeTrainingCourse() { }

        /// <summary>
        /// إنشاء دورة تدريبية جديدة
        /// </summary>
        public EmployeeTrainingCourse(
            Guid employeeId,
            string courseName,
            int durationDays,
            bool isForPromotion,
            string trainingFilePath,
            Guid userGuid)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("رقم الموظف غير صالح.");

            if (string.IsNullOrWhiteSpace(courseName))
                throw new ArgumentException("اسم الدورة مطلوب.");

            if (durationDays <= 0)
                throw new ArgumentException("عدد أيام الدورة يجب أن يكون أكبر من صفر.");

            if (string.IsNullOrWhiteSpace(trainingFilePath))
                throw new ArgumentException("يجب إرفاق ملف الدورة.");

            EmployeeId = employeeId;
            CourseName = courseName.Trim();
            DurationDays = durationDays;
            IsForPromotion = isForPromotion;
            TrainingFilePath = trainingFilePath.Trim();
            IsActive = true;

            SetCreated(userGuid);
        }

        /// <summary>
        /// تحديث تفاصيل الدورة
        /// </summary>
        public void UpdateDetails(
            string? bookNumber,
            DateTime? bookDate,
            string? sponsor,
            string? courseEvaluator,
            DateTime? startDate,
            DateTime? endDate,
            DateTime? detachmentDate,
            DateTime? initiationDate,
            string? evaluation,
            bool isForPromotion,
            string? notes,
            bool isActive,
            Guid userGuid)
        {
            if (startDate.HasValue && endDate.HasValue && endDate < startDate)
                throw new ArgumentException("تاريخ انتهاء الدورة لا يمكن أن يكون قبل تاريخ البدء.");

            BookNumber = bookNumber?.Trim();
            BookDate = bookDate;
            Sponsor = sponsor?.Trim();
            CourseEvaluator = courseEvaluator?.Trim();
            StartDate = startDate;
            EndDate = endDate;
            DetachmentDate = detachmentDate;
            InitiationDate = initiationDate;
            Evaluation = evaluation?.Trim();
            IsForPromotion = isForPromotion;
            Notes = notes?.Trim();
            IsActive = isActive;

            Touch(userGuid);
        }

        /// <summary>
        /// تحديث ملف الدورة
        /// </summary>
        public void UpdateAttachment(string newFilePath, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(newFilePath))
                throw new ArgumentException("مسار الملف غير صالح.");

            TrainingFilePath = newFilePath.Trim();
            Touch(userGuid);
        }
    }
}