using BeerShop.Services;
using BeerShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace BeerShop.Controllers
{
    public class BeerControllerAutoMapper : Controller
    {
        private readonly BeerServices _beerService;

        private readonly IMapper _mapper;


        public BeerControllerAutoMapper(IMapper mapper)
        {// Later with DI
            _mapper = mapper;
            _beerService = new BeerServices();
        }
        public async Task<IActionResult> Index()
        {
            var lstBeer = await _beerService.GetAll();  // Domain objects
            List<BeerVM> beerVMs = new List<BeerVM>();

            if (lstBeer != null)
            {
                beerVMs = _mapper.Map<List<BeerVM>>(lstBeer);
            }

            return View(beerVMs);  // Always VM 
        }
    }
}
