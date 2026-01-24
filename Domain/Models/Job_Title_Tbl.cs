using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Job_Title_Tbl
    {

        [DisplayName("Job_Title_Id")]
        [Key]
        public int Job_Title_Id { get; set; }

        [DisplayName("العنوان الوظيفي")]
        public string Job_Title { get; set; }



        //[DisplayName("Military")]
        //[Required]
        //[DefaultValue(0)]
        ////[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int Military { get; set; }




        public virtual ICollection<Career_Tbl> Job_To_Career_rel { get; set; }

        public virtual ICollection<Raise_Tbl> Job_To_Raise_rel { get; set; }


    }
}