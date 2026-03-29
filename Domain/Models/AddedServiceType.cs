using System;
using System.Collections.Generic;
using Domain.Common.BaseEntities;

namespace Domain.Entities.EmploymentHistory
{
    /// <summary>
    /// يمثل نوع الخدمة المضافة للموظف
    /// مثل: خدمة عسكرية، خدمة عقد سابق، خدمة فصل سياسي...
    /// </summary>
    public class AddedServiceType : Base<Guid>
    {
        /// <summary>
        /// اسم نوع الخدمة المضافة
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// هل تؤثر هذه الخدمة على العلاوة؟
        /// </summary>
        public bool BonusAffect { get; private set; }

        /// <summary>
        /// هل تؤثر هذه الخدمة على الترفيع؟
        /// </summary>
        public bool PromotionAffect { get; private set; }

        /// <summary>
        /// جميع الخدمات المضافة المرتبطة بهذا النوع
        /// </summary>
        public ICollection<EmployeeAddedService> EmployeeAddedServices { get; private set; }

        private AddedServiceType() { }

        public AddedServiceType(
            string name,
            bool bonusAffect,
            bool promotionAffect,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم نوع الخدمة المضافة مطلوب.");

            Name = name.Trim();
            BonusAffect = bonusAffect;
            PromotionAffect = promotionAffect;

            SetCreated(userGuid);
        }

        public void Update(
            string name,
            bool bonusAffect,
            bool promotionAffect,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم نوع الخدمة المضافة مطلوب.");

            Name = name.Trim();
            BonusAffect = bonusAffect;
            PromotionAffect = promotionAffect;

            Touch(userGuid);
        }
    }
}