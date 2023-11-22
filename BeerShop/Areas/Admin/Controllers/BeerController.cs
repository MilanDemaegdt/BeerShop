using AutoMapper;
using BeerShop.Areas.Admin.ViewModels;
using BeerShop.Services;
using BeerShop.ViewModels;
using BeerShopDB.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace BeerShop.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class BeerController : Controller
    {
        private readonly BreweryService _breweryService;
        private readonly BeerServices _beerService;
        private readonly VarietyService _varietyService;

        private readonly IMapper _mapper;


        public BeerController(IMapper mapper)
        {// Later with DI
            _mapper = mapper;
            _beerService = new BeerServices();
            _breweryService = new BreweryService();
            _varietyService = new VarietyService(); 
        }
        public async Task<IActionResult> Index()

        {
            try
            {
                var lstBeer = await _beerService.GetAll();  // Domain objects
                List<BeerAdminVM> beerVMs = new List<BeerAdminVM>();
                 beerVMs = _mapper.Map<List<BeerAdminVM>>(lstBeer);

                return View(beerVMs);  // Always VM 
            }

            catch(Exception e)
            {
                Debug.WriteLine("Errorlog {0}", e.Message);
            }

            return View();
        }




        public async Task<IActionResult> CreateBearIndex()
        {

            var createBeerVMs = new CreateBeerVM()
            {

                Brouwer = new SelectList(await _breweryService.GetAll(), "Brouwernr", "Naam"),
                Soort = new SelectList(await _varietyService.GetAll(), "Soortnr", "Soortnaam")
            };
            
            return View(createBeerVMs);  // Always VM 
    
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBearIndex(CreateBeerVM entityVM)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var beer = _mapper.Map<Beer>(entityVM);
                    await _beerService.Insert(beer);
                    return RedirectToAction("Index");

                }
            }
            catch(SqlException Ex)
            {
                ModelState.AddModelError("", "");
            }
            catch(DataException Ex)
            {
                ModelState.AddModelError("", "Unable to save changes");
            }
            catch(Exception Ex)
            {
                ModelState.AddModelError("", "call system administration");
            }

            entityVM.Brouwer = new SelectList(await _breweryService.GetAll(), "Brouwernr", "Naam", entityVM.Brouwernr);
            entityVM.Soort = new SelectList(await _varietyService.GetAll(), "Soortnr", "Soortnaam", entityVM.Soortnr);

            return View(entityVM);

        }

    }

}
