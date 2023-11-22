using BeerShopDB.Models.Entities;
using BeerShopDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop.Services
{
    public class VarietyService
    {
        private VarietyDAO varietyDAO;

        public VarietyService()
        {
            varietyDAO = new VarietyDAO();
        }
        public async Task<IEnumerable<Variety>?> GetAll()
        {
            return await varietyDAO.GetAll();
        }
    }
}
