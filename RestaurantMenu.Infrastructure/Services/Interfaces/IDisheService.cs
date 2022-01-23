using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;
using Timetable.Infrastructure.Models.Service.Dishe;

namespace RestaurantMenu.Infrastructure.Services.Interfaces
{
    /// <summary>
    ///     Interface for dishe service
    /// </summary>
    public interface IDisheService
    {
        /// <summary>
        ///     Get dishes async
        /// </summary>
        /// <returns></returns>
        Task<List<DisheDto>> GetDishesAsync();

        /// <summary>
        ///     Get dishe by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DisheDto> GetDisheByIdAsync(int id);

        /// <summary>
        ///     Get dishe by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<DisheDto> GetDisheByNameAsync(string name);

        /// <summary>
        ///     Create dishe async
        /// </summary>
        /// <param name="disheDto"></param>
        /// <returns></returns>
        Task<CreateDisheResponseModel> CreateDisheAsync(DisheDto disheDto);

        /// <summary>
        ///     Edit dishe async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="disheDto"></param>
        /// <returns></returns>
        Task<EditDisheResponseModel> EditDisheAsync(int id, DisheDto disheDto);

        /// <summary>
        ///     Delete dishe async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DisheResponseType> DeleteDisheAsync(int id);
    }
}
