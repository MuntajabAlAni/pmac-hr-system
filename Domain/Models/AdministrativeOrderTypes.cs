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
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("نوع الامر")]
        public required string OrderType { get; set; }

        public virtual required ICollection<Order> Orders { get; set; }
    }
}
