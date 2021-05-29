using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieRenderApp.CustomValidation;

namespace MovieRenderApp.Models
{
    public class NewRenter
    {
        public int? Id { get; set; }

       [Required(ErrorMessage ="*Please Enter Customer Name")]
       [ValidCustomer]
        public string Customer { get; set; }

        [Required(ErrorMessage ="*please Enter Movie Name")]
        [ValidMovie]
        public string Movie { get; set; }

    }
}