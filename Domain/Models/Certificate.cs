using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Certificate
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("الوصف")]
        public string? Description { get; set; }

        [DisplayName("عدد الاشهر")]
        [Required]
        [DefaultValue(0)]
        public int NoOfMonths { get; set; }

        public virtual ICollection<EducationCertificate> EducationCertificates { get; set; } = new List<EducationCertificate>();
    }
}
