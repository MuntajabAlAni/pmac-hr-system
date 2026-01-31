using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class JobTitle
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("العنوان الوظيفي")]
        public required string Title { get; set; }

        public virtual ICollection<Career>? Careers { get; set; }

        public virtual ICollection<Raise>? Raises { get; set; }
    }
}
