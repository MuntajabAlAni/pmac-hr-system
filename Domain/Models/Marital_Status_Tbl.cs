using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Marital_Status_Tbl
    {

        [DisplayName("Marital_Status_Id")]
        [Key]
        public int Marital_Status_Id { get; set; }


        [DisplayName("الحالة الزوجية")]
        public string Marital_Status { get; set; }


        public virtual ICollection<Employee_Tbl> Marital_St_To_Employee_rel { get; set; }



    }
}