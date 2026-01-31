using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ServiceType
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Service_Type")]
        public required string Name { get; set; }

        public virtual ICollection<AddedService>? AddedServices { get; set; }
    }
}