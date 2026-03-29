using System;
using Domain.Common.BaseEntities;
using Domain.Entities.Certifications.Enums;

namespace Domain.Entities.Certifications
{
    /// <summary>
    /// Represents an academic or professional certification.
    /// تمثل شهادة أكاديمية أو مهنية داخل النظام
    /// </summary>
    public class Certification : Base<Guid>
    {
        // =====================================================
        // Core Properties
        // =====================================================

        /// <summary>
        /// Certification name (e.g., Bachelor, Master, PMP)
        /// اسم الشهادة
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Certification level (Diploma, Bachelor, Master, etc.)
        /// مستوى الشهادة
        /// </summary>
        public CertificationLevel Level { get; private set; }

        /// <summary>
        /// Optional description or notes
        /// وصف اختياري للشهادة
        /// </summary>
        public string? Description { get; private set; }

        /// <summary>
        /// Number of months counted for promotion purposes.
        /// If NULL → not determined yet.
        /// If 0 → no promotion credit granted.
        /// عدد الأشهر المحتسبة لغرض الترفيع
        /// </summary>
        public int? PromotionsMonths { get; private set; }

        /// <summary>
        /// Indicates whether this certification is considered higher education.
        /// هل تعتبر شهادة عليا (دراسات عليا)
        /// </summary>
        public bool IsHigherEducation { get; private set; }

        // =====================================================
        // Constructors
        // =====================================================

        // Required by EF Core
        private Certification() { }

        public Certification(
            string name,
            CertificationLevel level,
            string? description,
            int? promotionsMonths,
            bool isHigherEducation,
            Guid userGuid)
        {
            SetName(name);
            SetPromotionsMonths(promotionsMonths);

            Level = level;
            Description = description?.Trim();
            IsHigherEducation = isHigherEducation;

            SetCreated(userGuid);
        }

        // =====================================================
        // Update Method
        // =====================================================

        public void Update(
            string name,
            CertificationLevel level,
            string? description,
            int? promotionsMonths,
            bool isHigherEducation,
            Guid userGuid)
        {
            SetName(name);
            SetPromotionsMonths(promotionsMonths);

            Level = level;
            Description = description?.Trim();
            IsHigherEducation = isHigherEducation;

            Touch(userGuid);
        }

        // =====================================================
        // Private Validation Methods
        // =====================================================

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Certification name cannot be empty.");

            if (name.Length > 200)
                throw new ArgumentException("Certification name exceeds allowed length.");

            Name = name.Trim();
        }

        private void SetPromotionsMonths(int? months)
        {
            if (months.HasValue)
            {
                if (months < 0)
                    throw new ArgumentException("Promotions months cannot be negative.");

                if (months > 120)
                    throw new ArgumentException("Promotions months value is unrealistically high.");
            }

            PromotionsMonths = months;
        }
    }
}