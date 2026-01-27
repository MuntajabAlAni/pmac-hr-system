using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class LetterType
    {



        [DisplayName("Letter_Type_Id")]
        [Key]
        public int Letter_Type_Id { get; set; }


        [DisplayName("نوع الخطاب")]
        public string Letter_Type { get; set; }


        public virtual ICollection<Letter> Letter_Types_To_Letters_rel { get; set; }



    }
}