using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class PunishType
    {

        [DisplayName("Punish_Type_Id")]
        [Key]
        public int Punish_Type_Id { get; set; }


        [DisplayName("نوع العقوبة")]
        public string Punishment_Type { get; set; }



        [DisplayName("عدد الايام")]
        [DefaultValue(0)]
        [Required]
        public int? No_Of_Days { get; set; }


        [DisplayName("يؤثر على العلاوة؟")]

        [DefaultValue(false)]
        public Boolean? Raise_Affected { get; set; }



        public virtual ICollection<Punishment> Punish_Type_To_Punishments_rel { get; set; }

    }
}
