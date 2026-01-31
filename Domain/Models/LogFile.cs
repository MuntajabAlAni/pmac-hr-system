using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class LogFile
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("مستخدم النظام")]
        public string? UserName { get; set; }

        [DisplayName("وقت الحركة")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryTime { get; set; }

        [DisplayName("نوع الحركة")]
        public string? EntryType { get; set; }

        [DisplayName("نوع البيانات")]
        public string? EntryTable { get; set; }

        [DisplayName("رقم القيد المعدل")]
        public Guid RecordId { get; set; }

        [DisplayName("وصف الحركة")]
        public string? NotificationString { get; set; }

        [DisplayName("الموظف المعدلة بياناته")]
        public string? EmployeeName { get; set; }

        [DisplayName("رابط الحركة")]
        public string? Link { get; set; }

        [DisplayName("Military")]
        [DefaultValue(0)]
        public int Military { get; set; }
    }
}