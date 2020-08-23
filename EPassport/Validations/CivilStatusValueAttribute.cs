using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

namespace EPassport.Validations
{
    public class CivilStatusValueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           if(value != null)
            {
                string csVal = value.ToString();
                if (csVal.Contains("Married") && (csVal.Contains("Widow")))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Enter name of your husband or wife");
        }
    }
}