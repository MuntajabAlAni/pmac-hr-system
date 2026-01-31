using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class StoreEmployee
    {
        [DisplayName("الرقم")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("رقم الموظف في نظام الافراد")]
        public int HREmployeeId { get; set; }

        [DisplayName("اسم الموظف الكامل")]
        public string? FullName { get; set; }

        [DisplayName("الدائرة")]
        public string? Directorate { get; set; }

        [DisplayName("القسم")]
        public string? Department { get; set; }

        [DisplayName("تأريخ التعيين ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfEmployment { get; set; }

        [DisplayName("تأريخ المباشرة ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfInitiation { get; set; }

        [DisplayName("الملاك")]
        public string? Malak { get; set; }

        public int? Continuation { get; set; }
    }
}
