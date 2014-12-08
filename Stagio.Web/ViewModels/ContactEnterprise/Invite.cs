using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.ContactEnterprise
{
    public class Invite
    {
        [DisplayName("Courriel")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [DisplayName("Prénom")]
        public String FirstName { get; set; }

        [DisplayName("Nom")]
        public String LastName { get; set; }

        [DisplayName("Nom de l'entreprise")]
        public String EnterpriseName { get; set; }

        [DisplayName("Téléphone")]
        public String Telephone { get; set; }

        [DisplayName("Poste")]
        public String Poste { get; set; }

        [DisplayName("Message")]
        public String Message { get; set; }
    }
}