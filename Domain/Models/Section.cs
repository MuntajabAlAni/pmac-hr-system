using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Section
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Section_Name")]
        public required string Name { get; set; }

        [DisplayName("Department_Id")]
        public Guid DepartmentId { get; set; }

        public virtual ICollection<Career>? Careers { get; set; }

        //--------------------------Relationships----------------------------------------
        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }
    }
}
