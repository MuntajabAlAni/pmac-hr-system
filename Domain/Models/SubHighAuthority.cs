using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;

namespace HR_PMAC_BACK.Domain.Entities.Organizations
{
    // الجهات الفرعية التابعة للجهة العليا
    //مثل الجامعات او الهيئة ضمن المكتب
    public class SubHighAuthority : Base<int>
    {
        public string SubAuthorityName { get; private set; }

        // =============================
        // Foreign Key
        // =============================

        public int HighAuthorityId { get; private set; }

        // Navigation
        public HighAuthority HighAuthority { get; private set; }

        private SubHighAuthority() { }

        public SubHighAuthority(
            string name,
            int highAuthorityId,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Sub authority name cannot be empty.");

            if (highAuthorityId <= 0)
                throw new ArgumentException("Invalid HighAuthorityId.");

            SubAuthorityName = name.Trim();
            HighAuthorityId = highAuthorityId;

            SetCreated(userGuid);
        }

        public void Update(
            string name,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Sub authority name cannot be empty.");

            SubAuthorityName = name.Trim();

            Touch(userGuid);
        }
    }
}