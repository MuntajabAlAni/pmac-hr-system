using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class PersonalCardModel
    {


        public string pic { get; set; }


        [DisplayName("اسم الموظف")]
        public String EmpName { get; set; }


        [DisplayName("تأريخ الولادة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birth_Date { get; set; }


        [DisplayName("الدرجة الوظيفية")]
        public string Grade { get; set; }


        [DisplayName("المرحلة")]
        public string Step { get; set; }


        [DisplayName("العنوان الوظيفي")]
        public string Job_Title { get; set; }


        [DisplayName("اسم الدائرة")]
        public string Directorate { get; set; }

        [DisplayName("اسم القسم")]
        public string Department { get; set; }


        [DisplayName("رقم الموظف الوطني")]
        public string Employee_National_Num { get; set; }


        [DisplayName("الحالة الوظيفية")]
        public string Employment_Status { get; set; }

        [DisplayName("المنصب")]
        public string Position_Id { get; set; }


        [DisplayName("تاريخ كتاب التعيين")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Assign_Book_Date { get; set; }


        [DisplayName("تأريخ المباشرة في الوظيفة العامة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Initiation_Actual_Date { get; set; }


        [DisplayName("تأريخ  المباشرة في المكتب")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Initiation_AtOffice_Book_Date { get; set; }




        [DisplayName("تأريخ  المباشرة في المكتب")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? End_of_Service_Date { get; set; }



        [DisplayName("التحصيل الدراسي")]
        public string Education { get; set; }


        [DisplayName("الجهة المانحة")]
        public string Certificat_publisher_Id { get; set; }



        [DisplayName("التخصص")]
        [DefaultValue("لم يذكر")]
        public string Major { get; set; }



        [DisplayName("سنة التخرج")]
        public string Year_Of_Graduate { get; set; }



        [DisplayName("نوع العمل")]
        public string Work_Career_Type_Id { get; set; }



        //مدة الخدمة يوم-شهر-سنة
        [DisplayName("سنوات")]
        public int? years { get; set; }


        [DisplayName("أشهر")]
        public int? months { get; set; }


        [DisplayName("أيام")]
        public int? days { get; set; }



        [DisplayName("عدد كتب الشكر من السيد رئيس مجلس الوزراء")]
        public int? thanks_PM { get; set; }


        [DisplayName("عدد كتب الشكر من السيد مدير المكتب")]
        public int? thanks_OM { get; set; }


   


    }
}