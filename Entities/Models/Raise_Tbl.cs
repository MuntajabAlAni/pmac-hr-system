using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Raise_Tbl
    {


        [DisplayName("Raise_Id")]
        [Key]
        public int Raise_Id { get; set; }


        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }



        [DisplayName("اسم الموظف")]
        public string Emp_Name { get; set; }



        [DisplayName("رقم الامر")]
        public string Order_No { get; set; }


        [DisplayName("العدد")]
        public string Order_Count_No { get; set; }


        [DisplayName("تاريخ الامر")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Order_Date { get; set; }




        [DisplayName("نوع الامر")]
        public int Raise_Type_Id { get; set; }



        [DisplayName("الدرجة السابقة")]
        public int Grade_Id { get; set; }


        [DisplayName("المرحلة السابقة")]
        public int Step_Id { get; set; }


        [DisplayName("الراتب السابق")]
        public string Salary { get; set; }




        [DisplayName("العنوان الوظيفي السابق")]
        public int Job_Title_Id { get; set; }





        [DisplayName("تاريخ الاستحقاق السابق")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Last_Raise_Date { get; set; }





        [DisplayName("الدرجة الحالية")]
        public int New_Grade { get; set; }

        [DisplayName("الدرجة الحالية")]
        public string New_Grade_String { get; set; }


        [DisplayName("المرحلة الحالية")]
        public int New_Step { get; set; }

        [DisplayName("المرحلة الحالية")]
        public string New_Step_string { get; set; }

        //----------------

        [DisplayName("الدرجة القادمة")]
        public string Next_Grade_String { get; set; }


        [DisplayName("المرحلة القادمة")]
        public string Next_Step_string { get; set; }

        //-------------------
        [DisplayName("الراتب الحالي")]
        public string New_Salary { get; set; }



        [DisplayName("العنوان الوظيفي الحالي")]
        public int New_Job_Title_Id { get; set; }

        [DisplayName("العنوان الوظيفي الحالي")]
        public string New_Job_Title_string { get; set; }


        [DisplayName("العنوان الوظيفي القادم")]
        public string Next_Job_Title_string { get; set; }



        [DisplayName("تاريخ الاستحقاق الحالي")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Current_Raise_Date { get; set; }





        [DisplayName("تاريخ الاستحقاق القادم")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Next_Raise_Date { get; set; }




        [DisplayName("احتساب يدوي/ تلقائي")]
        [DefaultValue("تلقائي")]
        public string Auto_Manual { get; set; }


        [DisplayName("الاستحقاق القادم (علاوة/ ترفيع)")]
        public string Next_Raise_Promotion { get; set; }


        [DisplayName("عدد الايام المدورة")]
        public string Cycled_Days { get; set; }





        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]

        public String Notes { get; set; }


        //[DisplayName("Added_Service_Id")]
        //public int? Added_Service_Id { get; set; }



        [DisplayName("رابط ملف المرفقات")]
        public string File_Path { get; set; }





        [DisplayName("اخر علاوة أو ترفيع")]
        [DefaultValue(false)]
        //[Required]
        public bool Is_Last_RP { get; set; }





        [DisplayName("يطبع في المحضر القادم؟")]
        [DefaultValue(false)]
        //[Required]
        public bool IsRecord { get; set; }





        [DisplayName("العلاوة أة الترقية معلقة؟")]
        [DefaultValue(false)]
        //[Required]
        public bool IsSuspended { get; set; }



        [DisplayName("الشهادة لهذه الترقية")]
        public string Education { get; set; }



        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Raise_To_Emp_rel { get; set; }


        [ForeignKey("Raise_Type_Id")]
        public virtual Raise_Type_Tbl Raise_To_Raise_Type_rel { get; set; }



        [ForeignKey("Grade_Id")]
        public virtual Grade_Tbl Raise_To_Grade_rel { get; set; }


        [ForeignKey("Step_Id")]
        public virtual Step_Tbl Raise_To_Step_rel { get; set; }


        [ForeignKey("Job_Title_Id")]
        public virtual Job_Title_Tbl Raise_To_Job_Title_rel { get; set; }
        //---------------------------------------------------------------------------




    }
}