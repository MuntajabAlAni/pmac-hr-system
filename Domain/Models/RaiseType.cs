using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Raise_Type_Tbl
    {

        [DisplayName("Raise_Type_Id")]
        [Key]
        public int Raise_Type_Id { get; set; }

        [DisplayName("Raise_Type")]
        public string Raise_Type { get; set; }

        public virtual ICollection<Raise> Raise_Type_To_Raise_rel { get; set; }




    }
}