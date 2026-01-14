using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Work_Career_Type_Tbl
    {


        [DisplayName("Work_Career_Type_Id")]
        [Key]
        public int Work_Career_Type_Id { get; set; }

        [DisplayName("نوع العمل ")]
        public string Work_Career_Type { get; set; }


        public virtual ICollection<Career_Tbl> Work_Career_Type_To_Career_rel { get; set; }



    }
}