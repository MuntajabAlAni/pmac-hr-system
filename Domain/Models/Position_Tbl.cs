using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Position_Tbl
    {


        [DisplayName("Position_Id")]
        [Key]
        public int? Position_Id { get; set; }


        [DisplayName("المنصب")]
        public string Position_Title { get; set; }



        public virtual ICollection<Career_Tbl> Position_To_Career_rel { get; set; }



    }
}