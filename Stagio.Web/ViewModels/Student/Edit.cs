using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Stagio.DataLayer;

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
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entrez un numéro valide.")]
        [Required(ErrorMessage = "Requis")]
        public string Telephone { get; set; }

        [DisplayName("Ancien mot de passe")]
        [DataType(DataType.Password)]
        [ValidationOldPassword]
        public string OldPassword { get; set; }

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
        public ValidationNewPassword()
        { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = (string) value;

            int nbNumbers = password.Count(Char.IsDigit);
            int nbLetters = password.Count(Char.IsLetter);

            if (nbNumbers < 2 || nbLetters < 2)
            {
                return new ValidationResult("Le mot de passe doit contenir deux chiffres et deux lettres."); 
            }
            return null; // everything OK
        }
    }

    public class ValidationOldPassword : ValidationAttribute
    {
        public ValidationOldPassword()
        { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string oldPassword = (string) value;

            StagioDbContext stagioDbContext = new StagioDbContext();
            IEnumerable<string> listSamePassword = stagioDbContext.Students.Where(x => x.Password == oldPassword).Select(x => x.Password);
            

            int count = 0;
            foreach (object o in listSamePassword)
            {
                count++;
            }


            if (count == 0)
            {
                return new ValidationResult("L'ancien mot de passe n'est pas valide.");
            }
            return null; // everything OK
        }
    }
}