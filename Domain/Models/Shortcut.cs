using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Shortcut
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("تركيبة المفاتيح")]
        [Required]
        [StringLength(50)]
        public required string KeyCombination { get; set; } // e.g. Alt+1, Ctrl+S

        [DisplayName("نوع الحدث")]
        [Required]
        [StringLength(50)]
        public required string ActionType { get; set; } // "Navigate" or "Click"

        [DisplayName("الرابط او الامر")]
        [Required]
        [StringLength(255)]
        public required string ActionValue { get; set; } // url or element id

        [DisplayName("الوصف")]
        [StringLength(250)]
        public string? Description { get; set; }

        public int Hidden { get; set; }
    }
}