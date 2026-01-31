using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Position
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("المنصب")]
        public required string Title { get; set; }

        public virtual ICollection<Career>? Careers { get; set; }
    }
}