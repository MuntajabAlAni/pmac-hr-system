using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class AddedService
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }

        [DisplayName("اسم الموظف")]
        public required string EmployeeName { get; set; }

        [DisplayName("رقم الامر")]
        public required string OrderNumber { get; set; }

        [DisplayName("رقم الكتاب")]
        public required string BookNumber { get; set; }

        [DisplayName("تاريخ الامر")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [DisplayName("نوع الامر")]
        public Guid OrderTypeId { get; set; }

        [DisplayName("من تاريخ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }

        [DisplayName("الى تاريخ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate { get; set; }

        [DisplayName("مجموع الايام")]
        public double? TotalDays { get; set; }

        [DisplayName("عدد السنوات")]
        public int? Years { get; set; }

        [DisplayName("عدد الاشهر")]
        public int? Months { get; set; }

        [DisplayName("عدد الايام")]
        public int? Days { get; set; }

        [DisplayName("نوع الخدمة المضافة")]
        [Required]
        public required string AddedType { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public required string Notes { get; set; }

        [DisplayName("سارية التأثير على الاستحقاق الحالي؟")]
        [DefaultValue(true)]
        public bool IsRunning { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public required string FilePath { get; set; }

        //------------relationship to employee && service typ------------------

        //--------------------------rRelation----------------------------------------
        [ForeignKey("EmployeeId")]
        public virtual required Employee Employee { get; set; }

        [ForeignKey("ServiceTypeId")]
        public virtual required Service_Type_Tbl ServiceType { get; set; }
        //---------------------------------------------------------------------------
    }
}
