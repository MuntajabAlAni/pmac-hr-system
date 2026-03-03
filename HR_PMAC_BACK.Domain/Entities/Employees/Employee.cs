using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;
using HR_PMAC_BACK.Domain.Entities.Employees.Enums;

namespace HR_PMAC_BACK.Domain.Entities.Employees
{
    public class Employee : Base<Guid>
    {
        // ======================================================
        // Core Identity
        // ======================================================

        /// <summary>
        /// الرقم الوظيفي
        /// </summary>
        public string EmployeeNumber { get; private set; }

        /// <summary>
        /// رقم الأرشيف (رقم إضبارة الموظف)
        /// </summary>
        public string ArchiveNumber { get; private set; }

        /// <summary>
        /// الحالة الوظيفية (فعال، متقاعد، تارك العمل ...)
        /// </summary>
        public EmployeeStatus Status { get; private set; }

        // ======================================================
        // Hire Information
        // ======================================================

        /// <summary>
        /// تاريخ التعيين (Hire Date)
        /// </summary>
        public DateTime HireDate { get; private set; }

        /// <summary>
        /// رقم كتاب التعيين
        /// </summary>
        public string? HireBookNumber { get; private set; }

        public DateTime? HireBookDate { get; private set; }

        public string? HireBookFilePath { get; private set; }

        /// <summary>
        /// تاريخ المباشرة
        /// </summary>
        public DateTime? StartWorkDate { get; private set; }

        public DateTime? StartWorkBookDate { get; private set; }

        public string? StartWorkBookFilePath { get; private set; }

        // ======================================================
        // Special Employee Status (Enum)
        // ======================================================

        /// <summary>
        /// الحالات الخاصة للموظف
        /// </summary>
        /// مفصول سياسي,من ذوي الشهداء,لديه خدمة عسكرية
        public SpecialEmpStatus SpecialEmpStatus { get; private set; }

        // ======================================================
        // Arabic Name
        // ======================================================

        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string ThirdName { get; private set; }
        public string FourthName { get; private set; }
        public string LastName { get; private set; }
        public string SureName { get; private set; }
        public string MotherName { get; private set; }

        // ======================================================
        // English Name
        // ======================================================

        public string? FullNameEnglish { get; private set; }

        // ======================================================
        // Personal Attributes
        // ======================================================

        public Gender Gender { get; private set; }
        public Religion Religion { get; private set; }
        public Ethnicity Ethnicity { get; private set; }
        public BloodGroup? BloodGroup { get; private set; }
        public DateTime? BirthDate { get; private set; }

        // ======================================================
        // Family Info
        // ======================================================

        public MaritalStatus MaritalStatus { get; private set; }

        // ======================================================
        // Contact Info
        // ======================================================

        public string? PhoneNumber { get; private set; }
        public string? Email { get; private set; }

        private Employee() { }

        // ======================================================
        // Constructor
        // ======================================================

        public Employee(
            string employeeNumber,
            string archiveNumber,
            string firstName,
            Gender gender,
            Religion religion,
            Ethnicity ethnicity,
            DateTime hireDate,
            Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(employeeNumber))
                throw new ArgumentException("Employee number required.");

            if (string.IsNullOrWhiteSpace(archiveNumber))
                throw new ArgumentException("Archive number required.");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name required.");

            if (hireDate == default)
                throw new ArgumentException("Hire date is required.");

            Id = Guid.NewGuid();

            EmployeeNumber = employeeNumber.Trim();
            ArchiveNumber = archiveNumber.Trim();
            FirstName = firstName.Trim();

            Gender = gender;
            Religion = religion;
            Ethnicity = ethnicity;

            HireDate = hireDate;

            Status = EmployeeStatus.Active;
            SpecialEmpStatus = SpecialEmpStatus.None;

            SetCreated(userGuid);
        }

        // ======================================================
        // Hire Info Update
        // ======================================================

