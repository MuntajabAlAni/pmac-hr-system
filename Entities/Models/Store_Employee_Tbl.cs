using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRN.Models
{
    public class Store_Employee_Tbl
    {

        [DisplayName("الرقم")]
        [Key]
        public int Emp_Id { get; set; }



        [DisplayName("رقم الموظف في نظام الافراد")]
        public int HR_Emp_Id { get; set; }


        [DisplayName("اسم الموظف الكامل")]
        public string Fname { get; set; }


        [DisplayName("الدائرة")]
        public string Dir { get; set; }


        [DisplayName("القسم")]
        public string Dep { get; set; }



        [DisplayName("تأريخ التعيين ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateT { get; set; }



        [DisplayName("تأريخ المباشرة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateM { get; set; }



        [DisplayName("الملاك")]
        public string Malak { get; set; }


        public int? continuation { get; set; }


    }
}