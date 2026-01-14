using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Consultants_Tasks_Tbl
    {

        [DisplayName("Task_Id")]
        [Key]
        public int Task_Id { get; set; }



        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public String Emp_Name { get; set; }



        [DisplayName("الموضوع")]
        [DataType(DataType.MultilineText)]

        public string Task_Subject { get; set; }



        [DisplayName("وصف المهمة")]
        //public string Task_Description { get; set; }//------------------------------------------------------
        public int Task_Description { get; set; }


        [DisplayName("تاريخ الاحالة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Task_Date { get; set; }



        [DisplayName("طبيعة العمل")]
        //public string Work_Nature { get; set; }//----------------------------------------------------------
        public int Work_Nature { get; set; }



        [DisplayName("حالة الاجراء")]
        //public string Task_Status { get; set; }//----------------------------------------------------------
        public int Task_Status { get; set; }



        [DisplayName("توصيف الاجراء")]
        //public string Pocedure_Description { get; set; }//-------------------------------------------------
        public int Pocedure_Description { get; set; }




        [DisplayName("وصف تقدم العمل")]
        [DataType(DataType.MultilineText)]

        public string Progress_Description { get; set; }


        [DisplayName("التوصيات")]
        [DataType(DataType.MultilineText)]

        public string Task_Recommendations { get; set; }




        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]

        public string Task_Notes { get; set; }




        [DisplayName("رابط ملف المرفقات")]
        //[Required]
        public string File_Path { get; set; }




        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Tasks_To_Emp_rel { get; set; }


        [ForeignKey("Task_Description")]
        public virtual Task_Description_Tbl Tasks_To_Task_Desc_rel { get; set; }


        [ForeignKey("Work_Nature")]
        public virtual Work_Nature_Tbl Tasks_To_Work_Nature_rel { get; set; }


        [ForeignKey("Task_Status")]
        public virtual Task_Status_Tbl Tasks_To_Task_Status_rel { get; set; }


        [ForeignKey("Pocedure_Description")]
        public virtual Procedure_Desc_Tbl Task_To_Procedure_Desc_rel { get; set; }



        //---------------------------------------------------------------------------



    }
}