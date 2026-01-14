using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRN.Models
{
    public class Ranks_Tbl
    {



        [DisplayName("Job_Title_Id")]
        [Key]
        public int Job_Title_Id { get; set; }

        [DisplayName("الرتبة")]
        public string Rank { get; set; }

        public virtual ICollection<MilitaryModel> Rank_to_Career_rel { get; set; }



    }
}