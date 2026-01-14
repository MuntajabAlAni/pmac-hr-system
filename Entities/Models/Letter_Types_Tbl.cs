using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRN.Models
{
    public class Letter_Types_Tbl
    {



        [DisplayName("Letter_Type_Id")]
        [Key]
        public int Letter_Type_Id { get; set; }


        [DisplayName("نوع الخطاب")]
        public string Letter_Type { get; set; }


        public virtual ICollection<Letters_Tbl> Letter_Types_To_Letters_rel { get; set; }



    }
}