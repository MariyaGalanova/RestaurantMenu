using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Database.Models;
using RestaurantMenu.Database.Repositories.Interfaces;

namespace RestaurantMenu.Database.Repositories
{
    /// <summary>
    ///     Dishe repository
    /// </summary>
    public class DisheRepository : IDisheRepository
    {
        public DatabaseContext _databaseContext;

        public DisheRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get dishes async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Dishe>> GetDishesAsync()
        {
            return await _databaseContext.Dishes.ToListAsync();
        }

        /// <summary>
        ///     Get dishe by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Dishe> GetDisheByIdAsync(int id)
        {
            return await _databaseContext.Dishes.FirstOrDefaultAsync(d => d.Id == id);
        }

        /// <summary>
        ///     Get dishe by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Dishe> GetDisheByNameAsync(string name)
        {
            return await _databaseContext.Dishes.FirstOrDefaultAsync(d => d.Name == name);
        }

        /// <summary>
        ///     Create dishe async
        /// </summary>
        /// <param name="dishe"></param>
        /// <returns></returns>
        public async Task<Dishe> CreateDisheAsync(Dishe dishe)
        {
            _databaseContext.Dishes.Add(dishe);
            await _databaseContext.SaveChangesAsync();  

            return dishe;
        }

        /// <summary>
        ///     Edit dishe async
        /// </summary>
        /// <param name="dishe"></param>
        /// <returns></returns>
        public async Task<Dishe> EditDisheAsync(Dishe dishe)
        {
            _databaseContext.Dishes.Update(dishe);
            await _databaseContext.SaveChangesAsync();

            return dishe;
        }

        /// <summary>
        ///     Delete dishe async
        /// </summary>
        /// <param name="dishe"></param>
        /// <returns></returns>
        public async Task DeleteDisheAsync(Dishe dishe)
        {
            _databaseContext.Dishes.Remove(dishe);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
