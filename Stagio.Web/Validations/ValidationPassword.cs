using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Stagio.Web.Validations
{
    public class ValidationPassword : ValidationAttribute
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
                
            }
            return null;
        }
    }
}