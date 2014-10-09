using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stagio.DataLayer;

namespace Stagio.Web.ViewModels.Enterprise
{
    public class Create
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Requis")]
        [DataType(DataType.EmailAddress)]
        [ValidationVerifyIfEmailIsUnique]
        public string Email { get; set; }

        [DisplayName("Nom")]
        [Required(ErrorMessage = "Requis")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        [Required(ErrorMessage = "Requis")]
        public string FirstName { get; set; }

        [DisplayName("Nom de l'entreprise")]
        [Required(ErrorMessage = "Requis")]
        public string EnterpriseName { get; set; }

        [DisplayName("Téléphone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entrez un numéro valide.")]
        [Required(ErrorMessage = "Requis")]
        public string Telephone { get; set; }

        [DisplayName("Poste")]
        public int? Poste { get; set; }

        [DisplayName("Mot de passe")]
        [Required(ErrorMessage = "Requis")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [ValidationNewPassword]
        public string Password { get; set; }

        [DisplayName("Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Password", ErrorMessage = "Les mot de passes ne correspondent pas")]
        public string PasswordConfirmation { get; set; }
    }

    public class ValidationNewPassword : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = (string)value;

            if (password != null)
            {
                int nbNumbers = password.Count(Char.IsDigit);
                int nbLetters = password.Count(Char.IsLetter);

                if (nbNumbers < 2 || nbLetters < 2)
                {
                    return new ValidationResult("Le mot de passe doit contenir deux chiffres et deux lettres.");
                }
                return null;
            }
            else
            {
                return new ValidationResult("Le mot de passe est obligatoire.");
            }
        }
    }

    public class ValidationVerifyIfEmailIsUnique : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var db = new StagioDbContext();
            if (value != null)
            {
                var emailAsString = value.ToString();
                IEnumerable<string> email = db.Enterprises.Where(x => x.Email != null).Select(x => x.Email);
                if (email.Contains(emailAsString))
                {
                    return new ValidationResult("Ce email est déjà utilisé pour un compte entreprise.");
                }
                return null;
            }
            else
            {
                return new ValidationResult("Le email est obligatoire.");
            }
        }
    }
}
