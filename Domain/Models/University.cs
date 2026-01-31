using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class University
    {
        [DisplayName("رقم الجامعة")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("اسم الجامعة")]
        public required string Name { get; set; }
    }
}