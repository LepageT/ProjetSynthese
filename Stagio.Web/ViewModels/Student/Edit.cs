using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Student
{
    public class Edit
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Matricule")]
        public int Matricule { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Téléphone")]
        [Required(ErrorMessage = "Requis")]
        public int Telephone { get; set; }

        [DisplayName("Mot de passe")]
        [Required(ErrorMessage = "Requis")]
        public string Password { get; set; }

    }
}