        public void UpdateHireInfo(
            DateTime hireDate,
            string? hireBookNumber,
            DateTime? hireBookDate,
            string? hireBookFilePath,
            DateTime? startWorkDate,
            DateTime? startWorkBookDate,
            string? startWorkBookFilePath,
            Guid userGuid)
        {
            if (hireDate == default)
                throw new ArgumentException("Hire date is required.");

            HireDate = hireDate;

            HireBookNumber = hireBookNumber?.Trim();
            HireBookDate = hireBookDate;
            HireBookFilePath = hireBookFilePath?.Trim();

            StartWorkDate = startWorkDate;
            StartWorkBookDate = startWorkBookDate;
            StartWorkBookFilePath = startWorkBookFilePath?.Trim();

            Touch(userGuid);
        }

        // ======================================================
        // Update Archive Number
        // ======================================================

        public void UpdateArchiveNumber(string archiveNumber, Guid userGuid)
        {
            if (string.IsNullOrWhiteSpace(archiveNumber))
                throw new ArgumentException("Archive number required.");

            ArchiveNumber = archiveNumber.Trim();
            Touch(userGuid);
        }

        // ======================================================
        // Special Employee Status Update
        // ======================================================

        public void UpdateSpecialEmpStatus(
            SpecialEmpStatus specialEmpStatus,
            Guid userGuid)
        {
            if (!Enum.IsDefined(typeof(SpecialEmpStatus), specialEmpStatus))
                throw new ArgumentException("Invalid special employee status.");

            SpecialEmpStatus = specialEmpStatus;
            Touch(userGuid);
        }

        // ======================================================
        // Change Employment Status
        // ======================================================

        public void ChangeStatus(EmployeeStatus status, Guid userGuid)
        {
            Status = status;
            Touch(userGuid);
        }
    }
}
//using System;
//using HR_PMAC_BACK.Domain.Common.BaseEntities;
//using HR_PMAC_BACK.Domain.Entities.Employees.Enums;

//namespace HR_PMAC_BACK.Domain.Entities.Employees
//{
//    public class Employee : Base<Guid>
//    {
//        // ======================================================
//        // Core Identity
//        // ======================================================

//        /// <summary>
//        /// الرقم الوظيفي
//        /// </summary>
//        public string EmployeeNumber { get; private set; }

//        /// <summary>
//        /// رقم الأرشيف (رقم إضبارة الموظف)
//        /// </summary>
//        public string ArchiveNumber { get; private set; }

//        /// <summary>
//        /// الحالة الوظيفية (فعال، متقاعد، تارك العمل ...)
//        /// </summary>
//        public EmployeeStatus Status { get; private set; }

//        // ======================================================
//        // Hire Information
//        // ======================================================

//        /// <summary>
//        /// تاريخ التعيين (Hire Date)
//        /// </summary>
//        public DateTime HireDate { get; private set; }

//        /// <summary>
//        /// رقم كتاب التعيين
//        /// </summary>
//        public string? HireBookNumber { get; private set; }

//        public DateTime? HireBookDate { get; private set; }

//        public string? HireBookFilePath { get; private set; }

//        /// <summary>
//        /// تاريخ المباشرة
//        /// </summary>
//        public DateTime? StartWorkDate { get; private set; }

//        public DateTime? StartWorkBookDate { get; private set; }

//        public string? StartWorkBookFilePath { get; private set; }

//        // ======================================================
//        // Special Legal Status (Enum)
//        // ======================================================

//        /// <summary>
//        /// الحالة القانونية الخاصة
//        /// </summary>
//        public SpecialEmpStatus SpecialEmpStatus { get; private set; }

//        // ======================================================
//        // Arabic Name
//        // ======================================================

//        public string FirstName { get; private set; }
//        public string SecondName { get; private set; }
//        public string ThirdName { get; private set; }
//        public string FourthName { get; private set; }
//        public string LastName { get; private set; }
//        public string SureName { get; private set; }
//        public string MotherName { get; private set; }

//        // ======================================================
//        // English Name
//        // ======================================================

