using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRN.Models
{
    public class Task_Description_Tbl
    {

        [DisplayName("Task_Des_Id")]
        [Key]
        public int Task_Des_Id { get; set; }


        [DisplayName("وصف المهمة")]
        public string Task_Description { get; set; }


        public virtual ICollection<Consultants_Tasks_Tbl> Task_Description_To_Tasks_rel { get; set; }


    }
}