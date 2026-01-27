using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Department
    {

        [DisplayName("Deptartment_ID")]
        [Key]
        public int Deptartment_Id { get; set; }





        [DisplayName("Directorate_Id")]
        public int Directorate_Id { get; set; }





        [DisplayName("Deptartment_Name")]
        //[Required]
        public string Deptartment_Name { get; set; }



        [DisplayName("Exception")]
        [DefaultValue(0)]
        public int Exception { get; set; }




        [DisplayName("hidden")]
        [DefaultValue(0)]
        public int hidden { get; set; }





        //public virtual ICollection<Emp_tbl> Deptartment_Emp_rel { get; set; }

        //public virtual ICollection<Items_Cats_tbl> Deptartment_Items_rel { get; set; }

        public virtual ICollection<Section> Deptartment_To_Section_rel { get; set; }

        public virtual ICollection<Career> Department_To_Career_rel { get; set; }

        //--------------------------rRelation----------------------------------------
        [ForeignKey("Directorate_Id")]
        public virtual Directorate Department_Directorate_rel { get; set; }
        //---------------------------------------------------------------------------


    }
}
