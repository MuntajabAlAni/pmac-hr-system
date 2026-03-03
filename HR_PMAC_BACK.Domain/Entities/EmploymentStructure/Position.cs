using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;
using HR_PMAC_BACK.Domain.Entities.EmploymentStructure.Enums;

namespace HR_PMAC_BACK.Domain.Entities.EmploymentStructure
{
    /// <summary>
    /// يمثل المنصب الإداري داخل النظام
    /// (وزير، مستشار، مدير عام، ...)
    /// </summary>
    public class Position : Base<int>
    {
        /// <summary>
        /// اسم المنصب
        /// </summary>
        public string PositionName { get; private set; }

        /// <summary>
        /// مستوى المنصب الإداري (Enum رسمي)
        /// كلما كان الرقم أصغر كان المنصب أعلى
        /// </summary>
        public PositionLevel PositionLevel { get; private set; }

        private Position() { }

        // ======================================================
        // Constructor
        // ======================================================

        public Position(
            string positionName,
            PositionLevel positionLevel,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(positionName))
                throw new ArgumentException("اسم المنصب لا يمكن أن يكون فارغاً.");

            if (!Enum.IsDefined(typeof(PositionLevel), positionLevel))
                throw new ArgumentException("مستوى المنصب غير صالح.");

            PositionName = positionName.Trim();
            PositionLevel = positionLevel;

            SetCreated(userGuid);
        }

        // ======================================================
        // Update
        // ======================================================

        public void Update(
            string positionName,
            PositionLevel positionLevel,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(positionName))
                throw new ArgumentException("اسم المنصب لا يمكن أن يكون فارغاً.");

            if (!Enum.IsDefined(typeof(PositionLevel), positionLevel))
                throw new ArgumentException("مستوى المنصب غير صالح.");

            PositionName = positionName.Trim();
            PositionLevel = positionLevel;

            Touch(userGuid);
        }

        // ======================================================
        // تغيير المستوى فقط
        // ======================================================

        public void ChangeLevel(PositionLevel positionLevel, Guid userGuid)
        {
            if (!Enum.IsDefined(typeof(PositionLevel), positionLevel))
                throw new ArgumentException("مستوى المنصب غير صالح.");

            PositionLevel = positionLevel;
            Touch(userGuid);
        }
    }
}