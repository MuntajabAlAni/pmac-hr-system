using System;
using Domain.Common.BaseEntities;

namespace Domain.Entities.EmploymentStructure
{
    // طبيعة العمل (ميداني،هندسي ,إداري، مكتبي...)
    public class WorkNature : Base<Guid>
    {
        public string Name { get; private set; }

        private WorkNature() { }

        public WorkNature(string name, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Work nature name cannot be empty.");

            Name = name.Trim();

            SetCreated(userGuid);
        }

        public void Update(string name, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Work nature name cannot be empty.");

            Name = name.Trim();

            Touch(userGuid);
        }
    }
}
