using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class MaritalStatus
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("الحالة الزوجية")]
        public required string Name { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}