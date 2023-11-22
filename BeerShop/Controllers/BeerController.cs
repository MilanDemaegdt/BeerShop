using BeerShop.Services;
using BeerShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeerShop.Controllers
{
    public class BeerController : Controller
    {
        private readonly BeerServices _beerService;

        public BeerController()
        {// Later with DI
            _beerService = new BeerServices();
        }
        public async Task<IActionResult> Index()
        {
            var lstBeer = await _beerService.GetAll();  // Domain objects
            List<BeerVM> beerVMs = new List<BeerVM>();

            if (lstBeer != null)
            {
                foreach (var beer in lstBeer)
                {
                    var beerVM = new BeerVM();
                    // later we use an automapper
                    beerVM.Naam = beer.Naam;
                    beerVM.BrouwerNaam = beer.BrouwernrNavigation.Naam;
                    beerVM.SoortNaam = beer.SoortnrNavigation.Soortnaam;
                    beerVM.Alcohol = beer.Alcohol;
                    beerVM.Image = beer.Image;
                    beerVMs.Add(beerVM);
                }
            }

            return View(beerVMs);  // Always VM 
        }
    }
}

