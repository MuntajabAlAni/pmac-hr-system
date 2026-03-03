using System;
using HR_PMAC_BACK.Domain.Common.BaseEntities;
using HR_PMAC_BACK.Domain.Entities.Employees;
using HR_PMAC_BACK.Domain.Entities.Certifications;

namespace HR_PMAC_BACK.Domain.Entities.EmployeeCertifications
{
    /// <summary>
    /// يمثل شهادة تخص موظف معين داخل النظام
    /// (كيان رابط يحتوي بيانات أكاديمية وإدارية إضافية)
    /// </summary>
    public class EmployeeCertification : Base<int>
    {
        // =====================================================
        // العلاقات (Foreign Keys)
        // =====================================================

        /// <summary>
        /// رقم الموظف (GUID)
        /// </summary>
        public Guid EmployeeId { get; private set; }

        /// <summary>
        /// كيان الموظف المرتبط
        /// </summary>
        public Employee Employee { get; private set; }

        /// <summary>
        /// رقم نوع الشهادة (من جدول الشهادات العام)
        /// </summary>
        public int CertificationId { get; private set; }

        /// <summary>
        /// كيان نوع الشهادة
        /// </summary>
        public Certification Certification { get; private set; }

        // =====================================================
        // المعلومات الأكاديمية
        // =====================================================

        /// <summary>
        /// اسم الجهة التعليمية (جامعة / معهد / مدرسة)
        /// </summary>
        public string InstitutionName { get; private set; }

        /// <summary>
        /// اسم الكلية (اختياري)
        /// </summary>
        public string? CollegeName { get; private set; }

        /// <summary>
        /// اسم القسم (اختياري)
        /// </summary>
        public string? DepartmentName { get; private set; }

        /// <summary>
        /// التخصص (اختياري)
        /// </summary>
        public string? Specialization { get; private set; }

        /// <summary>
        /// بلد التخرج (اختياري)
        /// </summary>
        public string? Country { get; private set; }

        /// <summary>
        /// سنة التخرج (اختياري)
        /// </summary>
        public int? GraduationYear { get; private set; }

        /// <summary>
        /// المعدل أو التقدير (اختياري)
        /// </summary>
        public string? GradeOrGpa { get; private set; }

        // =====================================================
        // معلومات الوثيقة الأصلية
        // =====================================================

        /// <summary>
        /// رقم الوثيقة
        /// </summary>
        public string DocumentNumber { get; private set; }

        /// <summary>
        /// تاريخ إصدار الوثيقة
        /// </summary>
        public DateTime? IssueDate { get; private set; }

        /// <summary>
        /// مسار ملف الشهادة الأصلية (PDF أو صورة)
        /// </summary>
        public string OriginalCertificateFilePath { get; private set; }

        // =====================================================
        // معلومات صحة الصدور (اختيارية)
        // =====================================================

        /// <summary>
        /// رقم صحة الصدور (اختياري)
        /// </summary>
        public string? AuthenticityApprovalNumber { get; private set; }

        /// <summary>
        /// تاريخ صحة الصدور (اختياري)
        /// </summary>
        public DateTime? AuthenticityApprovalDate { get; private set; }

        /// <summary>
        /// مسار ملف صحة الصدور (اختياري)
        /// </summary>
        public string? AuthenticityApprovalFilePath { get; private set; }

        // =====================================================
        // حقول التأثير الإداري
        // =====================================================

        /// <summary>
        /// هل تؤثر هذه الشهادة على العلاوة السنوية؟
        /// </summary>
        public bool AffectsAllowance { get; private set; }

        /// <summary>
        /// هل تؤثر هذه الشهادة على الترفيع؟
        /// </summary>
        public bool AffectsPromotion { get; private set; }

        /// <summary>
        /// تاريخ احتساب الشهادة لأغراض الترفيع أو العلاوة
        /// </summary>
        public DateTime? ConsiderationDate { get; private set; }

        /// <summary>
        /// ملاحظات إضافية
        /// </summary>
        public string? Notes { get; private set; }

        // =====================================================
        // المنشئ (Constructor)
        // =====================================================

        private EmployeeCertification() { } // مطلوب لـ EF Core

        public EmployeeCertification(
            Guid employeeId,
            int certificationId,
            string institutionName,
            string documentNumber,
            string originalCertificateFilePath,
            bool affectsAllowance,
            bool affectsPromotion,
            Guid userGuid)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("رقم الموظف غير صالح.");

            if (certificationId <= 0)
                throw new ArgumentException("نوع الشهادة غير صالح.");

            if (string.IsNullOrWhiteSpace(institutionName))
                throw new ArgumentException("اسم الجهة التعليمية مطلوب.");

            if (string.IsNullOrWhiteSpace(documentNumber))
                throw new ArgumentException("رقم الوثيقة مطلوب.");

            if (string.IsNullOrWhiteSpace(originalCertificateFilePath))
                throw new ArgumentException("ملف الشهادة الأصلية مطلوب.");

            EmployeeId = employeeId;
            CertificationId = certificationId;
            InstitutionName = institutionName.Trim();
            DocumentNumber = documentNumber.Trim();
            OriginalCertificateFilePath = originalCertificateFilePath;

            AffectsAllowance = affectsAllowance;
            AffectsPromotion = affectsPromotion;

            SetCreated(userGuid);
        }

        // =====================================================
        // تحديث البيانات
        // =====================================================

        public void UpdateDetails(
            string? collegeName,
            string? departmentName,
            string? specialization,
            string? country,
            int? graduationYear,
            string? gradeOrGpa,
            DateTime? issueDate,
            string? authenticityApprovalNumber,
            DateTime? authenticityApprovalDate,
            string? authenticityApprovalFilePath,
            DateTime? considerationDate,
            bool affectsAllowance,
            bool affectsPromotion,
            string? notes,
            Guid userGuid)
        {
            CollegeName = collegeName?.Trim();
            DepartmentName = departmentName?.Trim();
            Specialization = specialization?.Trim();
            Country = country?.Trim();
            GraduationYear = graduationYear;
            GradeOrGpa = gradeOrGpa?.Trim();
            IssueDate = issueDate;

            AuthenticityApprovalNumber = authenticityApprovalNumber?.Trim();
            AuthenticityApprovalDate = authenticityApprovalDate;
            AuthenticityApprovalFilePath = authenticityApprovalFilePath;

            ConsiderationDate = considerationDate;
            AffectsAllowance = affectsAllowance;
            AffectsPromotion = affectsPromotion;

            Notes = notes?.Trim();

            Touch(userGuid);
        }
    }
}