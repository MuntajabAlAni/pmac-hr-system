using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;

namespace HR_PMAC_BACK.Domain.Entities.Organizations
{
    /// <summary>
    /// تمثل الدائرة داخل الهيكل الإداري
    /// ترتبط بالجهة العليا بشكل إجباري
    /// ويمكن أن ترتبط بجهة فرعية بشكل اختياري
    /// </summary>
    public class Directorate : Base<int>
    {
        /// <summary>
        /// اسم الدائرة
        /// </summary>
        public string Name { get; private set; }

        // ======================================================
        // العلاقة الإلزامية (الجذر الإداري)
        // ======================================================

        /// <summary>
        /// معرف الجهة العليا (إجباري)
        /// </summary>
        public int HighAuthorityId { get; private set; }

        /// <summary>
        /// Navigation Property للجهة العليا
        /// </summary>
        public HighAuthority HighAuthority { get; private set; }

        // ======================================================
        // العلاقة الاختيارية
        // ======================================================

        /// <summary>
        /// الجهة الفرعية (اختياري)
        /// </summary>
        public int? SubHighAuthorityId { get; private set; }
        public SubHighAuthority? SubHighAuthority { get; private set; }

        private Directorate() { }

        /// <summary>
        /// إنشاء دائرة جديدة
        /// </summary>
        public Directorate(
            string name,
            int highAuthorityId,
            int? subHighAuthorityId,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم الدائرة لا يمكن أن يكون فارغاً.");

            if (highAuthorityId <= 0)
                throw new ArgumentException("يجب تحديد الجهة العليا.");

            if (subHighAuthorityId.HasValue && subHighAuthorityId <= 0)
                throw new ArgumentException("معرف الجهة الفرعية غير صالح.");

            Name = name.Trim();
            HighAuthorityId = highAuthorityId;
            SubHighAuthorityId = subHighAuthorityId;

            SetCreated(userGuid);
        }

        /// <summary>
        /// تحديث اسم الدائرة
        /// </summary>
        public void Update(string name, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم الدائرة لا يمكن أن يكون فارغاً.");

            Name = name.Trim();
            Touch(userGuid);
        }

        // ======================================================
        // تغيير الجهة العليا (إجباري دائماً)
        // عند تغييرها يتم إلغاء أي ارتباط فرعي
        // ======================================================

        public void ChangeHighAuthority(int highAuthorityId, Guid userGuid)
        {
            if (highAuthorityId <= 0)
                throw new ArgumentException("معرف الجهة العليا غير صالح.");

            HighAuthorityId = highAuthorityId;

            // حفاظاً على سلامة التسلسل الإداري
            SubHighAuthorityId = null;

            Touch(userGuid);
        }

        // ======================================================
        // ربط جهة فرعية (اختياري)
        // يتم تمرير HighAuthorityId الخاص بها للتحقق الهرمي
        // ======================================================

        public void AssignSubAuthority(
            int subHighAuthorityId,
            int subHighAuthorityHighAuthorityId,
            Guid userGuid)
        {
            if (subHighAuthorityId <= 0)
                throw new ArgumentException("معرف الجهة الفرعية غير صالح.");

            // تحقق هرمي: يجب أن تكون الجهة الفرعية تابعة لنفس الجهة العليا
            if (subHighAuthorityHighAuthorityId != HighAuthorityId)
                throw new InvalidOperationException(
                    "الجهة الفرعية لا تتبع للجهة العليا المحددة.");

            SubHighAuthorityId = subHighAuthorityId;

            Touch(userGuid);
        }

        /// <summary>
        /// إزالة الارتباط بالجهة الفرعية
        /// </summary>
        public void RemoveSubAuthority(Guid userGuid)
        {
            SubHighAuthorityId = null;
            Touch(userGuid);
        }
    }
}