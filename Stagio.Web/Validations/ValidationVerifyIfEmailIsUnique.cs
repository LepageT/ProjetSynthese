using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.DataLayer.EntityFramework;
using Stagio.Domain.Entities;

namespace Stagio.Web.Validations
{
    public class ValidationVerifyIfEmailIsUnique : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IEntityRepository<ContactEnterprise> _contactEnterpriseRepository = new EfEntityRepository<ContactEnterprise>();
            if (value != null)
            {
                var emailAsString = value.ToString();
                IEnumerable<string> email = _contactEnterpriseRepository.GetAll().Where(x => x.Email != null).Select(x => x.Email);
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