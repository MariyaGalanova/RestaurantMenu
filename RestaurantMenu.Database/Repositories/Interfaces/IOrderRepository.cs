using RestaurantMenu.Database.Models;

namespace RestaurantMenu.Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for order repository
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        ///     Get orders async
        /// </summary>
        /// <returns></returns>
        Task<List<Order>> GetOrdersAsync();

        /// <summary>
        ///     Get order by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Order> GetOrderByIdAsync(int id);

        /// <summary>
        ///     Create order async
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order> CreateOrderAsync(Order order);

        /// <summary>
        ///     Edit order async
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order> EditOrderAsync(Order order);

        /// <summary>
        ///     Delete order async
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task DeleteOrderAsync(Order order);
    }
}
