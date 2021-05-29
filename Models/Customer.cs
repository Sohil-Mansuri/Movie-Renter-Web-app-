using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieRenderApp.CustomValidation;
namespace MovieRenderApp.Models
{
    public class Customer
    {
        public int? Id { get; set; }


        [Required(ErrorMessage ="*Please Enter Your Full Name")]
        public string Name { get; set; }


        [Display(Name="Membership Type")] 
        [Required(ErrorMessage ="*Please Choose Your Plan")]   
        public int? MembershipTypeId { get; set; }


        public bool isSubscribedTonewsletter { get; set; }


        [Display(Name="Date Of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="*Birth Date is Required")]
        [AgeRestriction]
        public DateTime Birthdate { get; set; }

        [Display(Name="Country")]
        public string country { get; set; }
    }
    
    public class MembershipTypeName
    {
        public int Id { get; set; }
        public string List { get; set; }
    }
}