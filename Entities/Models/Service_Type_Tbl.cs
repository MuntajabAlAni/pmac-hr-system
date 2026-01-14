using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Service_Type_Tbl
    {

        [DisplayName("Service_Type_Id")]
        [Key]
        public int Service_Type_Id { get; set; }

        [DisplayName("Service_Type")]
        public string Service_Type { get; set; }

        public virtual ICollection<Add_Service_Tbl> Service_Type_To_Add_Service_rel { get; set; }

    }
}