using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;
using HR_PMAC_BACK.Domain.Entities.Employees.Enums;

namespace HR_PMAC_BACK.Domain.Entities.Employees
{
    /// <summary>
    /// يمثل أحد أفراد عائلة الموظف
    /// </summary>
    public class EmployeeFamilyMember : Base<Guid>
    {
        // ======================================================
        // Relation to Employee
        // ======================================================

        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        // ======================================================
        // Basic Info
        // ======================================================

        /// <summary>
        /// الاسم الكامل
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// درجة القرابة
        /// </summary>
        public FamilyRelationType RelationType { get; private set; }

        public DateTime? BirthDate { get; private set; }

        public string? NationalIdNumber { get; private set; }

        /// <summary>
        /// هل معال رسمياً
        /// </summary>
        public bool IsDependent { get; private set; }

        // ======================================================
        // Documents (مستمسكات)
        // ======================================================

        /// <summary>
        /// مسار هوية الأحوال / البطاقة الوطنية
        /// </summary>
        public string? NationalIdFilePath { get; private set; }

        /// <summary>
        /// مسار بطاقة السكن
        /// </summary>
        public string? ResidenceCardFilePath { get; private set; }

        /// <summary>
        /// أي مستمسك إضافي
        /// </summary>
        public string? OtherDocumentFilePath { get; private set; }

        private EmployeeFamilyMember() { }

        public EmployeeFamilyMember(
            Guid employeeId,
            string fullName,
            FamilyRelationType relationType,
            DateTime? birthDate,
            string? nationalIdNumber,
            bool isDependent,
            string? nationalIdFilePath,
            string? residenceCardFilePath,
            string? otherDocumentFilePath,
            Guid userGuid)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("EmployeeId required.");

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name required.");

            if (!Enum.IsDefined(typeof(FamilyRelationType), relationType))
                throw new ArgumentException("Invalid relation type.");

            Id = Guid.NewGuid();

            EmployeeId = employeeId;
            FullName = fullName.Trim();
            RelationType = relationType;
            BirthDate = birthDate;
            NationalIdNumber = nationalIdNumber?.Trim();
            IsDependent = isDependent;

            NationalIdFilePath = nationalIdFilePath?.Trim();
            ResidenceCardFilePath = residenceCardFilePath?.Trim();
            OtherDocumentFilePath = otherDocumentFilePath?.Trim();

            SetCreated(userGuid);
        }

        public void UpdateDocuments(
            string? nationalIdFilePath,
            string? residenceCardFilePath,
            string? otherDocumentFilePath,
            Guid userGuid)
        {
            NationalIdFilePath = nationalIdFilePath?.Trim();
            ResidenceCardFilePath = residenceCardFilePath?.Trim();
            OtherDocumentFilePath = otherDocumentFilePath?.Trim();

            Touch(userGuid);
        }
    }
}