using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRenderApp.Models;

namespace MovieRenderApp.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<MembershipTypeName> MembershipType { get; set; }
    }
}