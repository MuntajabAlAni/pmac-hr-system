using System;
using Domain.Common.BaseEntities;

namespace Domain.Entities.Employees
{
    /// <summary>
    /// يمثل مستمسكات الموظف (منفصلة عن جدول الموظف)
    /// كل مستمسك يحتوي على وجه وظهر كملفين منفصلين
    /// مع إضافة جهة الإصدار (اختيارية)
    /// </summary>
    public class EmployeeDocuments : Base<Guid>
    {
        public Guid EmployeeId { get; private set; }

        // =============================
        // General Notes
        // =============================

        public string? Notes { get; private set; }

        // =============================
        // Profile Picture
        // =============================

        public string? ProfileImagePath { get; private set; }

        // =============================
        // National ID
        // =============================

        public string NationalIdNumber { get; private set; }
        public DateTime NationalIdIssueDate { get; private set; }

        /// <summary>
        /// جهة إصدار الهوية (اختياري)
        /// </summary>
        public string? NationalIdIssuingAuthority { get; private set; }

        public string? NationalIdFrontImagePath { get; private set; }
        public string? NationalIdBackImagePath { get; private set; }

        // =============================
        // Housing Card
        // =============================

        public string HousingCardNumber { get; private set; }
        public DateTime HousingCardIssueDate { get; private set; }

        /// <summary>
        /// جهة إصدار بطاقة السكن (اختياري)
        /// </summary>
        public string? HousingCardIssuingAuthority { get; private set; }

        public string? HousingCardFrontImagePath { get; private set; }
        public string? HousingCardBackImagePath { get; private set; }

        // =============================
        // Address Details
        // =============================

        /// <summary>
        /// المحافظة (اختياري)
        /// </summary>
        public string? Governorate { get; private set; }

        /// <summary>
        /// المدينة (اختياري)
        /// </summary>
        public string? City { get; private set; }

        /// <summary>
        /// المحلة (مطلوب)
        /// </summary>
        public string Block { get; private set; }

        /// <summary>
        /// الزقاق (مطلوب)
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// رقم الدار (مطلوب)
        /// </summary>
        public string HouseNo { get; private set; }

        // =============================
        // Passport (Optional)
        // =============================

        public string? PassportNumber { get; private set; }
        public DateTime? PassportIssueDate { get; private set; }

        /// <summary>
        /// جهة إصدار الجواز (اختياري)
        /// </summary>
        public string? PassportIssuingAuthority { get; private set; }

        public string? PassportFrontImagePath { get; private set; }
        public string? PassportBackImagePath { get; private set; }

        // =============================
        // Badge (Optional)
        // =============================

        public string? BadgeNumber { get; private set; }
        public DateTime? BadgeIssueDate { get; private set; }

        /// <summary>
        /// جهة إصدار الباج (اختياري)
        /// </summary>
        public string? BadgeIssuingAuthority { get; private set; }

        public string? BadgeFrontImagePath { get; private set; }
        public string? BadgeBackImagePath { get; private set; }

        // =============================
        // CV (Optional)
        // =============================

        public string? CvFilePath { get; private set; }

        private EmployeeDocuments() { }

        // ======================================================
        // Constructor
        // ======================================================

        public EmployeeDocuments(
            Guid employeeId,
            string nationalIdNumber,
            DateTime nationalIdIssueDate,
            string housingCardNumber,
            DateTime housingCardIssueDate,
            string block,
            string street,
            string houseNo,
            Guid userGuid)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("Invalid EmployeeId.");

            if (string.IsNullOrWhiteSpace(nationalIdNumber))
                throw new ArgumentException("National ID required.");

            if (string.IsNullOrWhiteSpace(housingCardNumber))
                throw new ArgumentException("Housing card required.");

            if (string.IsNullOrWhiteSpace(block))
                throw new ArgumentException("Block is required.");

            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street is required.");

            if (string.IsNullOrWhiteSpace(houseNo))
                throw new ArgumentException("House number is required.");

            EmployeeId = employeeId;

            NationalIdNumber = nationalIdNumber.Trim();
            NationalIdIssueDate = nationalIdIssueDate;

            HousingCardNumber = housingCardNumber.Trim();
            HousingCardIssueDate = housingCardIssueDate;

            Block = block.Trim();
            Street = street.Trim();
            HouseNo = houseNo.Trim();

            SetCreated(userGuid);
        }

        // ======================================================
        // Update Issuing Authorities
        // ======================================================

        public void UpdateNationalIdAuthority(string? authority, Guid userGuid)
        {
            NationalIdIssuingAuthority = authority?.Trim();
            Touch(userGuid);
        }

        public void UpdateHousingCardAuthority(string? authority, Guid userGuid)
        {
            HousingCardIssuingAuthority = authority?.Trim();
            Touch(userGuid);
        }

        public void UpdatePassportAuthority(string? authority, Guid userGuid)
        {
            PassportIssuingAuthority = authority?.Trim();
            Touch(userGuid);
        }

        public void UpdateBadgeAuthority(string? authority, Guid userGuid)
        {
            BadgeIssuingAuthority = authority?.Trim();
            Touch(userGuid);
        }

        // باقي الدوال كما هي بدون تغيير...
    }
}