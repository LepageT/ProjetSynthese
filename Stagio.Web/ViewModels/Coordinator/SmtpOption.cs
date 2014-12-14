using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class SmtpOption
    {
        [DisplayName("Serveur SMTP")]
        public string SmtpServer { get; set; }
        [DisplayName("Port SMTP")]
        public int SmtpPort { get; set; }
        [DisplayName("Nom d'utilisateur")]
        public string SmtpUsername { get; set; }
        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        public string SmtpPassword { get; set; }

        [DisplayName("Compte Mail pour test")]
        public string TestEmail { get; set; }
    }
}