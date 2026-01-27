using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class WorkNature
    {

        [DisplayName("Work_Nature_Id")]
        [Key]
        public int Work_Nature_Id { get; set; }


        [DisplayName("طبيعة العمل")]
        public string Work_Nature { get; set; }


        public virtual ICollection<ConsultantTask> Work_NatureTo_Tasks_rel { get; set; }
    }
}