using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class ProcedureDescription
    {


        [DisplayName("Pocedure_Desc_Id")]
        [Key]
        public int Pocedure_Desc_Id { get; set; }


        [DisplayName("توصيف الاجراء")]
        public string Procedure_Description { get; set; }


        public virtual ICollection<ConsultantTask> Pocedure_Description_To_Tasks_rel { get; set; }


    }
}