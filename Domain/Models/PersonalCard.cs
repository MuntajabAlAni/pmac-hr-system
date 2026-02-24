using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class PersonalCard
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("EmployeeId")]
    public Guid EmployeeId { get; set; }

    public string? EmployeeName { get; set; } // Not mapped to DB, used for display

    [DisplayName("رقم الهوية")]
    public string? CardNumber { get; set; }

    [DisplayName("تأريخ الاصدار")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? IssuanceDate { get; set; }

    [DisplayName("تأريخ النفاذ")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? ExpiryDate { get; set; }

    [DisplayName("مسار الملف")]
    public string? FilePath { get; set; }

    // Navigation property
    public virtual Employee? Employee { get; set; }
}
