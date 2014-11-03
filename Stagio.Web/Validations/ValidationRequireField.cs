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
            private Object DesiredValue { get; set; }

            public ValidationRequireField(String propertyName, Object desiredvalue)
            {
                PropertyName = propertyName;
                DesiredValue = desiredvalue;
            }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            if (proprtyvalue == null)
            {
                return  new ValidationResult("");
              
            }
            if (proprtyvalue.ToString() == DesiredValue.ToString())
            {
                  ValidationResult result = base.IsValid(value, context);
                return result;
            }
            return ValidationResult.Success;
        }
        
    }
}