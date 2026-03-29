using System;
using Domain.Common.BaseEntities;

namespace Domain.Entities.Organizations
{
    /// <summary>
    /// يمثل جهة خارجية (لا نملك هيكلها الإداري الداخلي)
    /// تستخدم في التكليف / التنسيب / النقل الخارجي
    /// </summary>
    public class ExternalEntity : Base<Guid>
    {
        /// <summary>
        /// اسم الجهة الخارجية
        /// </summary>
        public string EntityName { get; private set; }

        /// <summary>
        /// مستوى الجهة (يستخدم لتمييز المستوى الإداري الخارجي)
        /// مثال: 1 = جهة عليا ، 2 = دائرة ، 3 = قسم ... حسب تعريف النظام
        /// </summary>
        public int EntityLevel { get; private set; }

        private ExternalEntity() { }

        // ======================================================
        // Constructor
        // ======================================================

        /// <summary>
        /// إنشاء جهة خارجية جديدة
        /// </summary>
        public ExternalEntity(
            string entityName,
            int entityLevel,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(entityName))
                throw new ArgumentException("اسم الجهة الخارجية مطلوب.");

            if (entityLevel <= 0)
                throw new ArgumentException("مستوى الجهة يجب أن يكون أكبر من صفر.");

            EntityName = entityName.Trim();
            EntityLevel = entityLevel;

            SetCreated(userGuid);
        }

        // ======================================================
        // Update Methods
        // ======================================================

        /// <summary>
        /// تحديث اسم الجهة
        /// </summary>
        public void UpdateName(string entityName, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(entityName))
                throw new ArgumentException("اسم الجهة مطلوب.");

            EntityName = entityName.Trim();
            Touch(userGuid);
        }

        /// <summary>
        /// تحديث مستوى الجهة
        /// </summary>
        public void UpdateLevel(int entityLevel, Guid userGuid)
        {
            if (entityLevel <= 0)
                throw new ArgumentException("مستوى الجهة يجب أن يكون أكبر من صفر.");

            EntityLevel = entityLevel;
            Touch(userGuid);
        }

        // ======================================================
        // Activation / Deactivation
        // ======================================================

        /// <summary>
        /// تعطيل الجهة (Soft Deactivate)
        /// </summary>
        public void Deactivate(Guid userGuid)
        {
            if (!IsActive) return;

            base.Deactivate(userGuid);
        }

        /// <summary>
        /// إعادة تفعيل الجهة
        /// </summary>
        public void ActivateEntity(Guid userGuid)
        {
            if (IsDeleted)
                throw new InvalidOperationException("لا يمكن تفعيل جهة محذوفة.");

            base.Activate(userGuid);
        }
    }
}