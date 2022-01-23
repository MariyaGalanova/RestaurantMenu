using Mapster;
using RestaurantMenu.Database.Models;
using RestaurantMenu.Database.Repositories.Interfaces;
using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;
using RestaurantMenu.Infrastructure.Services.Interfaces;
using Timetable.Infrastructure.Models.Service.Order;

namespace RestaurantMenu.Infrastructure.Services
{
    /// <summary>
    ///     Order service
    /// </summary>
    public class OrderService : IOrderService
    {
        public IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        ///     Get orders async
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderDto>> GetOrdersAsync()
        {
            List<Order> orders = await _orderRepository.GetOrdersAsync();
            return orders.Adapt<List<OrderDto>>();
        }

        /// <summary>
        ///     Get order by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            Order order = await _orderRepository.GetOrderByIdAsync(id);
            return order.Adapt<OrderDto>();
        }

        /// <summary>
        ///     Create order async
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        public async Task<CreateOrderResponseModel> CreateOrderAsync(OrderDto orderDto)
        {
            Order order = orderDto.Adapt<Order>();
            Order orderCreated = await _orderRepository.CreateOrderAsync(order);

            return new CreateOrderResponseModel()
            {
                Type = OrderResponseType.Success,
                Order = orderCreated.Adapt<OrderDto>()
            };
        }

        /// <summary>
        ///     Edit order async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        public async Task<EditOrderResponseModel> EditOrderAsync(int id, OrderDto orderDto)
        {
            Order order = await _orderRepository.GetOrderByIdAsync(id);

            if (order == null)
            {
                return new EditOrderResponseModel()
                {
                    Type = OrderResponseType.OrderNotFound
                };
            }

            orderDto.Id = order.Id;

            Order orderModel = orderDto.Adapt<Order>();
            Order orderEdited = await _orderRepository.EditOrderAsync(orderModel);

            return new EditOrderResponseModel()
            {
                Type = OrderResponseType.Success,
                Order = orderEdited.Adapt<OrderDto>()
            };

        }

        /// <summary>
        ///     Delete order async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrderResponseType> DeleteOrderAsync(int id)
        {
            Order order = await _orderRepository.GetOrderByIdAsync(id);

            if (order == null)
            {
                return OrderResponseType.OrderNotFound;
            }

            await _orderRepository.DeleteOrderAsync(order);

            return OrderResponseType.Success;
        }
    }
}
