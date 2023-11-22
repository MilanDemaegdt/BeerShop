using BeerShopDB.Models.Data;
using BeerShopDB.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BeerShopDB.Repositories
{
    public class BeerDAO
    {

        private readonly BierShopDbContext _dbContext;
        

        public BeerDAO()
        {
            _dbContext = new BierShopDbContext();
        }

        public async Task<IEnumerable<Beer>?> GetAll()
        
        {
            try
            {
                return await _dbContext.Beers.Include(a => a.BrouwernrNavigation).Include(a => a.SoortnrNavigation).ToListAsync();
            }
            catch(Microsoft.Data.SqlClient.SqlException ex)
            {
                Debug.WriteLine("Can't find database", ex.ToString);
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Beer>> GetAllBeerWithBrewer(int brouwerId)

        {
            try
            {
                return await _dbContext.Beers.Where(a => a.Brouwernr == brouwerId).Include(a => a.BrouwernrNavigation).Include(a => a.SoortnrNavigation).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("error DAO beer");
            }
           
        }


        public async Task Insert(Beer beer)

        {
            _dbContext.Entry(beer).State = EntityState.Added;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }


        public async Task<IEnumerable<Beer>?> GetAllBeerWithAlcoholPer(decimal? AlcoholPercent)

        {
            try
            {
                return await _dbContext.Beers.Where(a => a.Alcohol == AlcoholPercent ).Include(a => a.BrouwernrNavigation).Include(a => a.SoortnrNavigation).ToListAsync();
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