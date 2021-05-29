using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRenderApp.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public short SignupFee { get; set; }
        public int DurationInMonth { get; set; }
        public int Discount { get; set; }
    }
}