using System;
using Domain.Common.BaseEntities;

namespace Domain.Entities.Organizations
{
    // الجهات الفرعية التابعة للجهة العليا
    //مثل الجامعات او الهيئة ضمن المكتب
    public class SubHighAuthority : Base<Guid>
    {
        public string SubAuthorityName { get; private set; }

        // =============================
        // Foreign Key
        // =============================

        public Guid HighAuthorityId { get; private set; }

        // Navigation
        public HighAuthority HighAuthority { get; private set; }

        private SubHighAuthority() { }

        public SubHighAuthority(
            string name,
            Guid highAuthorityId,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Sub authority name cannot be empty.");

            if (highAuthorityId == Guid.Empty)
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