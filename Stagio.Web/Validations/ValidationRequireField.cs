using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stagio.Web.Validations
{
    public class ValidationRequireField : ValidationAttribute
    {
        private String PropertyName { get; set; }

        public ValidationRequireField(String field)
        {
            this.PropertyName = field;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            Object proprtyvalue = type.GetProperty((string)PropertyName).GetValue(instance, null);
            if (proprtyvalue == null)
            {
                return new ValidationResult((string)value);
            }

            return null;
        }
        
    }
}