using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

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
            var proprtyvalue = type.GetProperty((string)PropertyName).GetValue(instance, null);
            if (proprtyvalue != null && proprtyvalue.ToString() == "")
            {
                return new ValidationResult((string)value);
            }

            return null;
        }
        
    }
}