using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BeerShop.Areas.Admin.ViewModels
{
    public class CreateBeerVM
    {
        public string? Naam { get; set; }

        [Display(Name = "Brouwer")]
        public string? Brouwernr { get; set; }  

        public IEnumerable<SelectListItem>? Brouwer { get; set; }

        [Display(Name = "Soort")]
        public string? Soortnr { get; set; }

        public IEnumerable<SelectListItem>? Soort { get; set; }   

        public decimal? Alcohol { get; set; }   
    }
}
