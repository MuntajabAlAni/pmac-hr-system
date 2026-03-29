using System;
using System.Collections.Generic;
using Domain.Common.BaseEntities;

namespace Domain.Entities.Punishments
{
    /// <summary>
    /// يمثل نوع العقوبة (تنبيه، إنذار، قطع راتب، توبيخ...)
    /// </summary>
    public class PunishmentType : Base<Guid>
    {
        /// <summary>
        /// اسم نوع العقوبة
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// عدد الأيام المحرومة من الاستحقاق (إن وجد)
        /// </summary>
        public int DeductedDays { get; private set; }

        /// <summary>
        /// هل تؤثر هذه العقوبة على العلاوة؟
        /// </summary>
        public bool BonusAffect { get; private set; }

        /// <summary>
        /// هل تؤثر هذه العقوبة على الترفيع؟
        /// </summary>
        public bool PromotionAffect { get; private set; }

        /// <summary>
        /// جميع العقوبات المرتبطة بهذا النوع
        /// </summary>
        public ICollection<EmployeePunishment> EmployeePunishments { get; private set; }

        private PunishmentType() { }

        public PunishmentType(
            string name,
            int deductedDays,
            bool bonusAffect,
            bool promotionAffect,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم نوع العقوبة مطلوب.");

            if (deductedDays < 0)
                throw new ArgumentException("عدد الأيام لا يمكن أن يكون سالباً.");

            Name = name.Trim();
            DeductedDays = deductedDays;
            BonusAffect = bonusAffect;
            PromotionAffect = promotionAffect;

            SetCreated(userGuid);
        }

        public void Update(
            string name,
            int deductedDays,
            bool bonusAffect,
            bool promotionAffect,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم نوع العقوبة مطلوب.");

            if (deductedDays < 0)
                throw new ArgumentException("عدد الأيام لا يمكن أن يكون سالباً.");

            Name = name.Trim();
            DeductedDays = deductedDays;
            BonusAffect = bonusAffect;
            PromotionAffect = promotionAffect;

            Touch(userGuid);
        }
    }
}