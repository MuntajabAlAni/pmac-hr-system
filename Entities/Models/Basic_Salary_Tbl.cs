using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRN.Models
{
    public class Basic_Salary_Tbl
    {

        [DisplayName("Salary_Id")]
        [Key]
        public int Salary_Id { get; set; }


        [DisplayName("Salary")]
        public String Salary { get; set; }



        //public virtual ICollection<Raise_Tbl> Salary_To_Raise_rel { get; set; }


    }
}