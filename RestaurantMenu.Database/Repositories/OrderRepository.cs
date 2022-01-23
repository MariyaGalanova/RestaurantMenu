using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Database.Models;
using RestaurantMenu.Database.Repositories.Interfaces;

namespace RestaurantMenu.Database.Repositories
{
    /// <summary>
    ///     Order repository
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        public DatabaseContext _databaseContext;

        public OrderRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get orders async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _databaseContext.Orders.ToListAsync();
        }

        /// <summary>
        ///     Get order by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _databaseContext.Orders.FirstOrDefaultAsync(d => d.Id == id);
        }

        /// <summary>
        ///     Create order async
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> CreateOrderAsync(Order order)
        {
            _databaseContext.Orders.Add(order);
            await _databaseContext.SaveChangesAsync();  

            return order;
        }

        /// <summary>
        ///     Edit order async
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> EditOrderAsync(Order order)
        {
            _databaseContext.Orders.Update(order);
            await _databaseContext.SaveChangesAsync();

            return order;
        }

        /// <summary>
        ///     Delete order async
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task DeleteOrderAsync(Order order)
        {
            _databaseContext.Orders.Remove(order);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
