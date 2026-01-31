using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Login
    {
        [DisplayName("Id")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("user id")]
        public string? UserId { get; set; }

        [DisplayName("Session id")]
        public string? SessionId { get; set; }

        [DisplayName("LoggedIn?")]
        public bool LoggedIn { get; set; }

        [DisplayName("Login Time")]   
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LogInTime { get; set; }

        [DisplayName("Computer Name")]
        public string? ComputerName { get; set; }

        [DisplayName("LOGON_USER")]
        public string? LOGON_USER { get; set; }

        [DisplayName("HTTP_USER_AGENT")]
        public string? HTTP_USER_AGENT { get; set; }

        [DisplayName("AUTH_USER")]
        public string? AUTH_USER { get; set; }

        [DisplayName("IP Address")]
        public string? IPAddress { get; set; }
    }
}