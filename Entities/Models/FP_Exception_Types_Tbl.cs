using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRN.Models
{
    public class FP_Exception_Types_Tbl
    {


        [DisplayName("Exception_Id")]
        [Key]
        public int Exception_Id { get; set; }


        [DisplayName("Exception_Type")]
        public String Exception_Type { get; set; }






        public virtual ICollection<Career_Tbl> Excep_To_Car_rel { get; set; }
    }
}