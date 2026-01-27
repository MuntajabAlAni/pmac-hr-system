using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class LogFile
    {
        [DisplayName("Log_Id")]
        [Key]
        public int Log_Id { get; set; }


        [DisplayName("مستخدم النظام")]
        public string User_Name { get; set; }


        [DisplayName("وقت الحركة")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Entry_Time { get; set; }



        [DisplayName("نوع الحركة")]
        public string Entry_Type { get; set; }



        [DisplayName("نوع البيانات")]
        public string Entry_Table { get; set; }


        [DisplayName("رقم القيد المعدل")]
        public int Record_Id { get; set; }


        [DisplayName("وصف الحركة")]
        public string Notification_String { get; set; }


        [DisplayName("الموظف المعدلة بياناته")]
        public string Emp_Name { get; set; }

        [DisplayName("رابط الحركة")]
        public string Link { get; set; }



        [DisplayName("Military")]
        [DefaultValue(0)]
        public int Military { get; set; }




    }
}