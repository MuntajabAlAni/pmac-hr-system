using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Step_Tbl
    {

        [DisplayName("Step_Id")]
        [Key]
        public int Step_Id { get; set; }


        [DisplayName("Step")]
        public String Step { get; set; }



        public virtual ICollection<Raise_Tbl> Step_To_Raise_rel { get; set; }
        public virtual ICollection<Career_Tbl> Step_To_Career_rel { get; set; }


    }
}