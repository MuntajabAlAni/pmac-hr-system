using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Employee_Tbl
    {
        [DisplayName("Emp_Id")]
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Emp_Id { get; set; }




        [DisplayName("Store_Emp_Id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Store_Emp_Id { get; set; }



        //[DisplayName("PID")]

        //public int PID { get; set; }


        [DisplayName("اسم الموظف الكامل")]
        //[Required]
        public string Employee_F_Name { get; set; }


        //------------------------------------------------Personal info
        [DisplayName("اسم الموظف الاول")]
        [Required]
        public string Employee_First_Name { get; set; }


        [DisplayName("اسم الموظف الثاني")]
        //[Required]
        public string Employee_Second_Name { get; set; }


        [DisplayName("اسم الموظف الثالث")]
        //[Required]
        public string Employee_Third_Name { get; set; }


        [DisplayName("اسم الموظف الرابع")]
        //[Required]
        public string Employee_Forth_Name { get; set; }


        [DisplayName("لقب الموظف ")]
        //[Required]
        public string Employee_Last_Name { get; set; }

        [DisplayName("اسم الام الثلاثي")]
        //[Required]
        public string Mother_Name { get; set; }

        [DisplayName("اسم الموظف الثلاثي  باللغة الانكليزية")]
        //[Required]
        public string Mother_Name_English { get; set; }

        [DisplayName("الجنس")]
        //[Required]
        public int? Gender_Id { get; set; }



        //--------------------------rRelation----------------------------------------
        [ForeignKey("Gender_Id")]
        public virtual Gender_Tbl Emp_To_Gender_rel { get; set; }
        //---------------------------------------------------------------------------




        [DisplayName("فصيلة الدم")]
        //[Required]
        public string Blood_Group { get; set; }


        [DisplayName("القومية")]
        //[Required]
        public string Nationality { get; set; }


        [DisplayName("الديانة")]
        //[Required]
        public string Relegion { get; set; }


        [DisplayName("محل الولادة")]
        //[Required]
        public string Place_Of_Birth { get; set; }

        [DisplayName("تأريخ الولادة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birth_Date { get; set; }

        //----------------------------------------------------------
        [DisplayName("الحالة الزوجية")]
        //[Required]
        public int? Marital_Status { get; set; }

        [ForeignKey("Marital_Status")]
        public virtual Marital_Status_Tbl Emp_To_Marital_St_rel { get; set; }


        //-----------------------------------------------------------

        [DisplayName("عدد الاطفال")]
        //[Required]
        public string No_Of_Children { get; set; }


        [DisplayName("اسم الزوج/ الزوجة")]
        //[Required]
        public string Hus_Wif_Name { get; set; }


        [DisplayName("عمل الزوج/ الزوجة")]
        //[Required]
        public string Hus_Wif_Job { get; set; }

        [DisplayName("رقم الهاتف")]
        [DataType(DataType.PhoneNumber)]
        //[Required(ErrorMessage = "رقم الهاتف مطلوب")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "رقم الهاتف غير صحيح")]
        //^(\d{10})$
        //[RegularExpression(@"^(\d{11})$", ErrorMessage = "رقم الهاتف غير صحيح")]

        public string Phone_No { get; set; }

        [DisplayName("عنوان السكن")]
        //[Required]
        public string Address { get; set; }

        [DisplayName("المحلة")]
        //[Required]
        public string District { get; set; }

        [DisplayName("الزقاق")]
        //[Required]
        public string Alley { get; set; }

        [DisplayName("رقم الدار")]
        //[Required]
        public string House_No { get; set; }

        //-------------------------معلومات هوية الاحوال او البطاقة الوطنية



        [DisplayName("رقم هوية الاحوال المدنية")]
        //[Required]
        public string Civil_Id_No { get; set; }


        [DisplayName("رقم السجل")]
        //[Required]
        public string Record_No { get; set; }




        [DisplayName("رقم الصحيفة")]
        //[Required]
        public string Page_No { get; set; }



        [DisplayName("جهة الاصدار")]
        //[Required]
        public string Publisher { get; set; }




        [DisplayName("تأريخ الاصدار")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date_Of_Issuance { get; set; }


        [DisplayName("رقم البطاقة الوطنية")]
        //[Required]
        public string Nat_Card_No { get; set; }




        [DisplayName("تأريخ الاصدار")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Nat_Issuance_Date { get; set; }


        //------------------------معلومات شهادة الجنسية

        [DisplayName("رقم الشهادة")]
        //[Required]
        public string Id_Cert_No { get; set; }


        [DisplayName("رقم المحفظة")]
        //[Required]
        public string Pocket_No { get; set; }


        [DisplayName("جهة الاصدار")]
        //[Required]
        public string Cert_Publisher { get; set; }



        [DisplayName("تأريخ الاصدار")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Cert_Issuance_Date { get; set; }

        //------------------------------------Housing info-----------------

        [DisplayName("اسم مكتب المعلومات")]
        //[Required]
        public string Info_Office_Name { get; set; }


        [DisplayName("رقم البطاقة")]
        //[Required]
        public string Housing_Card_No { get; set; }



        [DisplayName("تأريخ التنظيم")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? HCard_Issuance_Date { get; set; }

        //-----------------------------supplying card info



        [DisplayName("رقم البطاقة")]
        //[Required]
        public string Supp_Card_No { get; set; }



        [DisplayName("اسم مركز التموين")]
        //[Required]
        public string Sup_Center_Name { get; set; }



        [DisplayName("رقم مركز التموين")]
        //[Required]
        public string Sup_Center_No { get; set; }




        [DisplayName("الملاحظات")]
        //[Required]
        public string Sup_Notes { get; set; }


        //--------------------------------------file path-------------------------


        [DisplayName("رابط ملف المرفقات")]
        //[Required]
        public string File_Path { get; set; }

        //--------------------------------------Prof_Pic-------------------------


        [DisplayName("الصورة الشخصية")]
        //[Required]
        public string Prof_Pic { get; set; }


        [DisplayName("البريد الالكتروني")]
        //[Required]
        public string Email { get; set; }



        [DisplayName("IsSelected")]
        [DefaultValue(false)]
        //[Required]
        public bool IsSelected { get; set; }





        [DisplayName("IsSelected_Thanks")]
        [DefaultValue(false)]
        //[Required]
        public bool IsSelected_Thanks { get; set; }





        [DisplayName("IsSelected_Letters")]
        [DefaultValue(false)]
        //[Required]
        public bool IsSelected_Letters { get; set; }






        [DisplayName("Military")]
        [Required]
        [DefaultValue(0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Military { get; set; }





        //---------------------------relatioships
        public virtual ICollection<Career> Emp_To_Career_rel { get; set; }
        public virtual ICollection<Orders_Tbl> Emp_To_Orders_rel { get; set; }
        public virtual ICollection<Thanks_Tbl> Emp_To_Thanks_rel { get; set; }
        public virtual ICollection<Vacation_Totals_Tbl> Emp_To_Vac_Totals_rel { get; set; }
        public virtual ICollection<Vacation_Tbl> Emp_To_Vacation_rel { get; set; }
        public virtual ICollection<ConsultantTask> Emp_To_Consults_Tasks_rel { get; set; }
        public virtual ICollection<Training_Courses_Tbl> Emp_To_Training_rel { get; set; }
        public virtual ICollection<Committee> Emp_To_Comm_rel { get; set; }
        public virtual ICollection<Deligation> Emp_To_Deligation_rel { get; set; }
        public virtual ICollection<Rewards_Tbl> Emp_To_Rewards_rel { get; set; }
        public virtual ICollection<Raise_Tbl> Emp_To_Raise_rel { get; set; }
        public virtual ICollection<AddedService> Emp_To_Add_Service_rel { get; set; }
        public virtual ICollection<EducationCertificate> Emp_To_Educ_rel { get; set; }
        public virtual ICollection<Punishment_Tbl> Emp_To_Punishment_rel { get; set; }

        //public virtual ICollection<Punish_Types_Tbl> Emp_To_Punish_Type_rel { get; set; }

        public virtual ICollection<Letters_Tbl> Emp_To_Letters_rel { get; set; }







    }
}