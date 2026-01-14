using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRN.Models
{
    public class Vacation_Tbl
    {



        [DisplayName("Vacation_Id")]
        [Key]
        public int Vacation_Id { get; set; }


        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }


        [DisplayName("اسم الموظف")]
        public String Emp_Name { get; set; }


        // 

        [DisplayName("رقم الامر الاداري")]
        public string Order_Issue_No { get; set; }

        //

        [DisplayName("تاريخ الامر الاداري")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Order_Issue_Date { get; set; }


        //
        [DisplayName("نوع الاجازة")]
        public int Vacation_Type_Id { get; set; }


        //--------------------------rRelation----------------------------------------
        [ForeignKey("Vacation_Type_Id")]
        public virtual Vacation_Type_Tbl Vacation_To_Vac_Type_rel { get; set; }
        //---------------------------------------------------------------------------




        //------salary
        [DisplayName("الايام")]
        [DefaultValue(0)]
        public int No_Of_Days { get; set; }

        [DisplayName("الاشهر")]
        [DefaultValue(0)]
        public int No_Of_Months { get; set; }

        [DisplayName("السنوات")]
        [DefaultValue(0)]
        public int No_Of_Years { get; set; }



        //------ without salary
        [DisplayName("الايام")]
        [DefaultValue(0)]
        public int No_Of_Days2 { get; set; }

        [DisplayName("الاشهر")]
        [DefaultValue(0)]
        public int No_Of_Months2 { get; set; }

        [DisplayName("السنوات")]
        [DefaultValue(0)]
        public int No_Of_Years2 { get; set; }












        //
        [DisplayName("تاريخ التمتع بالاجازة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Start_Date { get; set; }



        //
        [DisplayName("رقم أمر المباشرة")]
        public string Vac_Dir_Ord_No { get; set; }//---was "Detachment_Book_ No"



        [DisplayName("العدد")]
        public string Book_No { get; set; }//---was "Detachment_Book_ No"




        //
        [DisplayName("تاريخ المباشرة الفعلي")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? End_Date { get; set; }   //--------was"Detachment_Book_ Date"




        ////
        //[DisplayName("تاريخ المباشرة الفعلي")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? End_Date { get; set; }   //--was Proceeding_ Date



        //
        [DisplayName("رقم كتاب المباشرة")]
        public string Proceeding_Book_No { get; set; }



        //
        [DisplayName("تاريخ كتاب المباشرة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Proceeding_Book_Date { get; set; }



        [DisplayName("سارية التأثير على الاستحقاق الحالي؟")]
        [DefaultValue(1)]
        public int Running { get; set; }





        //
        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Vac_Notes { get; set; }




        [DisplayName("رابط ملف المرفقات")]
        //[Required]
        public string File_Path { get; set; }




        //
        [DisplayName("اسم مدخل القيد")]
        public string UserName { get; set; }


        //
        [DisplayName("تاريخ ادخال القيد")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EntryDate { get; set; }













        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Vacation_To_Emp_rel { get; set; }
        //---------------------------------------------------------------------------


    }
}