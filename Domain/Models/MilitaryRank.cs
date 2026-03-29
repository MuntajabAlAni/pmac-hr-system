using System;
using Domain.Common.BaseEntities;

namespace Domain.Entities.EmploymentStructure
{
    // الرتب العسكرية
    public class MilitaryRank : Base<Guid>
    {
        public string RankName { get; private set; }

        // المستوى العسكري (كلما كان الرقم أصغر كانت الرتبة أعلى)
        public int RankLevel { get; private set; }

        private MilitaryRank() { }

        public MilitaryRank(
            string rankName,
            int rankLevel,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(rankName))
                throw new ArgumentException("Rank name cannot be empty.");

            if (rankLevel <= 0)
                throw new ArgumentException("Rank level must be greater than zero.");

            RankName = rankName.Trim();
            RankLevel = rankLevel;

            SetCreated(userGuid);
        }

        public void Update(
            string rankName,
            int rankLevel,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(rankName))
                throw new ArgumentException("Rank name cannot be empty.");

            if (rankLevel <= 0)
                throw new ArgumentException("Rank level must be greater than zero.");

            RankName = rankName.Trim();
            RankLevel = rankLevel;

            Touch(userGuid);
        }
    }
}
