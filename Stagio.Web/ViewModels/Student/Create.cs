using Stagio.Web.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Student
{
    public class Create
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Matricule")]
        [Required(ErrorMessage = "Requis")]
        public int Matricule { get; set; }

        [DisplayName("Nom")]
        [Required(ErrorMessage = "Requis")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        [Required(ErrorMessage = "Requis")]
        public string FirstName { get; set; }

        [DisplayName("Téléphone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entrez un numéro valide.")]
        [Required(ErrorMessage = "Requis")]
        public string Telephone { get; set; }

        [DisplayName("Mot de passe")]
        [Required(ErrorMessage = "Requis")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [ValidationPassword]
        public string Password { get; set; }

        [DisplayName("Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Password", ErrorMessage = "Les mot de passes ne correspondent pas")]
        public string PasswordConfirmation { get; set; }

        [DisplayName("Courriel")]
        [Required(ErrorMessage = "Requis")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Confirmation Courriel")]
        [Required(ErrorMessage = "Requis")]
        [DataType(DataType.EmailAddress)]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Email", ErrorMessage = "Les emails ne correspondent pas")]
        public string ConfirmEmail { get; set; }
    }
}