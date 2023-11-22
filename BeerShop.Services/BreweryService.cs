using BeerShopDB.Models.Entities;
using BeerShopDB.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop.Services
{

    
    public class BreweryService
    {
        private BrewerDAO brewerDAO;

        public BreweryService()
        {
            brewerDAO = new BrewerDAO();
        }
        public async Task<IEnumerable<Brewery>?> GetAll()
        {
            return await brewerDAO.GetAll();
        }
    }

    
}
