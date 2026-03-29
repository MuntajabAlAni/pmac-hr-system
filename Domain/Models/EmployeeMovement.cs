using System;
using Domain.Common.BaseEntities;
using Domain.Entities.Employees;
using Domain.Entities.Organizations;
using Domain.Entities.Movements.Enums;

namespace Domain.Entities.Movements
{
    /// <summary>
    /// يمثل حركة إدارية للموظف
    /// (تكليف / تنسيب / نقل / منصب)
    /// ويغطي النقل الداخلي والخارجي
    /// </summary>
    public class EmployeeMovement : Base<Guid>
    {
        // =====================================================
        // الموظف
        // =====================================================

        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        // =====================================================
        // نوع الحركة
        // =====================================================

        public MovementType MovementType { get; private set; }
        // مثال: Transfer, Assignment, Delegation, Position

        public MovementScope Scope { get; private set; }
        // Internal / External

        public MovementDirection Direction { get; private set; }

        public MovementOrderLevel OrderLevel { get; private set; }

        // =====================================================
        // الهيكل الإداري الداخلي (اختياري عدا الجهة العليا بالنقل الداخلي)
        // =====================================================

        public int? FromHighAuthorityId { get; private set; }
        public HighAuthority? FromHighAuthority { get; private set; }

        public int? ToHighAuthorityId { get; private set; }
        public HighAuthority? ToHighAuthority { get; private set; }

        public int? FromDirectorateId { get; private set; }
        public int? FromDepartmentId { get; private set; }
        public int? FromSectionId { get; private set; }
        public int? FromUnitId { get; private set; }

        public int? ToDirectorateId { get; private set; }
        public int? ToDepartmentId { get; private set; }
        public int? ToSectionId { get; private set; }
        public int? ToUnitId { get; private set; }

        // =====================================================
        // الجهات الخارجية
        // =====================================================

        public int? FromExternalEntityId { get; private set; }
        public ExternalEntity? FromExternalEntity { get; private set; }

        public int? ToExternalEntityId { get; private set; }
        public ExternalEntity? ToExternalEntity { get; private set; }

        // =====================================================
        // بيانات المنصب (عند اختيار نوع الحركة = منصب)
        // =====================================================

        public int? PositionId { get; private set; }
        public Guid? JobTitleId { get; private set; }

        // =====================================================
        // بيانات الكتاب الإداري
        // =====================================================

        public string BookNumber { get; private set; }
        public DateTime BookDate { get; private set; }
        public string? FilePath { get; private set; }

        // =====================================================
        // مصادقة وزارة المالية (اختياري)
        // =====================================================

        public string? MoFApprovalNumber { get; private set; }
        public DateTime? MoFApprovalDate { get; private set; }
        public string? MoFApprovalType { get; private set; }

        // =====================================================
        // مدة الحركة
        // =====================================================

        public DateTime FromDate { get; private set; }
        public DateTime? ToDate { get; private set; }

        public bool IsActive { get; private set; }

        public string? Notes { get; private set; }

        private EmployeeMovement() { }

        public EmployeeMovement(
            Guid employeeId,
            MovementType movementType,
            MovementScope scope,
            MovementDirection direction,
            MovementOrderLevel orderLevel,
            string bookNumber,
            DateTime bookDate,
            DateTime fromDate,
            Guid userGuid,
            DateTime? toDate = null,
            int? fromHighAuthorityId = null,
            int? toHighAuthorityId = null,
            int? fromExternalEntityId = null,
            int? toExternalEntityId = null,
            int? positionId = null,
            Guid? jobTitleId = null,
            string? filePath = null,
            string? mofApprovalNumber = null,
            DateTime? mofApprovalDate = null,
            string? mofApprovalType = null,
            string? notes = null)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("الموظف غير صالح.");

            if (string.IsNullOrWhiteSpace(bookNumber))
                throw new ArgumentException("رقم الكتاب مطلوب.");

            if (toDate.HasValue && fromDate > toDate.Value)
                throw new ArgumentException("خطأ في مدة الحركة.");

            // شرط النقل الداخلي
            if (movementType == MovementType.Transfer &&
                scope == MovementScope.Internal &&
                (fromHighAuthorityId == null || toHighAuthorityId == null))
                throw new ArgumentException("النقل الداخلي يتطلب تحديد الجهة العليا.");

            // شرط الحركة الخارجية
            if (scope == MovementScope.External &&
                (fromExternalEntityId == null && toExternalEntityId == null))
                throw new ArgumentException("الحركة الخارجية تتطلب تحديد جهة خارجية.");

            EmployeeId = employeeId;
            MovementType = movementType;
            Scope = scope;
            Direction = direction;
            OrderLevel = orderLevel;

            FromHighAuthorityId = fromHighAuthorityId;
            ToHighAuthorityId = toHighAuthorityId;

            FromExternalEntityId = fromExternalEntityId;
            ToExternalEntityId = toExternalEntityId;

            PositionId = positionId;
            JobTitleId = jobTitleId;

            BookNumber = bookNumber.Trim();
            BookDate = bookDate;
            FilePath = filePath?.Trim();

            MoFApprovalNumber = mofApprovalNumber?.Trim();
            MoFApprovalDate = mofApprovalDate;
            MoFApprovalType = mofApprovalType?.Trim();

            FromDate = fromDate;
            ToDate = toDate;

            Notes = notes?.Trim();

            IsActive = true;

            SetCreated(userGuid);
        }

