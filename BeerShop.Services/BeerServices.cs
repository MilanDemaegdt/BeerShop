using BeerShopDB.Models.Entities;
using BeerShopDB.Repositories;

namespace BeerShop.Services
{
    public class BeerServices
    {
        private BeerDAO beerDAO;

        public BeerServices()
        {
            beerDAO = new BeerDAO();    
        }

        public async Task<IEnumerable<Beer>?> GetAll()
        {
            return await beerDAO.GetAll();
        }

        public async Task<IEnumerable<Beer>?> GetAllBeerWithBrewer(int brouwerId)
        {
            return await beerDAO.GetAllBeerWithBrewer(brouwerId);
        }

        public async Task Insert(Beer beer)
        {
            await beerDAO.Insert(beer); 
        }

        public async Task<IEnumerable<Beer>?> GetAllBeerWithAlcoholPer(decimal? percentage)
        {
            return await beerDAO.GetAllBeerWithAlcoholPer(percentage);
        }

    }
}