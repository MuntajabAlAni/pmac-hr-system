using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class FingerPrintExceptionType
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Exception_Type")]
        public required string Name { get; set; }

        public virtual ICollection<Career>? Careers { get; set; }
    }
}
