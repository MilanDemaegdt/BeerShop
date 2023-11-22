using AutoMapper;
using BeerShop.Services;
using BeerShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeerShop.Controllers
{
    public class BeerSortingController : Controller
    {
        private readonly BeerServices _beerService;

        private readonly BreweryService breweryService;

        private readonly IMapper _mapper;
        public BeerSortingController(IMapper mapper)
        {// Later with DI
            _mapper = mapper;
            _beerService = new BeerServices();
            breweryService = new BreweryService();
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult GetBeerByAlcohol()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GetBeerByAlcohol(decimal? txtAlcohol)
        {
            var lstBeer = await _beerService.GetAllBeerWithAlcoholPer(txtAlcohol);  // Domain objects
            List<BeerVM> beerVMs = new List<BeerVM>();

            if (lstBeer != null)
            {
                beerVMs = _mapper.Map<List<BeerVM>>(lstBeer);
            }

            return View(beerVMs);  // Always VM  
        }




        public async Task<IActionResult> GetBeerByBrewer()
        {     
            ViewBag.lstBrouwer =
                new SelectList(await breweryService.GetAll(),
                "Brouwernr", "Naam");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GetBeerByBrewer(int brouwerId)
        {
            if(brouwerId == null)
            {
                return NotFound();
            }

            var lstBeer = await _beerService.GetAllBeerWithBrewer(brouwerId);  // Domain objects

            ViewBag.lstBrouwer =
                new SelectList(await breweryService.GetAll(),
                "Brouwernr", "Naam");

            List<BeerVM> beerVMs = _mapper.Map<List<BeerVM>>(lstBeer);

    

            return View(beerVMs);  // Always VM  
        }




        public async Task<IActionResult> GetBeerByBrewerVM()
        {
           BreweryBeersVM breweryBeersVM = new BreweryBeersVM();
           
           breweryBeersVM.Breweries = new SelectList(await breweryService.GetAll(), "Brouwernr", "Naam");

           return View(breweryBeersVM);    
        }


 

        [HttpPost]
        public async Task<IActionResult> GetBeerByBrewerVM(BreweryBeersVM entity)
        {

            if(entity.BreweryNumber == null)
            {
                return NotFound();
            }

            

            var bierList = await _beerService.GetAllBeerWithBrewer(Convert.ToInt16(entity.BreweryNumber));

            BreweryBeersVM breweryBeersVM = new BreweryBeersVM();

            breweryBeersVM.Beers = _mapper.Map<List<BeerVM>>(bierList);

            breweryBeersVM.Breweries = new SelectList(await breweryService.GetAll(), "Brouwernr", "Naam", entity.BreweryNumber);

            return View(breweryBeersVM);
        }


        public async Task<IActionResult> GetBeerByBrewerAjax()
        {
            BreweryBeersVM breweryBeersVM = new BreweryBeersVM();

            breweryBeersVM.Breweries = new SelectList(await breweryService.GetAll(), "Brouwernr", "Naam");

            return View(breweryBeersVM);
        }

        [HttpPost]
        public async Task<IActionResult> GetBeerByBrewerAjax(BreweryBeersVM entity)
        {
            if (entity.BreweryNumber == null)
            {
                return NotFound();
            }

            var bierList = await _beerService.GetAllBeerWithBrewer
                (Convert.ToInt16(entity.BreweryNumber));
            List<BeerVM> listVM = _mapper.Map<List<BeerVM>>(bierList);

            Thread.Sleep(2000);// mag je natuurlijk weglaten, hier wordt 2 sec. gewacht
            return PartialView("_SearchBierenPartial", listVM); // Hier staat niet return View maar return PartialView,
                                                                // hier wordt enkel een stukje van de pagina aangemaakt.

        }






    }
}
