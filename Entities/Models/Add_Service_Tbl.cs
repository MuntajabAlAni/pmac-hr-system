using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Add_Service_Tbl
    {



        [DisplayName("Order_Id")]
        [Key]
        public int Order_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public String Emp_Name { get; set; }

        [DisplayName("رقم الامر")]
        public String Order_No { get; set; }

        [DisplayName("العدد")]
        public String Book_No { get; set; }


        [DisplayName("تاريخ الامر")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Order_Date { get; set; }


        [DisplayName("نوع الامر")]
        public int Order_Type_Id { get; set; }

    

        [DisplayName("من تاريخ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? From_Date { get; set; }


        [DisplayName("الى تاريخ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? To_Date { get; set; }


        [DisplayName("مجموع الايام")]
        public Double? Total_Days { get; set; }

        [DisplayName("عدد السنوات")]
        public int? Years { get; set; }


        [DisplayName("عدد الاشهر")]
        public int? Months { get; set; }

        [DisplayName("عدد الايام")]
        public int? Days { get; set; }

 
        [DisplayName("نوع الخدمة المضافة")]
        [Required]
        public String Add_Type { get; set; }


        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public String Notes { get; set; }


        [DisplayName("سارية التأثير على الاستحقاق الحالي؟")]
        [DefaultValue(1)]
        public int Running { get; set; }



        [DisplayName("رابط ملف المرفقات")]
        public string File_Path { get; set; }



        //------------relationship to employee && service typ------------------

        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Add_Service_To_Emp_rel { get; set; }



        [ForeignKey("Order_Type_Id")]
        public virtual Service_Type_Tbl Add_Service_To_Service_Type_rel { get; set; }

        //---------------------------------------------------------------------------




    }
}