using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class VacationTotal
    {


        [DisplayName("Vac_Total_Id")]
        [Key]
        public int Vac_Total_Id { get; set; }

        [DisplayName("الرصيد المدور من الاجازات الاعتيادية")]
        [DefaultValue("0")]
        public string Ordinary_Vac_Total { get; set; }


        [DisplayName("الرصيد المدور من الاجازات المرضية")]
        [DefaultValue("0")]
        public string Illness_Vac_Total { get; set; }




        [DisplayName("الرصيد النهائي للاعتيادية")]
        [DefaultValue("0")]
        public string Ordinary_Final_Total { get; set; }


        [DisplayName("الرصيد النهائي للمرضية")]
        [DefaultValue("0")]
        public string Illness_Final_Total { get; set; }





        [DisplayName("اسم الموظف")]
        public int Emp_Id { get; set; }


        [DisplayName("اسم الموظف")]
        public string Emp_Name { get; set; }





        //--------------------------rRelation----------------------------------------
        [ForeignKey("Emp_Id")]
        public virtual Employee Vac_Totals_To_Emp_rel { get; set; }
        //---------------------------------------------------------------------------



    }
}