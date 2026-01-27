using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class VacationType
    {


        [DisplayName("Vacation_Type_Id")]
        [Key]
        public int Vacation_Type_Id { get; set; }

        [DisplayName("نوع الاجازة ")]
        public string Vacation_Type { get; set; }



        [DisplayName("Is_Condition")]
        [DefaultValue(false)]
        public Boolean? Is_Condition { get; set; }


        [DisplayName("خدمة فعلية مع تفعيل عداد الرصيد؟")]
        [DefaultValue(false)]
        public Boolean? Rsed { get; set; }

        [DisplayName("يؤثر على العلاوة؟")]
        [DefaultValue(false)]
        public Boolean? Raise_Affected { get; set; }



        public virtual ICollection<Vacation> Vac_Type_To_Vacs_rel { get; set; }


    }
}