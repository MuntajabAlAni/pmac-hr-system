using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Committee
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }

        [DisplayName("اسم الموظف")]
        public string? EmployeeName { get; set; }

        [DisplayName("نوع اللجنة")]
        public required string CommitteeType { get; set; }

        [DisplayName("رقم امر اللجنة")]
        public required string CommitteeOrderNumber { get; set; }

        [DisplayName("تأريخ الامر ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [DisplayName("نوع مدة اللجنة")]
        public string? CommitteeDurationType { get; set; }

        [DisplayName("عدد أيام اللجنة")]
        public string? NumberOfDays { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? CommitteeNotes { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string? FilePath { get; set; }

        //--------------------------Relationships----------------------------------------
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
}
