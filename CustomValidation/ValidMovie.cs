using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using MovieRenderApp.DomainModels;

namespace MovieRenderApp.CustomValidation
{
    public class ValidMovie:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Movie = value.ToString();
            if (string.IsNullOrEmpty(Movie))
            {
                return new ValidationResult("Please Enter The Name of Movie");
            }

            var dbaccess = new Dblogics();

            DataTable dt = dbaccess.GetMovies();
            var result = dbaccess.MovieFilter(dt).DefaultIfEmpty().Where(x => x.Name == Movie).ToList();

            if (result.Count == 0)
                return new ValidationResult("*This Movie is Not Available");
            else
                return ValidationResult.Success;
        }
    }
}