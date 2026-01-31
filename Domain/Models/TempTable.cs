using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class TempTable
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("PID")]
        public int PID { get; set; }

        [DisplayName("Note")]
        [DataType(DataType.MultilineText)]
        public string? Note { get; set; }
    }
}