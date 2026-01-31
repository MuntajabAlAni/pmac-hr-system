using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class CertificatePublisher
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("الجهة المانحة للشهادة")]
        public required string Name { get; set; }
    }
}
