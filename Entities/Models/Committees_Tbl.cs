using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Committees_Tbl
    {


        [DisplayName("Committee_Id")]
        [Key]
        public int Order_Id { get; set; }


        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public String Emp_Name { get; set; }


        [DisplayName("نوع اللجنة")]
        public string Comm_Type { get; set; }


        [DisplayName("رقم امر اللجنة")]
        public string Comm_Order_No { get; set; }


        [DisplayName("تأريخ الامر ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Order_Date { get; set; }




        [DisplayName("نوع مدة اللجنة")]
        public string Comm_Duration_Type { get; set; }


        [DisplayName("عدد أيام اللجنة")]
        public string No_Of_Days { get; set; }


        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Comm_Notes { get; set; }



        [DisplayName("رابط ملف المرفقات")]
        public string File_Path { get; set; }


        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Orders_To_Emp_rel { get; set; }
        //---------------------------------------------------------------------------





    }
}