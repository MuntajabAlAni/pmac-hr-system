using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Certifications_Tbl
    {

        [DisplayName("Certificate_Id")]
        [Key]
        public int Certificate_Id { get; set; }



        [DisplayName("Certificate_Id")]
        public String Certificate { get; set; }



        [DisplayName("عدد الاشهر")]
        [Required]
        [DefaultValue(0)]
        public int No_Of_Months { get; set; }




        public virtual ICollection<Education_Cert_Tbl> Cert_Type_To_Edu_rel { get; set; }


    }
}