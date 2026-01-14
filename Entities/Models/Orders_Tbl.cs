using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Orders_Tbl
    {

        [DisplayName("Order_Id")]
        [Key]
        public int Order_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public String Emp_Name { get; set; }



        [DisplayName("رقم الامر")]
        public string Order_Count_No { get; set; }

        [DisplayName("العدد")]
        public string Order_No { get; set; }

        [DisplayName("تأريخ الامر ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Order_Date { get; set; }

        [DisplayName("نوع الامر")]
        public int Order_Type { get; set; }



        //--------------------------rRelation----------------------------------------
        [ForeignKey("Order_Type")]
        public virtual Administrative_Order_Types Orders_To_OrdersType_rel { get; set; }
        //---------------------------------------------------------------------------



        [DisplayName("الموضوع")]
        public string Order_Subject { get; set; }


        [DisplayName("تأريخ المباشرة أو الانفكاك ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Direct_Date { get; set; }



        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Order_Notes { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string File_Path { get; set; }


        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Orders_To_Emp_rel { get; set; }
        //---------------------------------------------------------------------------


    }
}