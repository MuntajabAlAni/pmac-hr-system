using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRN.Models
{
    public class MilitaryModel
    {


        [DisplayName("Emp_Id")]
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Emp_Id { get; set; }



        //employee tbl-------------------------------------

        [DisplayName("الاسم  الكامل")]
        [Required]
        public string Employee_F_Name { get; set; }


        //------------------------------------------------Personal info



        //---career tbl -----------------------------------------------


        [DisplayName("الرتبة")]
        public int? rank_id { get; set; }



        [ForeignKey("rank_id")]
        public virtual Ranks_Tbl Military_To_Ranks_rel { get; set; }





        [DisplayName("الجهة المكلف منها")]
        [DataType(DataType.MultilineText)]

        public string Previous_Directorate { get; set; }



        [DisplayName("اسم الدائرة")]
        public int? Directorate_Id { get; set; }

        [DisplayName("اسم القسم")]
        public int? Department_Id { get; set; }

        [DisplayName("اسم الشعبة")]
        public Nullable<int> Section_Id { get; set; }


        [DisplayName("استمرارية الخدمة")]
        [Required]
        public int Continuation { get; set; }



        [DisplayName("الحالة الوظيفية")]
        public string Employment_Status { get; set; }


        //[DisplayName("المنصب العسكري")]
        //public string Basic_Salary { get; set; }



        //[DisplayName("اللواء")]
        //public string Consultant_agency { get; set; }


        //[DisplayName("الفوج")]
        //public string Work_Type { get; set; }


        //[DisplayName("السرية")]
        //public string Martyre_Related { get; set; }





        [DisplayName("رقم كتاب المباشرة")]
        public string Initiation_Book_No { get; set; }

        [DisplayName("تأريخ كتاب المباشرة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Initiation_Book_Date { get; set; }




        [DisplayName("تأريخ المباشرة الفعلي في المكتب")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Initiation_AtOffice_Book_Date { get; set; }




        [DisplayName("تأريخ انتهاء الخدمة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? End_Of_Service_Date { get; set; }


        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Career_Notes { get; set; }




        [DisplayName("لديه بصمة الكترونية")]
        [DefaultValue(0)]
        public int? hasFingerprint { get; set; }

        [DisplayName("تأريخ تسجيل البصمة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FingerprintDate { get; set; }






        [DisplayName("Military")]
        //[Required]
        [DefaultValue(1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? Military { get; set; }



        [DisplayName("تفاصيل الجهة المكلف منها ")]
        public int? Side_Id { get; set; }


        [ForeignKey("Side_Id")]
        public virtual Comming_From_Tbl military_To_CommingFrom_rel { get; set; }




    }
}