using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class OfficialDocument
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("الموظف")]
        public Guid EmployeeId { get; set; }

        [DisplayName("نوع الوثيقة")]
        public Guid DocumentTypeId { get; set; }

        [DisplayName("العدد")]
        public string? IssueNumber { get; set; }

        [DisplayName("التاريخ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? IssueDate { get; set; }

        [DisplayName("الجهة/الموضوع")]
        public string? DestinationOrSubject { get; set; } // Combined Destination (Letter) and Subject (Order)

        [DisplayName("الموضوع")]
        public string? Subject { get; set; }

        [DisplayName("تاريخ المباشرة/الانفكاك")] // From Order
        [DataType(DataType.Date)]
        public DateTime? EffectiveDate { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }

        [DisplayName("الملف المرفق")]
        public string? FilePath { get; set; }

        // Relationships
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        [ForeignKey("DocumentTypeId")]
        public virtual OfficialDocumentType? DocumentType { get; set; }
    }
}
