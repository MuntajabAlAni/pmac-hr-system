using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Logins
    {
        [DisplayName("Login_Id")]
        [Key]
        public int LoginId { get; set; }

        [DisplayName("user id")]
        public string UserId { get; set; }

        [DisplayName("Session id")]
        public string SessionId { get; set; }

        [DisplayName("LoggedIn?")]
        public Boolean LoggedIn { get; set; }


        [DisplayName("Login Time")]   
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LogInTime { get; set; }


        [DisplayName("Computer Name")]
        public string ComputerName { get; set; }


        [DisplayName("LOGON_USER")]
        public string LOGON_USER { get; set; }

        [DisplayName("HTTP_USER_AGENT")]
        public string HTTP_USER_AGENT { get; set; }

        [DisplayName("AUTH_USER")]
        public string AUTH_USER { get; set; }



        [DisplayName("IP Address")]
        public string IPAddress { get; set; }





    }
}