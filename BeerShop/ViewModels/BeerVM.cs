using BeerShopDB.Models.Entities;

namespace BeerShop.ViewModels
{
    public class BeerVM
    {

        public string? Naam { get; set; } 
        
        public string? BrouwerNaam { get; set; }

        public string? SoortNaam { get; set; }

        public decimal? Alcohol { get; set; }

        public string? Image { get; set; }
    }
}
