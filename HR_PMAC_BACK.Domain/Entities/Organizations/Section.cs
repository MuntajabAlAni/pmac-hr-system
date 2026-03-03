using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;

namespace HR_PMAC_BACK.Domain.Entities.Organizations
{
    /// <summary>
    /// تمثل الشعبة داخل الهيكل الإداري
    /// ترتبط بالجهة العليا بشكل إجباري
    /// وبقية المستويات اختيارية مع تحقق هرمي
    /// </summary>
    public class Section : Base<int>
    {
        /// <summary>
        /// اسم الشعبة
        /// </summary>
        public string Name { get; private set; }

        // ======================================================
        // الجذر الإداري (إجباري)
        // ======================================================

        /// <summary>
        /// معرف الجهة العليا (إجباري دائماً)
        /// </summary>
        public int HighAuthorityId { get; private set; }

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
        public int? SubHighAuthorityId { get; private set; }
        public SubHighAuthority? SubHighAuthority { get; private set; }

        /// <summary>
        /// الدائرة (اختياري)
        /// </summary>
        public int? DirectorateId { get; private set; }
        public Directorate? Directorate { get; private set; }

        /// <summary>
        /// المديرية (اختياري)
        /// </summary>
        public int? SubDirectorateId { get; private set; }
        public SubDirectorate? SubDirectorate { get; private set; }

        /// <summary>
        /// القسم (اختياري)
        /// </summary>
        public int? DepartmentId { get; private set; }
        public Department? Department { get; private set; }

        private Section() { }

        // ======================================================
        // Constructor
        // ======================================================

        /// <summary>
        /// إنشاء شعبة جديدة
        /// </summary>
        public Section(
            string name,
            int highAuthorityId,
            int? subHighAuthorityId,
            int? directorateId,
            int? subDirectorateId,
            int? departmentId,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم الشعبة لا يمكن أن يكون فارغاً.");

            if (highAuthorityId <= 0)
                throw new ArgumentException("يجب تحديد الجهة العليا.");

            Name = name.Trim();
            HighAuthorityId = highAuthorityId;
            SubHighAuthorityId = subHighAuthorityId;
            DirectorateId = directorateId;
            SubDirectorateId = subDirectorateId;
            DepartmentId = departmentId;

            SetCreated(userGuid);
        }

        // ======================================================
        // تحديث الاسم
        // ======================================================

        public void Update(string name, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم الشعبة لا يمكن أن يكون فارغاً.");

            Name = name.Trim();
            Touch(userGuid);
        }

        // ======================================================
        // تغيير الجهة العليا
        // عند تغييرها يتم تصفير جميع المستويات الأدنى
        // ======================================================

        public void ChangeHighAuthority(int highAuthorityId, Guid userGuid)
        {
            if (highAuthorityId <= 0)
                throw new ArgumentException("معرف الجهة العليا غير صالح.");

            HighAuthorityId = highAuthorityId;

            // إعادة ضبط جميع العلاقات الأدنى
            SubHighAuthorityId = null;
            DirectorateId = null;
            SubDirectorateId = null;
            DepartmentId = null;

            Touch(userGuid);
        }

        // ======================================================
        // ربط جهة فرعية (مع تحقق هرمي)
        // ======================================================

        public void AssignSubHighAuthority(
            int subHighAuthorityId,
            int subHighAuthorityHighAuthorityId,
            Guid userGuid)
        {
            if (subHighAuthorityId <= 0)
                throw new ArgumentException("معرف الجهة الفرعية غير صالح.");

            if (subHighAuthorityHighAuthorityId != HighAuthorityId)
                throw new InvalidOperationException(
                    "الجهة الفرعية لا تتبع للجهة العليا المحددة.");

            SubHighAuthorityId = subHighAuthorityId;
            Touch(userGuid);
        }

        // ======================================================
        // ربط دائرة (مع تحقق هرمي)
        // ======================================================

        public void AssignDirectorate(
            int directorateId,
            int directorateHighAuthorityId,
            Guid userGuid)
        {
            if (directorateId <= 0)
                throw new ArgumentException("معرف الدائرة غير صالح.");

            if (directorateHighAuthorityId != HighAuthorityId)
                throw new InvalidOperationException(
                    "الدائرة لا تتبع للجهة العليا المحددة.");

            DirectorateId = directorateId;
            Touch(userGuid);
        }

        // ======================================================
        // ربط مديرية (مع تحقق هرمي)
        // ======================================================

        public void AssignSubDirectorate(
            int subDirectorateId,
            int subDirectorateHighAuthorityId,
            Guid userGuid)
        {
            if (subDirectorateId <= 0)
                throw new ArgumentException("معرف المديرية غير صالح.");

            if (subDirectorateHighAuthorityId != HighAuthorityId)
                throw new InvalidOperationException(
                    "المديرية لا تتبع للجهة العليا المحددة.");

            SubDirectorateId = subDirectorateId;
            Touch(userGuid);
        }

        // ======================================================
        // ربط قسم (مع تحقق هرمي)
        // ======================================================

        public void AssignDepartment(
            int departmentId,
            int departmentHighAuthorityId,
            Guid userGuid)
        {
            if (departmentId <= 0)
                throw new ArgumentException("معرف القسم غير صالح.");

            if (departmentHighAuthorityId != HighAuthorityId)
                throw new InvalidOperationException(
                    "القسم لا يتبع للجهة العليا المحددة.");

            DepartmentId = departmentId;
            Touch(userGuid);
        }

        // ======================================================
        // إزالة العلاقات الاختيارية
        // ======================================================

        public void RemoveSubHighAuthority(Guid userGuid)
        {
            SubHighAuthorityId = null;
            Touch(userGuid);
        }

        public void RemoveDirectorate(Guid userGuid)
        {
            DirectorateId = null;
            Touch(userGuid);
        }

        public void RemoveSubDirectorate(Guid userGuid)
        {
            SubDirectorateId = null;
            Touch(userGuid);
        }

        public void RemoveDepartment(Guid userGuid)
        {
            DepartmentId = null;
            Touch(userGuid);
        }
    }
}