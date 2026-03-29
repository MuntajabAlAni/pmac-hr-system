using System;
using Domain.Common.BaseEntities;

namespace Domain.Entities.Organizations
{
    /// <summary>
    /// يمثل المديرية (أصغر من الدائرة وأكبر من القسم)
    /// يرتبط بالجهة العليا بشكل إجباري
    /// ويمكن أن يرتبط بجهة فرعية أو دائرة بشكل اختياري
    /// </summary>
    public class SubDirectorate : Base<Guid>
    {
        /// <summary>
        /// اسم المديرية
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

        private SubDirectorate() { }

        /// <summary>
        /// إنشاء مديرية جديدة
        /// </summary>
        public SubDirectorate(
            string name,
            Guid highAuthorityId,
            Guid? directorateId,
            Guid? subHighAuthorityId,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم المديرية لا يمكن أن يكون فارغاً.");

            if (highAuthorityId == Guid.Empty)
                throw new ArgumentException("يجب تحديد الجهة العليا.");

            if (directorateId.HasValue && directorateId == Guid.Empty)
                throw new ArgumentException("معرف الدائرة غير صالح.");

            if (subHighAuthorityId.HasValue && subHighAuthorityId == Guid.Empty)
                throw new ArgumentException("معرف الجهة الفرعية غير صالح.");

            Name = name.Trim();
            HighAuthorityId = highAuthorityId;
            DirectorateId = directorateId;
            SubHighAuthorityId = subHighAuthorityId;

            SetCreated(userGuid);
        }

        /// <summary>
        /// تحديث اسم المديرية
        /// </summary>
        public void Update(string name, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم المديرية لا يمكن أن يكون فارغاً.");

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
            DirectorateId = null;
            SubHighAuthorityId = null;

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

            // تحقق هرمي: يجب أن تكون الجهة الفرعية تابعة لنفس الجهة العليا
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
    }
}