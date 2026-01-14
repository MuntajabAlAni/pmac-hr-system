using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Letters_Tbl
    {


        [DisplayName("Letter_Id")]
        [Key]
        public int Letter_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public String Emp_Name { get; set; }

        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Letters_To_Emp_rel { get; set; }
        //---------------------------------------------------------------------------


        [DisplayName("جهة المخاطبة")]
        public string Destination_Name { get; set; }

        [DisplayName("نوع الكتاب")]
        public int Letter_Type_Id { get; set; }

        //--------------------------rRelation----------------------------------------
        [ForeignKey("Letter_Type_Id")]
        public virtual Letter_Types_Tbl Letters_To_Letter_Type_Rel { get; set; }
        //---------------------------------------------------------------------------

        [DisplayName("العدد")]
        public string Order_No { get; set; }


        [DisplayName("تأريخ الامر ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Order_Date { get; set; }


        [DisplayName("الموضوع")]
        public string Subject { get; set; }


        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }


        [DisplayName("رابط ملف المرفقات")]
        public string File_Path { get; set; }




     

    }
}