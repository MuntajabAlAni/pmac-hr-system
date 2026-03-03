using System;
using System.Collections.Generic;
using HR_PMAC_BACK.Domain.Common.BaseEntities;

namespace HR_PMAC_BACK.Domain.Entities.AdministrativeOrders
{
    /// <summary>
    /// يمثل نوع الأمر (إداري، ديواني، وزاري، أمر لجنة...)
    /// </summary>
    public class AdministrativeOrderType : Base<int>
    {
        /// <summary>
        /// اسم نوع الأمر
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// جميع الأوامر المرتبطة بهذا النوع
        /// </summary>
        public ICollection<AdministrativeOrder> AdministrativeOrders { get; private set; }

        private AdministrativeOrderType() { }

        public AdministrativeOrderType(string name, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم نوع الأمر مطلوب.");

            Name = name.Trim();

            SetCreated(userGuid);
        }

        public void Update(string name, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم نوع الأمر مطلوب.");

            Name = name.Trim();
            Touch(userGuid);
        }
    }
}