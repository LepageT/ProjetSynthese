using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Stagio.DataLayer;

namespace Stagio.Web.Validations
{
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