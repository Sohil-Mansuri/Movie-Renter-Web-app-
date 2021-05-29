using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MovieRenderApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="*Please Enter Movie Name")]
        public string Name { get; set; }


        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Required")]
        public DateTime ReleaseData { get; set; }


        [DataType(DataType.Date)]
        public DateTime DataAdded { get; set; }

        [Required(ErrorMessage ="*Please Enter No of Stoks Available")]
        [Range(1,20,ErrorMessage ="Maximum 20 Stocks You can put")]
        public int Stocks { get; set; }

        [Required(ErrorMessage ="Plese Select Category Of Movie")]       
        public string Category { get; set; }
    }
}