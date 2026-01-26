using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Section_tbl
    {





        [DisplayName("Section_ID")]
        [Key]
        public int Section_Id { get; set; }




        [DisplayName("Section_Name")]
        //[Required]
        public string Section_Name { get; set; }



        [DisplayName("Department_Id")]
        public int Department_Id { get; set; }





        //public virtual ICollection<Emp_tbl> Section_Emp_rel { get; set; }

        //public virtual ICollection<Items_Cats_tbl> Section_Items_rel { get; set; }


        public virtual ICollection<Career> Section_To_Career_rel { get; set; }


        //--------------------------rRelation----------------------------------------
        [ForeignKey("Department_Id")]
        public virtual Department Section_Department_rel { get; set; }
        //---------------------------------------------------------------------------








    }
}
