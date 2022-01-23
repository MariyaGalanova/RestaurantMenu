using RestaurantMenu.Database.Models;

namespace RestaurantMenu.Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for dishe repository
    /// </summary>
    public interface IDisheRepository
    {
        /// <summary>
        ///     Get dishes async
        /// </summary>
        /// <returns></returns>
        Task<List<Dishe>> GetDishesAsync();

        /// <summary>
        ///     Get dishe by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Dishe> GetDisheByIdAsync(int id);

        /// <summary>
        ///     Get dishe by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Dishe> GetDisheByNameAsync(string name);

        /// <summary>
        ///     Create dishe async
        /// </summary>
        /// <param name="dishe"></param>
        /// <returns></returns>
        Task<Dishe> CreateDisheAsync(Dishe dishe);

        /// <summary>
        ///     Edit dishe async
        /// </summary>
        /// <param name="dishe"></param>
        /// <returns></returns>
        Task<Dishe> EditDisheAsync(Dishe dishe);

        /// <summary>
        ///     Delete dishe async
        /// </summary>
        /// <param name="dishe"></param>
        /// <returns></returns>
        Task DeleteDisheAsync(Dishe dishe);
    }
}