//        public string? FullNameEnglish { get; private set; }

//        // ======================================================
//        // Personal Attributes
//        // ======================================================

//        public Gender Gender { get; private set; }
//        public Religion Religion { get; private set; }
//        public Ethnicity Ethnicity { get; private set; }
//        public BloodGroup? BloodGroup { get; private set; }
//        public DateTime? BirthDate { get; private set; }

//        // ======================================================
//        // Family Info
//        // ======================================================

//        public MaritalStatus MaritalStatus { get; private set; }

//        // ======================================================
//        // Contact Info
//        // ======================================================

//        public string? PhoneNumber { get; private set; }
//        public string? Email { get; private set; }

//        private Employee() { }

//        // ======================================================
//        // Constructor
//        // ======================================================

//        public Employee(
//            string employeeNumber,
//            string archiveNumber,
//            string firstName,
//            Gender gender,
//            Religion religion,
//            Ethnicity ethnicity,
//            DateTime hireDate,
//            Guid userGuid)
//        {
//            if (string.IsNullOrWhiteSpace(employeeNumber))
//                throw new ArgumentException("Employee number required.");

//            if (string.IsNullOrWhiteSpace(archiveNumber))
//                throw new ArgumentException("Archive number required.");

//            if (string.IsNullOrWhiteSpace(firstName))
//                throw new ArgumentException("First name required.");

//            if (hireDate == default)
//                throw new ArgumentException("Hire date is required.");

//            Id = Guid.NewGuid();

//            EmployeeNumber = employeeNumber.Trim();
//            ArchiveNumber = archiveNumber.Trim();
//            FirstName = firstName.Trim();

//            Gender = gender;
//            Religion = religion;
//            Ethnicity = ethnicity;

//            HireDate = hireDate;
//            Status = EmployeeStatus.Active;
//            SpecialLegalStatus = SpecialEmpStatus.None;

//            SetCreated(userGuid);
//        }

//        // ======================================================
//        // Hire Info Update
//        // ======================================================

//        public void UpdateHireInfo(
//            DateTime hireDate,
//            string? hireBookNumber,
//            DateTime? hireBookDate,
//            string? hireBookFilePath,
//            DateTime? startWorkDate,
//            DateTime? startWorkBookDate,
//            string? startWorkBookFilePath,
//            Guid userGuid)
//        {
//            if (hireDate == default)
//                throw new ArgumentException("Hire date is required.");

//            HireDate = hireDate;

//            HireBookNumber = hireBookNumber?.Trim();
//            HireBookDate = hireBookDate;
//            HireBookFilePath = hireBookFilePath?.Trim();

//            StartWorkDate = startWorkDate;
//            StartWorkBookDate = startWorkBookDate;
//            StartWorkBookFilePath = startWorkBookFilePath?.Trim();

//            Touch(userGuid);
//        }

//        // ======================================================
//        // Update Archive Number
//        // ======================================================

//        public void UpdateArchiveNumber(string archiveNumber, Guid userGuid)
//        {
//            if (string.IsNullOrWhiteSpace(archiveNumber))
//                throw new ArgumentException("Archive number required.");

//            ArchiveNumber = archiveNumber.Trim();
//            Touch(userGuid);
//        }

//        // ======================================================
//        // Special Legal Status Update
//        // ======================================================

//        public void UpdateSpecialLegalStatus(
//            SpecialEmpStatus specialLegalStatus,
//            Guid userGuid)
//        {
//            if (!Enum.IsDefined(typeof(SpecialEmpStatus), specialLegalStatus))
//                throw new ArgumentException("Invalid special legal status.");

//            SpecialLegalStatus = specialLegalStatus;
//            Touch(userGuid);
//        }

//        // ======================================================
//        // Change Employment Status
//        // ======================================================

//        public void ChangeStatus(EmployeeStatus status, Guid userGuid)
//        {
//            Status = status;
//            Touch(userGuid);
//        }
//    }
//}


