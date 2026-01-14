using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Education_Cert_Tbl
    {
        [DisplayName("Education_Id")]
        [Key]
        public int Education_Id { get; set; }

        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }

        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Educ_To_Emp_rel { get; set; }
        //---------------------------------------------------------------------------

        [DisplayName("اسم الموظف")]
        public String Emp_Name { get; set; }


        [DisplayName("التحصيل الدراسي")]
        public int Educ_Id { get; set; }


        [DisplayName("عدد أشهر الخدمة المضافة")]
        [DefaultValue(0)]
        public int No_Of_Months { get; set; }


        //--------------------------rRelation----------------------------------------
        [ForeignKey("Educ_Id")]
        public virtual Certifications_Tbl Educ_To_Cert_Type_rel { get; set; }
        //---------------------------------------------------------------------------


        [DisplayName("اسم الجامعة/ المعهد")]
        public String Institute_Name { get; set; }


        [DisplayName("اسم الكلية")]
        public String College_Name { get; set; }


        [DisplayName("اسم القسم")]
        public String Department_Name { get; set; }



        [DisplayName("التخصص")]
        public String Major { get; set; }



        //[DisplayName("سنة التخرج")]
        //public String Grad_Year { get; set; }



        [DisplayName("رقم الوثيقة")]
        public String Cert_No { get; set; }


        [DisplayName("تأريخ اصدار الوثيقة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Order_Date { get; set; }


        [DisplayName("سنة التخرج")]
        public string Year_Of_Graduate { get; set; }


        [DisplayName("رقم صحة الصدور")]
        public string Approve_Cert_No { get; set; }




        [DisplayName("تأريخ صحة الصدور")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Approve_Cert_Date { get; set; }



        [DisplayName("البلد المانح للشهادة")]
        public string Country_Of_Graduate { get; set; }


        [DisplayName("التسلسل")]
        public string Sequence { get; set; }


        [DisplayName("المعدل")]
        public string Average { get; set; }

        [DisplayName("يؤثر على العلاوة")]
        [Required]
        public string Affect_Raise { get; set; }


        [DisplayName("تأريخ احتساب الشهادة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Consideration_Date { get; set; }


        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Education_Notes { get; set; }


        [DisplayName("سارية التأثير على الاستحقاق الحالي؟")]
        [DefaultValue(1)]
        public int Running { get; set; }





        [DisplayName("رابط ملف المرفقات")]
        //[Required]
        public string File_Path { get; set; }

    }
}