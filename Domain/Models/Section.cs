using System;
using Domain.Common.BaseEntities;

namespace Domain.Entities.Organizations
{
    /// <summary>
    /// تمثل الشعبة داخل الهيكل الإداري
    /// ترتبط بالجهة العليا بشكل إجباري
    /// وبقية المستويات اختيارية مع تحقق هرمي
    /// </summary>
    public class Section : Base<Guid>
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

        /// <summary>
        /// القسم (اختياري)
        /// </summary>
        public Guid? DepartmentId { get; private set; }
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
            Guid highAuthorityId,
            Guid? subHighAuthorityId,
            Guid? directorateId,
            Guid? subDirectorateId,
            Guid? departmentId,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم الشعبة لا يمكن أن يكون فارغاً.");

            if (highAuthorityId == Guid.Empty)
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

        public void ChangeHighAuthority(Guid highAuthorityId, Guid userGuid)
        {
            if (highAuthorityId == Guid.Empty)
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
            Guid subHighAuthorityId,
            Guid subHighAuthorityHighAuthorityId,
            Guid userGuid)
        {
            if (subHighAuthorityId == Guid.Empty)
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
            Guid directorateId,
            Guid directorateHighAuthorityId,
            Guid userGuid)
        {
            if (directorateId == Guid.Empty)
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
            Guid subDirectorateId,
            Guid subDirectorateHighAuthorityId,
            Guid userGuid)
        {
            if (subDirectorateId == Guid.Empty)
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
            Guid departmentId,
            Guid departmentHighAuthorityId,
            Guid userGuid)
        {
            if (departmentId == Guid.Empty)
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