        public void Deactivate(Guid userGuid)
        {
            IsActive = false;
            Touch(userGuid);
        }

        public bool IsCurrent()
        {
            var today = DateTime.UtcNow.Date;

            if (!IsActive)
                return false;

            if (ToDate.HasValue)
                return today >= FromDate.Date && today <= ToDate.Value.Date;

            return today >= FromDate.Date;
        }
    }
}
//using System;
//using Domain.Common.BaseEntities;
//using Domain.Entities.Employees;
//using Domain.Entities.Organizations;
//using Domain.Entities.Movements.Enums;

//namespace Domain.Entities.Movements
//{
//    /// <summary>
//    /// يمثل حركة إدارية للموظف
//    /// (تكليف / تنسيب / نقل)
//    /// </summary>
//    public class EmployeeMovement : Base<Guid>
//    {
//        // =====================================================
//        // الموظف
//        // =====================================================

//        public Guid EmployeeId { get; private set; }
//        public Employee Employee { get; private set; }

//        // =====================================================
//        // نوع الحركة
//        // =====================================================

//        public MovementType MovementType { get; private set; }
//        public MovementScope Scope { get; private set; }
//        public MovementDirection Direction { get; private set; }
//        public MovementOrderLevel OrderLevel { get; private set; }

//        // =====================================================
//        // الجهات الداخلية (هرمية)
//        // =====================================================

//        // الجهة العليا (مطلوبة في النقل الداخلي)
//        public int? FromHighAuthorityId { get; private set; }
//        public HighAuthority FromHighAuthority { get; private set; }

//        public int? ToHighAuthorityId { get; private set; }
//        public HighAuthority ToHighAuthority { get; private set; }

//        // باقي الهيكل (اختياري)
//        public int? FromDepartmentId { get; private set; }
//        public int? FromDirectorateId { get; private set; }
//        public int? FromSectionId { get; private set; }
//        public int? FromDivisionId { get; private set; }
//        public int? FromUnitId { get; private set; }

//        public int? ToDepartmentId { get; private set; }
//        public int? ToDirectorateId { get; private set; }
//        public int? ToSectionId { get; private set; }
//        public int? ToDivisionId { get; private set; }
//        public int? ToUnitId { get; private set; }

//        // =====================================================
//        // الجهات الخارجية
//        // =====================================================

//        public int? FromExternalEntityId { get; private set; }
//        public ExternalEntity FromExternalEntity { get; private set; }

//        public int? ToExternalEntityId { get; private set; }
//        public ExternalEntity ToExternalEntity { get; private set; }

//        // =====================================================
//        // بيانات الكتاب
//        // =====================================================

//        public string BookNumber { get; private set; }
//        public DateTime BookDate { get; private set; }

//        // =====================================================
//        // المدة
//        // =====================================================

//        public DateTime FromDate { get; private set; }
//        public DateTime ToDate { get; private set; }

//        // =====================================================
//        // الملف
//        // =====================================================

//        public string? FilePath { get; private set; }

//        public bool IsActive { get; private set; }

//        public string? Notes { get; private set; }

//        private EmployeeMovement() { }

//        public EmployeeMovement(
//            Guid employeeId,
//            MovementType movementType,
//            MovementScope scope,
//            MovementDirection direction,
//            MovementOrderLevel orderLevel,
//            int? fromHighAuthorityId,
//            int? toHighAuthorityId,
//            int? fromExternalEntityId,
//            int? toExternalEntityId,
//            string bookNumber,
//            DateTime bookDate,
//            DateTime fromDate,
//            DateTime toDate,
//            string? filePath,
//            Guid userGuid)
//        {
//            if (employeeId == Guid.Empty)
//                throw new ArgumentException("الموظف غير صالح.");

//            if (string.IsNullOrWhiteSpace(bookNumber))
//                throw new ArgumentException("رقم الكتاب مطلوب.");

//            if (fromDate > toDate)
//                throw new ArgumentException("خطأ في المدة.");

//            // شرط النقل الداخلي
//            if (scope == MovementScope.Internal &&
//                (fromHighAuthorityId == null || toHighAuthorityId == null))
//                throw new ArgumentException("النقل الداخلي يتطلب تحديد الجهة العليا.");

//            // شرط الحركة الخارجية
//            if (scope == MovementScope.External &&
//                (fromExternalEntityId == null && toExternalEntityId == null))
//                throw new ArgumentException("الحركة الخارجية تتطلب تحديد جهة خارجية.");

//            EmployeeId = employeeId;
//            MovementType = movementType;
//            Scope = scope;
//            Direction = direction;
//            OrderLevel = orderLevel;

//            FromHighAuthorityId = fromHighAuthorityId;
//            ToHighAuthorityId = toHighAuthorityId;

//            FromExternalEntityId = fromExternalEntityId;
//            ToExternalEntityId = toExternalEntityId;

//            BookNumber = bookNumber.Trim();
//            BookDate = bookDate;

//            FromDate = fromDate;
//            ToDate = toDate;

//            FilePath = filePath?.Trim();

//            IsActive = true;

//            SetCreated(userGuid);
//        }

//        public void Deactivate(Guid userGuid)
//        {
//            IsActive = false;
//            Touch(userGuid);
//        }

//        public bool IsCurrent()
//        {
//            var today = DateTime.UtcNow.Date;
//            return IsActive &&
//                   today >= FromDate.Date &&
//                   today <= ToDate.Date;
//        }
//    }
//}