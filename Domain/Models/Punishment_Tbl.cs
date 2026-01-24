using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Punishment_Tbl
    {


        [DisplayName("Punishment_Id")]
        [Key]
        public int Punishment_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public String Emp_Name { get; set; }


        [DisplayName("جهة اصدار العقوبة")]
        public string Punisher_Name { get; set; }


        [DisplayName("نوع العقوبة")]
        public int Punish_Type_Id { get; set; }



        //--------------------------rRelation----------------------------------------
        [ForeignKey("Punish_Type_Id")]
        public virtual Punish_Types_Tbl Punishments_To_Punish_Type_Rel { get; set; }
        //---------------------------------------------------------------------------


        [DisplayName("رقم الامر")]
        public string Order_No { get; set; }


        [DisplayName("تأريخ الامر ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Order_Date { get; set; }



        [DisplayName("السبب")]
        [DataType(DataType.MultilineText)]
        public string Reason { get; set; }



        [DisplayName("يؤثر على العلاوة؟")]
        [Required]
        public string Affect_Raise { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string File_Path { get; set; }




        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Punishment_To_Emp_rel { get; set; }
        //---------------------------------------------------------------------------


    }
}