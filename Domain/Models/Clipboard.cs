using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Clipboard
    {




        [DisplayName("Copy_Id")]
        [Key]
        public int Copy_Id { get; set; }



        [DisplayName("order_no")]
        public string order_no { get; set; }



        [DisplayName("order_count_no")]
        public string order_count_no { get; set; }



        [DisplayName("order_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? order_date { get; set; }


        [DisplayName("running")]
        [DefaultValue(0)]
        public int running { get; set; }

        [DisplayName("Paste_Requested")]
        [DefaultValue(0)]
        public int Paste_Requested { get; set; }




        [DisplayName("User_Name")]
        public string User_Name { get; set; }




    }
}
