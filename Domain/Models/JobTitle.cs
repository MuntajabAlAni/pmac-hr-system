using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class JobTitle
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




        public virtual ICollection<Career> Job_To_Career_rel { get; set; }

        public virtual ICollection<Raise> Job_To_Raise_rel { get; set; }


    }
}
