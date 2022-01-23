using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;
using Timetable.Infrastructure.Models.Service.Order;

namespace RestaurantMenu.Infrastructure.Services.Interfaces
{
    /// <summary>
    ///     Interface for order service
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        ///     Get orders async
        /// </summary>
        /// <returns></returns>
        Task<List<OrderDto>> GetOrdersAsync();

        /// <summary>
        ///     Get order by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrderDto> GetOrderByIdAsync(int id);

        /// <summary>
        ///     Create order async
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        Task<CreateOrderResponseModel> CreateOrderAsync(OrderDto orderDto);

        /// <summary>
        ///     Edit order async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        Task<EditOrderResponseModel> EditOrderAsync(int id, OrderDto orderDto);

        /// <summary>
        ///     Delete order async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrderResponseType> DeleteOrderAsync(int id);
    }
}
