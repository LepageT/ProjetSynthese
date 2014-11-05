using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.ContactEnterprise
{
    public class AcceptApply
    {
        [DisplayName("Téléphone")]
        public string Telephone { get; set; }

        [DisplayName("Poste")]
        public string Poste { get; set; }

        [DisplayName("Courriel")]
        public string Email { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }
    }
}