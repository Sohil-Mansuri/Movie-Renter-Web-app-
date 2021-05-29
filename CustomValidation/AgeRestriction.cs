using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieRenderApp.CustomValidation
{
    public class AgeRestriction : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value!=null)
            {
                DateTime Birthdate = (DateTime)value;

                var age = DateTime.Now.Year - Birthdate.Year;
                if (age >= 18)
                    return ValidationResult.Success;
                else
                    return new ValidationResult(" ! Age Must be 18 yers old");


            }
            return new ValidationResult("*Age is Required");

        }
    }
}