using System;

namespace HR_PMAC_BACK.Domain.Common.BaseEntities
{
    /// <summary>
    /// الكيان الأساسي لجميع الكيانات في النظام
    /// يحتوي على:
    /// - التدقيق (Auditing)
    /// - إدارة الحالة
    /// - إدارة النسخ / السجل التاريخي
    /// </summary>
    public abstract class Base<TId> : EntityBase<TId>
    {
        protected Base()
        {
            var now = DateTimeOffset.UtcNow;

            CreatedAtUtc = now;
            LastModifiedAtUtc = now;

            IsLast = true;      // النسخة الحالية
            IsActive = true;    // فعال افتراضياً
            IsDeleted = false;  // غير محذوف
        }

        // ======================================================
        // Auditing (معلومات التتبع)
        // ======================================================

        /// <summary>
        /// المستخدم الذي أنشأ الكيان
        /// </summary>
        public Guid? CreationBy { get; protected set; }

        /// <summary>
        /// تاريخ الإنشاء (UTC)
        /// </summary>
        public DateTimeOffset CreatedAtUtc { get; protected set; }

        /// <summary>
        /// المستخدم الذي عدل الكيان آخر مرة
        /// </summary>
        public Guid? LastModifiedBy { get; protected set; }

        /// <summary>
        /// تاريخ آخر تعديل (UTC)
        /// </summary>
        public DateTimeOffset? LastModifiedAtUtc { get; protected set; }

        // ======================================================
        // Status Management (إدارة الحالة)
        // ======================================================

        /// <summary>
        /// هل الكيان فعال
        /// </summary>
        public bool IsActive { get; protected set; }

        /// <summary>
        /// حذف منطقي (Soft Delete)
        /// </summary>
        public bool IsDeleted { get; protected set; }

        // ======================================================
        // Versioning / History (إدارة النسخ)
        // ======================================================

        /// <summary>
        /// هل هذا هو السجل الأخير (في حال وجود تاريخ تغييرات)
        /// </summary>
        public bool IsLast { get; protected set; }

        // ======================================================
        // Internal Behavior Methods
        // ======================================================

        /// <summary>
        /// ضبط معلومات الإنشاء
        /// </summary>
        protected void SetCreated(Guid? userGuid)
        {
            CreationBy = userGuid;
            CreatedAtUtc = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// تحديث معلومات التعديل
        /// </summary>
        protected void Touch(Guid? userGuid)
        {
            LastModifiedBy = userGuid;
            LastModifiedAtUtc = DateTimeOffset.UtcNow;
        }

        // ======================================================
        // Soft Delete
        // ======================================================

        /// <summary>
        /// حذف منطقي للكيان
        /// </summary>
        public virtual void MarkDeleted(Guid? userGuid)
        {
            if (IsDeleted) return;

            IsDeleted = true;
            IsActive = false;   // عند الحذف يتم تعطيله تلقائياً
            IsLast = false;     // لا يعتبر أحدث نسخة

            Touch(userGuid);
        }

        // ======================================================
        // Activation / Deactivation
        // ======================================================

        public void Activate(Guid? userGuid)
        {
            if (IsDeleted)
                throw new InvalidOperationException("لا يمكن تفعيل كيان محذوف.");

            if (IsActive) return;

            IsActive = true;
            Touch(userGuid);
        }

        public void Deactivate(Guid? userGuid)
        {
            if (!IsActive) return;

            IsActive = false;
            Touch(userGuid);
        }

        // ======================================================
        // Version Control
        // ======================================================

        public void MarkAsLast(Guid? userGuid)
        {
            if (IsLast) return;

            IsLast = true;
            Touch(userGuid);
        }

        public void MarkAsNotLast(Guid? userGuid)
        {
            if (!IsLast) return;

            IsLast = false;
            Touch(userGuid);
        }
    }
}