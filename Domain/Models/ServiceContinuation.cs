using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Serv_Continuation_Tbl
    {



        [DisplayName("Serv_Con_Id")]
        [Key]
        public int Serv_Con_Id { get; set; }

        [DisplayName("حالة استمرارية الخدمة")]
        public string Serv_Con_Type { get; set; }


        public virtual ICollection<Career> Serv_Con_To_Career_rel { get; set; }



    }
}