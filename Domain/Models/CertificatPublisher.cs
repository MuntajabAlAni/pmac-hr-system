using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class CertificatPublisher
    {

        [DisplayName("تسلسل الجهة المانحة")]
        [Key]
        public int Certificat_publisher_Id { get; set; }


        [DisplayName("الجهة المانحة للشهادة")]
        public string Certificat_publisher_Name { get; set; }


        //public virtual ICollection<Career_Tbl> Cert_Pub_To_Career_rel { get; set; }


    }
}
