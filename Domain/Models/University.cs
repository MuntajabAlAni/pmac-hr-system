using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class University
    {

        [DisplayName("رقم الجامعة")]
        [Key]
        public int University_Id { get; set; }

        [DisplayName("اسم الجامعة")]
        public string University_Name { get; set; }

    }
}