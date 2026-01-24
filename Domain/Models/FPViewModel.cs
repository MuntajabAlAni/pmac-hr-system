using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class FPViewModel
    {


        [DisplayName("الاسم  الكامل")]
        public string Employee_F_Name { get; set; }



        [DisplayName("نوع الخدمة")]
        public int? Military { get; set; }




        [DisplayName("اسم الدائرة")]
        public int? Directorate_Id { get; set; }

        [DisplayName("اسم القسم")]
        public int? Department_Id { get; set; }





        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Career_Notes { get; set; }





        [DisplayName("المهام")]
        [DataType(DataType.MultilineText)]
        public string Work_Type { get; set; }




        [DisplayName("لديه بصمة الكترونية")]
        public int? hasFingerprint { get; set; }



        [DisplayName("حالة الاستثناء")]
        public int? Eception_Type { get; set; }



        [DisplayName("تأريخ تسجيل البصمة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FingerprintDate { get; set; }



    }
}