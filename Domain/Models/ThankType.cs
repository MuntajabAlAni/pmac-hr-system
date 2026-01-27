using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class ThankType
    {



        [DisplayName("Thanks_Type_Id")]
        [Key]
        public int Thanks_Type_Id { get; set; }

        [DisplayName("نوع كتاب الشكر")]
        public string Thanks_Type { get; set; }


        [DisplayName("عدد الايام")]
        [Required]
        [DefaultValue(0)]
        public int? No_Of_Days { get; set; }


        [DisplayName("يؤثر على العلاوة؟")]
        [DefaultValue(false)]
        public Boolean? Raise_Affected { get; set; }







        public virtual ICollection<Thank> Thanks_Type_To_Thanks_rel { get; set; }

    }
}