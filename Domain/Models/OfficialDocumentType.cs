using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class OfficialDocumentType
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("نوع الوثيقة")]
        public required string Name { get; set; }

        public virtual ICollection<OfficialDocument>? OfficialDocuments { get; set; }
    }
}
