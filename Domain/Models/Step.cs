using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Step
    {

        [DisplayName("Step_Id")]
        [Key]
        public int Step_Id { get; set; }


        [DisplayName("Step")]
        public string Description { get; set; }



        public virtual ICollection<Raise> Step_To_Raise_rel { get; set; }
        public virtual ICollection<Career> Step_To_Career_rel { get; set; }


    }
}
