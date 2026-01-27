using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class FingerPrintExceptionType
    {


        [DisplayName("Exception_Id")]
        [Key]
        public int Exception_Id { get; set; }


        [DisplayName("Exception_Type")]
        public string Exception_Type { get; set; }






        public virtual ICollection<Career> Excep_To_Car_rel { get; set; }
    }
}
