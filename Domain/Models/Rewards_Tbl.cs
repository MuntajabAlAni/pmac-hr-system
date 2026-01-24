using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Rewards_Tbl
    {

        [DisplayName("Reward_Id")]
        [Key]
        public int Reward_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public String Emp_Name { get; set; }


        [DisplayName("الجهة المانحة")]
        public String Reward_Giver { get; set; }

        [DisplayName("مبلغ المكافأة")]
        public String Reward_Amount { get; set; }

        [DisplayName("سبب المكافئة")]
        public String Reward_Reason { get; set; }

        [DisplayName("نوع الامر")]
        public String Order_Type { get; set; }

        [DisplayName("رقم الامر الاداري")]
        public String Order_No { get; set; }

        [DisplayName("تاريخ الامر الاداري")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Order_Date { get; set; }

        [DisplayName("رابط ملف المرفقات")]
        public string File_Path { get; set; }


        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Tasks_To_Emp_rel { get; set; }

    }
}