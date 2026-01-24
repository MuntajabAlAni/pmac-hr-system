using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Task_Status_Tbl
    {

        [DisplayName("Task_Status_Id")]
        [Key]
        public int Task_Status_Id { get; set; }


        [DisplayName("حالة الاجراء")]
        public string Task_Status { get; set; }


        public virtual ICollection<Consultants_Tasks_Tbl> Task_Status_To_Tasks_rel { get; set; }

    }
}