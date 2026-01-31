using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class RaiseType
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Raise_Type")]
        public required string Name { get; set; }

        public virtual ICollection<Raise>? Raises { get; set; }
    }
}