using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Gender_Tbl
    {

        [DisplayName("Gender_Id")]
        [Key]
        public int Gender_Id { get; set; }


        [DisplayName("Gender_Type")]
        public String Gender_Type { get; set; }



        public virtual ICollection<Employee_Tbl> Gender_To_Emp_rel { get; set; }


    }
}