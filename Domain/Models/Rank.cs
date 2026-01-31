using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Rank
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("الرتبة")]
        public required string Description { get; set; }

        public virtual ICollection<MilitaryModel>? MilitaryModels { get; set; }
    }
}
