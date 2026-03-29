using System;
using System.Collections.Generic;
using Domain.Common.BaseEntities;

namespace Domain.Entities.Vacations
{
    /// <summary>
    /// يمثل نوع الإجازة (اعتيادية، مرضية، أمومة، بدون راتب...)
    /// </summary>
    public class VacationType : Base<Guid>
    {
        /// <summary>
        /// اسم نوع الإجازة
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// هل يتطلب هذا النوع شرطاً خاصاً؟
        /// </summary>
        public bool IsConditional { get; private set; }

        /// <summary>
        /// هل تحتسب خدمة فعلية مع تفعيل عداد الرصيد؟
        /// </summary>
        public bool IsCountedInBalance { get; private set; }

        /// <summary>
        /// هل تؤثر هذه الإجازة على العلاوة؟
        /// </summary>
        public bool BonusAffect { get; private set; }

        /// <summary>
        /// هل تؤثر هذه الإجازة على الترفيع؟
        /// </summary>
        public bool PromotionAffect { get; private set; }

        public ICollection<EmployeeVacation> EmployeeVacations { get; private set; }

        private VacationType() { }

        public VacationType(
            string name,
            bool isConditional,
            bool isCountedInBalance,
            bool bonusAffect,
            bool promotionAffect,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم نوع الإجازة مطلوب.");

            Name = name.Trim();
            IsConditional = isConditional;
            IsCountedInBalance = isCountedInBalance;
            BonusAffect = bonusAffect;
            PromotionAffect = promotionAffect;

            SetCreated(userGuid);
        }

        public void Update(
            string name,
            bool isConditional,
            bool isCountedInBalance,
            bool bonusAffect,
            bool promotionAffect,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم نوع الإجازة مطلوب.");

            Name = name.Trim();
            IsConditional = isConditional;
            IsCountedInBalance = isCountedInBalance;
            BonusAffect = bonusAffect;
            PromotionAffect = promotionAffect;

            Touch(userGuid);
        }
    }
}