using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Thanks_Tbl
    {
        [DisplayName("Thanks_Id")]
        [Key]
        public int Thanks_Id { get; set; }


        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }


        [DisplayName("اسم الموظف")]
        public String Emp_Name { get; set; }


        [DisplayName("الجهة المناحة")]
        public string Donor { get; set; }


        [DisplayName("نوع الكتاب")]
        public int Thanks_Type_Id { get; set; }


        [DisplayName("نوع الامر")]
        public string Thanks_Order_Type { get; set; }



        [DisplayName("رقم الامر")]
        public string Order_Count_No { get; set; }

        [DisplayName("العدد")]
        public string Thanks_No { get; set; }


        [DisplayName("تأريخ الامر ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Order_Date { get; set; }




        [DisplayName("يؤثر على العلاوة")]
        [Required]
        public string Raise_affected { get; set; }





        [DisplayName("رقم امر القدم")]
        public string Old_Order_Count_No { get; set; }

        
        [DisplayName("تأريخ امر القدم ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Old_Order_Date { get; set; }



        [DisplayName("running")]
        [DefaultValue(1)]
        public int Running { get; set; }


      



        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Thanks_Notes { get; set; }

        [DisplayName("سبب المنح")]
        public string Thanks_Reasone { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string File_Path { get; set; }


        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Thanks_To_Emp_rel { get; set; }



        [ForeignKey("Thanks_Type_Id")]
        public virtual Thanks_Type_Tbl Thanks_To_Thanks_Type_rel { get; set; }
        //---------------------------------------------------------------------------

    }
}