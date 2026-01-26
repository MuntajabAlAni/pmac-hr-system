using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Grade_Tbl
    {

        [DisplayName("Grade_Id")]
        [Key]
        public int Grade_Id { get; set; }


        [DisplayName("Grade")]
        public string Grade { get; set; }



        public virtual ICollection<Raise_Tbl> Grade_To_Raise_rel { get; set; }

        public virtual ICollection<Career> Grade_To_Career_rel { get; set; }


    }
}
