using System;

namespace HR_PMAC_BACK.Domain.Common.BaseEntities
{
    public abstract class EntityBase<TId>
    {
        public TId Id { get; protected set; } = default!;
    }
}
