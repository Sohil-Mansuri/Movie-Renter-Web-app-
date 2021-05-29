using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieRenderApp.DomainModels;
using System.Data;

namespace MovieRenderApp.CustomValidation
{
    public class ValidCustomer:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var CustomerName = value.ToString();

            if (string.IsNullOrEmpty(CustomerName))
            {
                return new ValidationResult("Please Enter Customer Name");
            }


            var dbAccesss = new Dblogics();
            var dt = new DataTable();
            dt = dbAccesss.GetCustomer();
            var result = dbAccesss.CustomerFilter(dt).DefaultIfEmpty().Where(x => x.Name == CustomerName).ToList();

            if (result.Count==0)
            {
                return new ValidationResult("Not a Valid Customer");
            }
            else
                return ValidationResult.Success;

        }
            
    }
}