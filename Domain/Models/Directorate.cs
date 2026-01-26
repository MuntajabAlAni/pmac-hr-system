using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Directorate_tbl
    {

        [DisplayName("Directorate_Id")]
        [Key]
        public int Directorate_Id { get; set; }


        [DisplayName("Directorate_Name")]
        //[Required]
        public string Directorate_Name { get; set; }



        [DisplayName("Exception")]
        [DefaultValue(0)]
        public int Exception { get; set; }


        //public virtual ICollection<Emp_tbl> Directorate_Emp_rel { get; set; }
        //public virtual ICollection<Items_Cats_tbl> Directorate_Items_rel { get; set; }
        public virtual ICollection<Department> Directorate_Department_rel { get; set; }


        public virtual ICollection<Career> Directorate_Career_rel { get; set; }


    }
}
