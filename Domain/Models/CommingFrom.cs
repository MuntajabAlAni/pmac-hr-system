using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Comming_From_Tbl
    {


      


            [DisplayName("Side_Id")]
            [Key]
            public int Side_Id { get; set; }

            [DisplayName("اسم الجهة المكلف منها")]
            public string Side_Name { get; set; }

            public virtual ICollection<Career> Rank_to_Career_rel { get; set; }



        
    }




}
