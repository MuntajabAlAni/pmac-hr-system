using System;
using System.Collections.Generic;
using Domain.Common.BaseEntities;

namespace Domain.Entities.Committees
{
    /// <summary>
    /// يمثل نوع اللجنة (داخلية / خارجية)
    /// </summary>
    public class CommitteeType : Base<Guid>
    {
        public string Name { get; private set; }

        /// <summary>
        /// هل اللجنة داخلية؟
        /// </summary>
        public bool IsInternal { get; private set; }

        public ICollection<EmployeeCommittee> EmployeeCommittees { get; private set; }

        private CommitteeType() { }

        public CommitteeType(string name, bool isInternal, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم نوع اللجنة مطلوب.");

            Name = name.Trim();
            IsInternal = isInternal;

            SetCreated(userGuid);
        }
    }
}