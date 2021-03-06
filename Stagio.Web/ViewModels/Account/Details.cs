﻿using System.ComponentModel;

namespace Stagio.Web.ViewModels.Account
{
    public class Details
    {
        public int Id { get; set; }
        [DisplayName("Identifiant")]
        public string UserName { get; set; }
        [DisplayName("Prénom")]
        public string FirstName { get; set; }
          [DisplayName("Nom")]
        public string LastName { get; set; }
       
          [DisplayName("Téléphone")]
        public string Telephone { get; set; }

        [DisplayName("Poste")]
          public string Poste { get; set; }
          [DisplayName("Courriel")]
        public string Email { get; set; }
    }
}