using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Raise
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }

        [DisplayName("نوع الامر")]
        public Guid RaiseTypeId { get; set; }

        [DisplayName("رقم الامر")]
        public string? OrderNumber { get; set; }

        [DisplayName("تاريخ الامر")]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        [DisplayName("تاريخ النفاذ")]
        [DataType(DataType.Date)]
        public DateTime? EffectiveDate { get; set; } // Renamed/Mapped from CurrentRaiseDate to match DB

        [DisplayName("الراتب السابق")]
        public string? OldSalary { get; set; } // Mapped from Salary

        [DisplayName("الراتب الحالي")]
        public string? NewSalary { get; set; }

        [DisplayName("الدرجة السابقة")]
        public Guid? OldGradeId { get; set; } // Mapped from GradeId

        [DisplayName("الدرجة الحالية")]
        public Guid? NewGradeId { get; set; } // Changed from int to Guid

        [DisplayName("المرحلة السابقة")]
        public Guid? OldStepId { get; set; } // Mapped from StepId

        [DisplayName("المرحلة الحالية")]
        public Guid? NewStepId { get; set; } // Changed from int to Guid

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }

        // Additional properties from previous model preserved but optional/ignored by Dapper if not in query
        public string? NewGradeString { get; set; }
        public string? NewStepString { get; set; }
        public string? NextGradeString { get; set; }
        public string? NextStepString { get; set; }
        public Guid? NewJobTitleId { get; set; }
        public string? NewJobTitleString { get; set; }
        public string? NextJobTitleString { get; set; }
        public DateTime? NextRaiseDate { get; set; }
        public string? AutoManual { get; set; }
        public string? NextRaisePromotion { get; set; }
        public string? CycledDays { get; set; }
        public string? FilePath { get; set; }
        public bool IsLastRP { get; set; }
        public bool IsRecord { get; set; }
        public bool IsSuspended { get; set; }
        public string? Education { get; set; }
        
        // Relationships
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        [ForeignKey("RaiseTypeId")]
        public virtual RaiseType? RaiseType { get; set; }

        [ForeignKey("OldGradeId")]
        public virtual Grade? OldGrade { get; set; }

        [ForeignKey("NewGradeId")]
        public virtual Grade? NewGrade { get; set; }

        [ForeignKey("OldStepId")]
        public virtual Step? OldStep { get; set; }

        [ForeignKey("NewStepId")]
        public virtual Step? NewStep { get; set; }
    }
}
