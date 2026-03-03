using System;
using System.Collections.Generic;
using HR_PMAC_BACK.Domain.Common.BaseEntities;

namespace HR_PMAC_BACK.Domain.Entities.Thanks
{
    /// <summary>
    /// يمثل نوع كتاب الشكر
    /// مثل: شكر وزاري، شكر من رئيس الهيئة، شكر مدير عام...
    /// </summary>
    public class ThanksType : Base<int>
    {
        /// <summary>
        /// اسم نوع كتاب الشكر
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// عدد الأيام المضافة كقدم خدمة (إن وجد)
        /// </summary>
        public int AddedDays { get; private set; }

        /// <summary>
        /// هل يؤثر هذا النوع على العلاوة السنوية؟
        /// </summary>
        public bool BonusAffect { get; private set; }

        /// <summary>
        /// هل يؤثر هذا النوع على الترفيع؟
        /// </summary>
        public bool PromotionAffect { get; private set; }

        /// <summary>
        /// جميع كتب الشكر المرتبطة بهذا النوع
        /// </summary>
        public ICollection<EmployeeThanks> EmployeeThanks { get; private set; }

        private ThanksType() { }

        public ThanksType(
            string name,
            int addedDays,
            bool bonusAffect,
            bool promotionAffect,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم نوع كتاب الشكر مطلوب.");

            if (addedDays < 0)
                throw new ArgumentException("عدد الأيام لا يمكن أن يكون سالباً.");

            Name = name.Trim();
            AddedDays = addedDays;
            BonusAffect = bonusAffect;
            PromotionAffect = promotionAffect;

            SetCreated(userGuid);
        }

        public void Update(
            string name,
            int addedDays,
            bool bonusAffect,
            bool promotionAffect,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم نوع كتاب الشكر مطلوب.");

            if (addedDays < 0)
                throw new ArgumentException("عدد الأيام لا يمكن أن يكون سالباً.");

            Name = name.Trim();
            AddedDays = addedDays;
            BonusAffect = bonusAffect;
            PromotionAffect = promotionAffect;

            Touch(userGuid);
        }
    }
}