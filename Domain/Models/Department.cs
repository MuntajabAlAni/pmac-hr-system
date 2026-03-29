using System;
using Domain.Common.BaseEntities;

namespace Domain.Entities.Organizations
{
    /// <summary>
    /// يمثل القسم داخل الهيكل الإداري
    /// يرتبط بالجهة العليا بشكل إجباري
    /// وبقية المستويات اختيارية
    /// </summary>
    public class Department : Base<Guid>
    {
        /// <summary>
        /// اسم القسم
        /// </summary>
        public string Name { get; private set; }

        // ======================================================
        // العلاقة الإلزامية (الجذر الإداري)
        // ======================================================

        /// <summary>
        /// معرف الجهة العليا (إجباري)
        /// </summary>
        public Guid HighAuthorityId { get; private set; }

        /// <summary>
        /// Navigation Property للجهة العليا
        /// </summary>
        public HighAuthority HighAuthority { get; private set; }

        // ======================================================
        // العلاقات الاختيارية
        // ======================================================

        /// <summary>
        /// الجهة الفرعية (اختياري)
        /// </summary>
        public Guid? SubHighAuthorityId { get; private set; }
        public SubHighAuthority? SubHighAuthority { get; private set; }

        /// <summary>
        /// الدائرة (اختياري)
        /// </summary>
        public Guid? DirectorateId { get; private set; }
        public Directorate? Directorate { get; private set; }

        /// <summary>
        /// المديرية (اختياري)
        /// </summary>
        public Guid? SubDirectorateId { get; private set; }
        public SubDirectorate? SubDirectorate { get; private set; }

        private Department() { }

        /// <summary>
        /// إنشاء قسم جديد
        /// </summary>
        public Department(
            string name,
            Guid highAuthorityId,
            Guid? subHighAuthorityId,
            Guid? directorateId,
            Guid? subDirectorateId,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم القسم لا يمكن أن يكون فارغاً.");

            if (highAuthorityId == Guid.Empty)
                throw new ArgumentException("يجب تحديد الجهة العليا.");

            if (subHighAuthorityId.HasValue && subHighAuthorityId == Guid.Empty)
                throw new ArgumentException("معرف الجهة الفرعية غير صالح.");

            if (directorateId.HasValue && directorateId == Guid.Empty)
                throw new ArgumentException("معرف الدائرة غير صالح.");

            if (subDirectorateId.HasValue && subDirectorateId == Guid.Empty)
                throw new ArgumentException("معرف المديرية غير صالح.");

            Name = name.Trim();
            HighAuthorityId = highAuthorityId;
            SubHighAuthorityId = subHighAuthorityId;
            DirectorateId = directorateId;
            SubDirectorateId = subDirectorateId;

            SetCreated(userGuid);
        }

        /// <summary>
        /// تحديث اسم القسم
        /// </summary>
        public void Update(string name, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم القسم لا يمكن أن يكون فارغاً.");

            Name = name.Trim();
            Touch(userGuid);
        }

        // ======================================================
        // تغيير الجهة العليا (إجباري دائماً)
        // عند تغييرها يتم تصفير المستويات الأدنى
        // ======================================================

        public void ChangeHighAuthority(Guid highAuthorityId, Guid userGuid)
        {
            if (highAuthorityId == Guid.Empty)
                throw new ArgumentException("معرف الجهة العليا غير صالح.");

            HighAuthorityId = highAuthorityId;

            // حفاظاً على سلامة الهيكل الإداري
            SubHighAuthorityId = null;
            DirectorateId = null;
            SubDirectorateId = null;

            Touch(userGuid);
        }

        // ======================================================
        // ربط جهة فرعية (اختياري)
        // يتم تمرير HighAuthorityId الخاص بها للتحقق الهرمي
        // ======================================================

        public void AssignSubHighAuthority(
            Guid subHighAuthorityId,
            Guid subHighAuthorityHighAuthorityId,
            Guid userGuid)
        {
            if (subHighAuthorityId == Guid.Empty)
                throw new ArgumentException("معرف الجهة الفرعية غير صالح.");

            // تحقق هرمي: يجب أن تكون تابعة لنفس الجهة العليا
            if (subHighAuthorityHighAuthorityId != HighAuthorityId)
                throw new InvalidOperationException(
                    "الجهة الفرعية لا تتبع للجهة العليا المحددة.");

            SubHighAuthorityId = subHighAuthorityId;
            Touch(userGuid);
        }

        public void RemoveSubHighAuthority(Guid userGuid)
        {
            SubHighAuthorityId = null;
            Touch(userGuid);
        }

        // ======================================================
        // ربط دائرة (اختياري)
        // ======================================================

        public void AssignDirectorate(Guid directorateId, Guid userGuid)
        {
            if (directorateId == Guid.Empty)
                throw new ArgumentException("معرف الدائرة غير صالح.");

            DirectorateId = directorateId;
            Touch(userGuid);
        }

        public void RemoveDirectorate(Guid userGuid)
        {
            DirectorateId = null;
            Touch(userGuid);
        }

        // ======================================================
        // ربط مديرية (اختياري)
        // ======================================================

        public void AssignSubDirectorate(Guid subDirectorateId, Guid userGuid)
        {
            if (subDirectorateId == Guid.Empty)
                throw new ArgumentException("معرف المديرية غير صالح.");

            SubDirectorateId = subDirectorateId;
            Touch(userGuid);
        }

        public void RemoveSubDirectorate(Guid userGuid)
        {
            SubDirectorateId = null;
            Touch(userGuid);
        }
    }
}