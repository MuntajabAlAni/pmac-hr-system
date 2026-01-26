using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class AddedService
    {
        [DisplayName("Order_Id")]
        [Key]
        public Guid OrderId { get; set; }

        [DisplayName("اسم الموظف")]
        public Guid EmployeeId { get; set; }

        [DisplayName("اسم الموظف")]
        public string EmployeeName { get; set; }

        [DisplayName("رقم الامر")]
        public string OrderNumber { get; set; }

        [DisplayName("رقم الكتاب")]
        public string BookNumber { get; set; }

        [DisplayName("تاريخ الامر")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [DisplayName("نوع الامر")]
        public int OrderTypeId { get; set; }

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
        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Add_Service_To_Emp_rel { get; set; }

        [ForeignKey("Order_Type_Id")]
        public virtual Service_Type_Tbl Add_Service_To_Service_Type_rel { get; set; }
        //---------------------------------------------------------------------------
    }
}
