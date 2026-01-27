using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Deligation
    {


        [DisplayName("Deligation_Id")]
        [Key]
        public int Deligation_Id { get; set; }


        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public string Emp_Name { get; set; }


        [DisplayName("وجهة الايفاد")]
        public string Destination { get; set; }


        [DisplayName("الجهة الممولة")]
        public string Sponsor { get; set; }


        [DisplayName("موضوع الايفاد")]
        public string Subject { get; set; }


        [DisplayName("العنوان")]
        public string Title { get; set; }


        [DisplayName("الجهة المقيمة لدورة")]
        public string Evaluator { get; set; }

        [DisplayName("عدد ايام الايفاد الفعلية")]
        public string Actual_Days { get; set; }


        [DisplayName("عدد ايام السفر ")]
        public string Travel_Days { get; set; }


        [DisplayName("تأريخ السفر ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Travel_Date { get; set; }


        [DisplayName("رقم الامر الاداري")]
        public string Order_No { get; set; }


        [DisplayName("تاريخ الامر الاداري ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Order_Date { get; set; }

        [DisplayName("تاريخ المباشرة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Initiation_Date { get; set; }



        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]

        public string Notes { get; set; }



        [DisplayName("رابط ملف المرفقات")]
        public string File_Path { get; set; }




        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee Deligation_To_Emp_rel { get; set; }
        //---------------------------------------------------------------------------

    }
}
