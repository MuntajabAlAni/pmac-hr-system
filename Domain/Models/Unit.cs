using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;

namespace HR_PMAC_BACK.Domain.Entities.Organizations
{
    /// <summary>
    /// تمثل الوحدة داخل الهيكل الإداري
    /// ترتبط بالجهة العليا بشكل إجباري
    /// وبقية المستويات اختيارية مع تحقق هرمي كامل
    /// </summary>
    public class Unit : Base<int>
    {
        /// <summary>
        /// اسم الوحدة
        /// </summary>
        public string Name { get; private set; }

        // ======================================================
        // الجذر الإداري (إجباري)
        // ======================================================

        /// <summary>
        /// معرف الجهة العليا (إجباري دائماً)
        /// </summary>
        public int HighAuthorityId { get; private set; }

        public HighAuthority HighAuthority { get; private set; }

        // ======================================================
        // العلاقات الاختيارية
        // ======================================================

        public int? SubHighAuthorityId { get; private set; }
        public SubHighAuthority? SubHighAuthority { get; private set; }

        public int? DirectorateId { get; private set; }
        public Directorate? Directorate { get; private set; }

        public int? SubDirectorateId { get; private set; }
        public SubDirectorate? SubDirectorate { get; private set; }

        public int? DepartmentId { get; private set; }
        public Department? Department { get; private set; }

        public int? SectionId { get; private set; }
        public Section? Section { get; private set; }

        private Unit() { }

        // ======================================================
        // Constructor
        // ======================================================

        public Unit(
            string name,
            int highAuthorityId,
            int? subHighAuthorityId,
            int? directorateId,
            int? subDirectorateId,
            int? departmentId,
            int? sectionId,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم الوحدة لا يمكن أن يكون فارغاً.");

            if (highAuthorityId <= 0)
                throw new ArgumentException("يجب تحديد الجهة العليا.");

            Name = name.Trim();
            HighAuthorityId = highAuthorityId;
            SubHighAuthorityId = subHighAuthorityId;
            DirectorateId = directorateId;
            SubDirectorateId = subDirectorateId;
            DepartmentId = departmentId;
            SectionId = sectionId;

            SetCreated(userGuid);
        }

        // ======================================================
        // تحديث الاسم
        // ======================================================

        public void Update(string name, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم الوحدة لا يمكن أن يكون فارغاً.");

            Name = name.Trim();
            Touch(userGuid);
        }

        // ======================================================
        // تغيير الجهة العليا
        // ======================================================

        public void ChangeHighAuthority(int highAuthorityId, Guid userGuid)
        {
            if (highAuthorityId <= 0)
                throw new ArgumentException("معرف الجهة العليا غير صالح.");

            HighAuthorityId = highAuthorityId;

            // إعادة ضبط كل المستويات الأدنى
            SubHighAuthorityId = null;
            DirectorateId = null;
            SubDirectorateId = null;
            DepartmentId = null;
            SectionId = null;

            Touch(userGuid);
        }

        // ======================================================
        // ربط جهة فرعية (مع تحقق هرمي)
        // ======================================================

        public void AssignSubHighAuthority(
            int id,
            int parentHighAuthorityId,
            Guid userGuid)
        {
            if (id <= 0)
                throw new ArgumentException("معرف الجهة الفرعية غير صالح.");

            if (parentHighAuthorityId != HighAuthorityId)
                throw new InvalidOperationException(
                    "الجهة الفرعية لا تتبع للجهة العليا المحددة.");

            SubHighAuthorityId = id;
            Touch(userGuid);
        }

        // ======================================================
        // ربط دائرة (مع تحقق هرمي)
        // ======================================================

        public void AssignDirectorate(
            int id,
            int parentHighAuthorityId,
            Guid userGuid)
        {
            if (id <= 0)
                throw new ArgumentException("معرف الدائرة غير صالح.");

            if (parentHighAuthorityId != HighAuthorityId)
                throw new InvalidOperationException(
                    "الدائرة لا تتبع للجهة العليا المحددة.");

            DirectorateId = id;
            Touch(userGuid);
        }

        // ======================================================
        // ربط مديرية (مع تحقق هرمي)
        // ======================================================

        public void AssignSubDirectorate(
            int id,
            int parentHighAuthorityId,
            Guid userGuid)
        {
            if (id <= 0)
                throw new ArgumentException("معرف المديرية غير صالح.");

            if (parentHighAuthorityId != HighAuthorityId)
                throw new InvalidOperationException(
                    "المديرية لا تتبع للجهة العليا المحددة.");

            SubDirectorateId = id;
            Touch(userGuid);
        }

        // ======================================================
        // ربط قسم (مع تحقق هرمي)
        // ======================================================

        public void AssignDepartment(
            int id,
            int parentHighAuthorityId,
            Guid userGuid)
        {
            if (id <= 0)
                throw new ArgumentException("معرف القسم غير صالح.");

            if (parentHighAuthorityId != HighAuthorityId)
                throw new InvalidOperationException(
                    "القسم لا يتبع للجهة العليا المحددة.");

            DepartmentId = id;
            Touch(userGuid);
        }

        // ======================================================
        // ربط شعبة (مع تحقق هرمي)
        // ======================================================

        public void AssignSection(
            int id,
            int parentHighAuthorityId,
            Guid userGuid)
        {
            if (id <= 0)
                throw new ArgumentException("معرف الشعبة غير صالح.");

            if (parentHighAuthorityId != HighAuthorityId)
                throw new InvalidOperationException(
                    "الشعبة لا تتبع للجهة العليا المحددة.");

            SectionId = id;
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

        public void RemoveSection(Guid userGuid)
        {
            SectionId = null;
            Touch(userGuid);
        }
    }
}