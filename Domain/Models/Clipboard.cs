using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Clipboard
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("order_no")]
        public required string OrderNumber { get; set; }

        [DisplayName("order_count_no")]
        public required string OrderCountNumber { get; set; }

        [DisplayName("order_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [DisplayName("running")]
        [DefaultValue(0)]
        public int Running { get; set; }

        [DisplayName("Paste_Requested")]
        [DefaultValue(0)]
        public int PasteRequested { get; set; }

        [DisplayName("User_Name")]
        public required string UserName { get; set; }
    }
}
