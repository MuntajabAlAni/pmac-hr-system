using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class TempTable
    {

        [DisplayName("Temp_Id")]
        [Key]
        public int Temp_Id { get; set; }



        [DisplayName("PID")]
        public int PID { get; set; }


        [DisplayName("Note")]
        [DataType(DataType.MultilineText)]

        public string Note { get; set; }



    }
}