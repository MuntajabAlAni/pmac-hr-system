using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Department
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Directorate_Id")]
        public Guid DirectorateId { get; set; }

        [DisplayName("Deptartment_Name")]
        public required string Name { get; set; }

        [DisplayName("Exception")]
        [DefaultValue(0)]
        public int Exception { get; set; }

        [DisplayName("hidden")]
        [DefaultValue(0)]
        public int Hidden { get; set; }

        public virtual ICollection<Section>? Sections { get; set; }

        public virtual ICollection<Career>? Careers { get; set; }

        //--------------------------Relationships----------------------------------------
        [ForeignKey("DirectorateId")]
        public virtual Directorate? Directorate { get; set; }
    }
}
