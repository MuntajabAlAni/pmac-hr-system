using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class AdministrativeOrderType
    {
        [DisplayName("Order_Type_Id")]
        [Key]
        public int Order_Type_Id { get; set; }

        [DisplayName("نوع الامر")]
        public string Order_Type { get; set; }

        public virtual ICollection<Orders_Tbl> Order_Type_To_Order_rel { get; set; }
    }
}
