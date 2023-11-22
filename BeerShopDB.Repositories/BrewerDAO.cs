﻿using BeerShopDB.Models.Data;
using BeerShopDB.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShopDB.Repositories
{
    
    public class BrewerDAO
    {
        private readonly BierShopDbContext _dbContext;

        public BrewerDAO()
        {
            _dbContext = new BierShopDbContext();   
        }

        public async Task<IEnumerable<Brewery>?> GetAll()

        {
            try
            {
                return await _dbContext.Breweries.ToListAsync();
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                Debug.WriteLine("Can't find database", ex.ToString);
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
