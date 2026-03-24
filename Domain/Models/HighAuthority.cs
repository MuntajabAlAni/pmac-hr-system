using System;
using System.Collections.Generic;
using HR_PMAC_BACK.Domain.Common.BaseEntities;
using HR_PMAC_BACK.Domain.Entities.Organizations.Enums;

namespace HR_PMAC_BACK.Domain.Entities.Organizations
{
    // الجهات العليا (وزارة / هيئة / مجلس / أمانة عامة)
    public class HighAuthority : Base<int>
    {
        public string AuthorityName { get; private set; }

        // نوع الجهة
        public AuthorityType AuthorityType { get; private set; }

        // =============================
        // Navigation
        // =============================

        public ICollection<SubHighAuthority> SubHighAuthorities { get; private set; }
            = new List<SubHighAuthority>();

        private HighAuthority() { }

        public HighAuthority(
            string name,
            AuthorityType type,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Authority name cannot be empty.");

            AuthorityName = name.Trim();
            AuthorityType = type;

            SetCreated(userGuid);
        }

        public void Update(
            string name,
            AuthorityType type,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Authority name cannot be empty.");

            AuthorityName = name.Trim();
            AuthorityType = type;

            Touch(userGuid);
        }
    }
}

//using System;
//using HR_PMAC_BACK.Domain.Common.BaseEntities;
//using HR_PMAC_BACK.Domain.Entities.Organizations.Enums;

//namespace HR_PMAC_BACK.Domain.Entities.Organizations
//{
//    // الجهات العليا (وزارة / هيئة / مجلس / أمانة عامة)
//    public class HighAuthority : Base<int>
//    {
//        public string AuthorityName { get; private set; }
//        //Enum
//        public AuthorityType AuthorityType { get; private set; }

//        private HighAuthority() { }

//        public HighAuthority(
//            string name,
//            AuthorityType type,
//            Guid userGuid)
//        {
//            if (string.IsNullOrWhiteSpace(name))
//                throw new ArgumentException("Authority name cannot be empty.");

//            AuthorityName = name.Trim();
//            AuthorityType = type;

//            SetCreated(userGuid);
//        }

//        public void Update(
//            string name,
//            AuthorityType type,
//            Guid userGuid)
//        {
//            if (string.IsNullOrWhiteSpace(name))
//                throw new ArgumentException("Authority name cannot be empty.");

//            AuthorityName = name.Trim();
//            AuthorityType = type;

//            Touch(userGuid);
//        }
//    }
//}
