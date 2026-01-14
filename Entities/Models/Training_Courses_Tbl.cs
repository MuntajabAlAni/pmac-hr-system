using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRN.Models
{
    public class Training_Courses_Tbl
    {


        [DisplayName("Course_Id")]
        [Key]
        public int Course_Id { get; set; }



        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }


        [DisplayName("اسم الموظف")]
        public String Emp_Name { get; set; }



        [DisplayName("رقم الامر الخاص بالدورة")]
        public string Order_No { get; set; }


        [DisplayName(" تأريخ الامر الاداري ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Order_Date { get; set; }



        [DisplayName("اسم الدورة")]
        public string Course_Name { get; set; }


        [DisplayName("الجهة الممولة للدورة")]
        public string Sponsoure { get; set; }


        [DisplayName("الجهة المقيمة للدورة")]
        public string Course_Evaluator { get; set; }



        [DisplayName("عدد أيام الدورة")]
        public string No_Of_Days { get; set; }


   
        [DisplayName(" تأريخ بدأ الدورة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Start_Date { get; set; }

        [DisplayName(" تأريخ انتهاء الدورة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? End_Date { get; set; }

        [DisplayName(" تأريخ الانفكاك ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Detachment_Date { get; set; }

        [DisplayName(" تأريخ المباشرة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Initiation_Date { get; set; }


        [DisplayName("التقييم")]
        public string Evaluation { get; set; }

        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Course_Notes { get; set; }





        [DisplayName("رابط ملف المرفقات")]
        public string File_Path { get; set; }





        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Training_To_Emp_rel { get; set; }


    }
}