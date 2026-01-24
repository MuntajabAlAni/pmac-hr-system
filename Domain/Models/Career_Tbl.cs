using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Career_Tbl
    {
        [DisplayName("Career_Emp_Id")]
        [Key]
        public int Career_Emp_Id { get; set; }


        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }


        [DisplayName("اسم الموظف")]
        public String Emp_Name { get; set; }

        //------------------------------------------------Caree info

        [DisplayName("رقم الموظف الوطني")]
        public string Employee_National_Num { get; set; }



        [DisplayName("اسم الدائرة")]
        public int? Directorate_Id { get; set; }

        [DisplayName("اسم القسم")]
        public int? Department_Id { get; set; }

        [DisplayName("اسم الشعبة")]
        public Nullable<int> Section_Id { get; set; }


        [DisplayName("استمرارية الخدمة")]
        public int? Continuation { get; set; }

        //--------------------------rRelation----------------------------------------
        [ForeignKey("Continuation")]
        public virtual Serv_Continuation_Tbl Career_To_Serv_Con_rel { get; set; }
        //---------------------------------------------------------------------------




        [DisplayName("التحصيل الدراسي")]
        public string Education { get; set; }


        [DisplayName("العنوان الوظيفي")]
        public int? Job_Title_Id { get; set; }

        //--------------------------------


        [DisplayName("الدرجة الوظيفية")]
        public int? Grade { get; set; }


        [ForeignKey("Grade")]
        public virtual Grade_Tbl Career_To_Grade_rel { get; set; }

        [DisplayName("المرحلة")]
        public int? Step { get; set; }

        [ForeignKey("Step")]
        public virtual Step_Tbl Career_To_Step_rel { get; set; }
        //--------------------------------

        [DisplayName("الحالة الوظيفية")]
        public string Employment_Status { get; set; }

        [DisplayName("المنصب")]
        public int? Position_Id { get; set; }

        [DisplayName("تأريخ اخر ترفيع")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? Last_Promotion_Date { get; set; }


        [DisplayName("تأريخ أخر علاوة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? Last_Raise_Date { get; set; }



        [DisplayName("تأريخ الاستحقاق القادم")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? Next_Raise_Date { get; set; }



        [DisplayName("Dead_Line_Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? Dead_Line_Date { get; set; }





        [DisplayName("No_Deserver_Months")]
        [DefaultValue(0)]
        public int No_Deserver_Months { get; set; }


        [DisplayName("No_Deserved_Thanks")]
        [DefaultValue(0)]
        public int No_Deserved_Thanks { get; set; }




        [DisplayName("الراتب الاسمي")]
        public string Basic_Salary { get; set; }



        [DisplayName("دائرة المستشارين")]
        public string Consultant_agency { get; set; }


        [DisplayName("نوع العمل")]
        public int? Work_Career_Type_Id { get; set; }

        //---------------------------------

        [ForeignKey("Work_Career_Type_Id")]
        public virtual Work_Career_Type_Tbl Career_To_Work_Career_Type_rel { get; set; }

        //---------------------------------

        [DisplayName("المهام")]
        [DataType(DataType.MultilineText)]

        public string Work_Type { get; set; }


        [DisplayName("ملاحظات خلاصة الخدمة")]
        [DataType(DataType.MultilineText)]
        public string Career_Notes { get; set; }


        [DisplayName("الملاحظات")]
        [DataType(DataType.MultilineText)]
        public string Service_Summary_Notes { get; set; }





        //------------------------------------------------Assignment info

        [DisplayName("رقم كتاب التعيين")]
        public string Assign_Book_No { get; set; }

        [DisplayName("تاريخ كتاب التعيين")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Assign_Book_Date { get; set; }

        [DisplayName("رقم كتاب المباشرة")]
        public string Initiation_Book_No { get; set; }

        [DisplayName("تأريخ كتاب المباشرة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Initiation_Book_Date { get; set; }

        [DisplayName("تأريخ المباشرة الفعلي")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Initiation_Actual_Date { get; set; }

        [DisplayName("رقم كتاب المباشرة في المكتب")]
        public string Initiation_AtOffice_Book_No { get; set; }

        [DisplayName("تأريخ كتاب المباشرة في المكتب")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Initiation_AtOffice_Book_Date { get; set; }


        [DisplayName("هل لديك خدمة مضافة")]
        public string Additional_Service { get; set; }


        [DisplayName("من ذوي الشهداء")]
        public string Martyre_Related { get; set; }


        [DisplayName("سجين سياسي")]
        public string Political_Prisoner { get; set; }

        [DisplayName("فصل سياسي")]
        public string Political_Isolation { get; set; }


        [DisplayName("تأريخ انتهاء الخدمة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? End_Of_Service_Date { get; set; }



        [DisplayName("هل الموظف تارك للعمل سابقا")]
        public string Has_Left_Erlier { get; set; }


        [DisplayName("هل الموظف منقول")]
        public string Transferred { get; set; }


        [DisplayName("رقم كتاب الحذف")]
        public string Deletion_Book_No { get; set; }

        [DisplayName("رقم كتاب الاستحداث")]
        public string Update_Book_No { get; set; }

        [DisplayName("الدائرة السابقة")]
        public string Previous_Directorate { get; set; }

        [DisplayName("رصيد الاعتيادية المدور")]
        public string Normal_Vac_Credit { get; set; }

        [DisplayName("رصيد المرضية المدور")]
        public string Illness_Vac_Credit { get; set; }

        //-------------


        [DisplayName("الرصيد النهائي للاعتيادية")]
        [DefaultValue("0")]
        public string Ordinary_Final_Total { get; set; }


        [DisplayName("الرصيد النهائي للمرضية")]
        [DefaultValue("0")]
        public string Illness_Final_Total { get; set; }


        [DisplayName("no_sal_vac")]
        [DefaultValue("0")]
        public string no_sal_vac { get; set; }


        [DisplayName("Other_vacs")]
        [DefaultValue("0")]
        public string Other_vacs { get; set; }


        [DisplayName("illness_vacs_consumed")]
        [DefaultValue("0")]
        public string illness_vacs_consumed { get; set; }




        [DisplayName("ordinary_vacs_consumed")]
        [DefaultValue("0")]
        public string ordinary_vacs_consumed { get; set; }



        //-----------------

        [DisplayName("هل تم تدقيق البيانات؟")]
        public string Data_Validated { get; set; }


        //------------------------------------------------Certificate info

        //[DisplayName("الجهة المانحة")]
        //public int? Certificat_publisher_Id { get; set; }



        [DisplayName("الجهة المانحة")]
        public string Certificat_publisher_Id { get; set; }




        [DisplayName("التخصص")]
        [DefaultValue("لم يذكر")]
        public string Major { get; set; }


        [DisplayName("سنة التخرج")]
        public string Year_Of_Graduate { get; set; }


        [DisplayName("رقم صحة الصدور")]
        public string Approve_Cert_No { get; set; }




        [DisplayName("تأريخ صحة الصدور")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Approve_Cert_Date { get; set; }



        [DisplayName("رابط ملف المرفقات")]
        //[Required]
        public string File_Path { get; set; }



        [DisplayName("years")]
        [DefaultValue(0)]
        public int? years { get; set; }

        [DisplayName("months")]
        [DefaultValue(0)]
        public int? months { get; set; }

        [DisplayName("days")]
        [DefaultValue(0)]
        public int? days { get; set; }




        [DisplayName("الاستحقاق القادم (علاوة/ ترفيع)")]
        public string Next_Raise_Promotion { get; set; }


        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee_Tbl Career_To_Emp_rel { get; set; }



        //[ForeignKey("Certificat_publisher_Id")]
        //public virtual Certificat_publisher Career_To_Cert_Publisher_rel { get; set; }


        [ForeignKey("Job_Title_Id")]
        public virtual Job_Title_Tbl Career_To_Job_rel { get; set; }



        [ForeignKey("Position_Id")]
        public virtual Position_Tbl Career_To_Position_rel { get; set; }






        [ForeignKey("Directorate_Id")]
        public virtual Directorate_tbl Career_To_Dir_rel { get; set; }

        [ForeignKey("Department_Id")]
        public virtual Department_tbl Career_To_Dept_rel { get; set; }

        [ForeignKey("Section_Id")]
        public virtual Section_tbl Career_To_Sec_rel { get; set; }

        //---------------------------------------------------------------------------




        [DisplayName("الرتبة ")]
        public int Rank_Id { get; set; }


        [ForeignKey("Rank_Id")]
        public virtual Ranks_Tbl Career_To_Ranks_rel { get; set; }





        [DisplayName("الجهة المكلف منها ")]
        public int? Side_Id { get; set; }


        [ForeignKey("Side_Id")]
        public virtual Comming_From_Tbl Career_To_CommingFrom_rel { get; set; }


        [DisplayName("لديه بصمة الكترونية")]
        [DefaultValue(0)]
        public int? hasFingerprint { get; set; }

        [DisplayName("تأريخ تسجيل البصمة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FingerprintDate { get; set; }




        //------------------
        [DisplayName("مصادقة وزارة المالية")]
        public String M_Finance_Approval { get; set; }

        [DisplayName("نوع المصادقة")]
        public String Approval_Type { get; set; }

        //-----------------

        [DisplayName("حالة الاستثناء")]
        public int? Exception_Type_Id { get; set; }


        //--------------------------rRelation----------------------------------------
        [ForeignKey("Exception_Type_Id")]
        public virtual FP_Exception_Types_Tbl Career_To_Excep_rel { get; set; }
        //---------------------------------------------------------------------------
        //------------------------------------------------Personal info


        //[DisplayName("اسم الموظف الكامل")]
        ////[Required]
        //public string Employee_F_Name { get; set; }


        ////------------------------------------------------Personal info
        //[DisplayName("اسم الموظف الاول")]
        //[Required]
        //public string Employee_First_Name { get; set; }


        //[DisplayName("اسم الموظف الثاني")]
        //[Required]
        //public string Employee_Second_Name { get; set; }


        //[DisplayName("اسم الموظف الثالث")]
        //[Required]
        //public string Employee_Third_Name { get; set; }


        //[DisplayName("اسم الموظف الرابع")]
        //[Required]
        //public string Employee_Forth_Name { get; set; }


        //[DisplayName("لقب الموظف ")]
        ////[Required]
        //public string Employee_Last_Name { get; set; }

        //[DisplayName("اسم الام الثلاثي")]
        ////[Required]
        //public string Mother_Name { get; set; }

        //[DisplayName("اسم الموظف الثلاثي  باللغة الانكليزية")]
        ////[Required]
        //public string Mother_Name_English { get; set; }

        //[DisplayName("الجنس")]
        ////[Required]
        //public string Gender { get; set; }


        //[DisplayName("فصيلة الدم")]
        ////[Required]
        //public string Blood_Group { get; set; }


        //[DisplayName("القومية")]
        ////[Required]
        //public string Nationality { get; set; }


        //[DisplayName("الديانة")]
        ////[Required]
        //public string Relegion { get; set; }


        //[DisplayName("محل الولادة")]
        ////[Required]
        //public string Place_Of_Birth { get; set; }

        //[DisplayName("تأريخ الولادة")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        ////[DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        //public DateTime? Birth_Date { get; set; }


        //[DisplayName("الحالة الزوجية")]
        ////[Required]
        //public string Marital_Status { get; set; }


        //[DisplayName("عدد الاطفال")]
        ////[Required]
        //public string No_Of_Children { get; set; }


        //[DisplayName("اسم الزوج/ الزوجة")]
        ////[Required]
        //public string Hus_Wif_Name { get; set; }


        //[DisplayName("عمل الزوج/ الزوجة")]
        ////[Required]
        //public string Hus_Wif_Job { get; set; }

        //[DisplayName("رقم الهاتف")]
        //[DataType(DataType.PhoneNumber)]
        ////[Required(ErrorMessage = "رقم الهاتف مطلوب")]
        ////[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "رقم الهاتف غير صحيح")]
        ////^(\d{10})$
        //[RegularExpression(@"^(\d{11})$", ErrorMessage = "رقم الهاتف غير صحيح")]

        //public string Phone_No { get; set; }

        //[DisplayName("عنوان السكن")]
        ////[Required]
        //public string Address { get; set; }

        //[DisplayName("المحلة")]
        ////[Required]
        //public string District { get; set; }

        //[DisplayName("الزقاق")]
        ////[Required]
        //public string Alley { get; set; }

        //[DisplayName("رقم الدار")]
        ////[Required]
        //public string House_No { get; set; }

        ////-------------------------معلومات هوية الاحوال او البطاقة الوطنية



        //[DisplayName("رقم هوية الاحوال المدنية")]
        ////[Required]
        //public string Civil_Id_No { get; set; }


        //[DisplayName("رقم السجل")]
        ////[Required]
        //public string Record_No { get; set; }




        //[DisplayName("رقم الصحيفة")]
        ////[Required]
        //public string Page_No { get; set; }



        //[DisplayName("جهة الاصدار")]
        ////[Required]
        //public string Publisher { get; set; }




        //[DisplayName("تأريخ الاصدار")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? Date_Of_Issuance { get; set; }


        //[DisplayName("رقم البطاقة الوطنية")]
        ////[Required]
        //public string Nat_Card_No { get; set; }




        //[DisplayName("تأريخ الاصدار")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? Nat_Issuance_Date { get; set; }


        ////------------------------معلومات شهادة الجنسية

        //[DisplayName("رقم الشهادة")]
        ////[Required]
        //public string Id_Cert_No { get; set; }


        //[DisplayName("رقم المحفظة")]
        ////[Required]
        //public string Pocket_No { get; set; }


        //[DisplayName("جهة الاصدار")]
        ////[Required]
        //public string Cert_Publisher { get; set; }



        //[DisplayName("تأريخ الاصدار")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? Cert_Issuance_Date { get; set; }

        ////------------------------------------Housing info-----------------

        //[DisplayName("اسم مكتب المعلومات")]
        ////[Required]
        //public string Info_Office_Name { get; set; }


        //[DisplayName("رقم البطاقة")]
        ////[Required]
        //public string Housing_Card_No { get; set; }



        //[DisplayName("تأريخ التنظيم")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? HCard_Issuance_Date { get; set; }

        ////-----------------------------supplying card info



        //[DisplayName("رقم البطاقة")]
        ////[Required]
        //public string Supp_Card_No { get; set; }



        //[DisplayName("اسم مركز التموين")]
        ////[Required]
        //public string Sup_Center_Name { get; set; }



        //[DisplayName("رقم مركز التموين")]
        ////[Required]
        //public string Sup_Center_No { get; set; }




        //[DisplayName("الملاحظات")]
        ////[Required]
        //public string Sup_Notes { get; set; }


        ////--------------------------------------file path-------------------------


        //[DisplayName("رابط ملف المرفقات")]
        ////[Required]
        //public string File_Path { get; set; }

        ////--------------------------------------Prof_Pic-------------------------


        //[DisplayName("الصورة الشخصية")]
        ////[Required]
        //public string Prof_Pic { get; set; }


        //[DisplayName("البريد الالكتروني")]
        ////[Required]
        //public string Email { get; set; }


    }
}