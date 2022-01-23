using Microsoft.AspNetCore.Mvc;
using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;
using RestaurantMenu.Infrastructure.Services.Interfaces;
using Timetable.Infrastructure.Models.Service.Order;

namespace RestaurantMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            List<OrderDto> orders = await _orderService.GetOrdersAsync();

            return Ok(orders);
        }

        [HttpGet("GetOrder/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            OrderDto order = await _orderService.GetOrderByIdAsync(id);

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderDto order)
        {
            CreateOrderResponseModel createOrderResponse = await _orderService.CreateOrderAsync(order);

            if (createOrderResponse.Type == OrderResponseType.Success)
            {
                return Ok(createOrderResponse);
            }

            return BadRequest(createOrderResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrderDto order)
        {
            EditOrderResponseModel editOrderResponse = await _orderService.EditOrderAsync(id, order);

            if (editOrderResponse.Type == OrderResponseType.Success)
            {
                return Ok(editOrderResponse);
            }

            return BadRequest(editOrderResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            OrderResponseType orderResponse = await _orderService.DeleteOrderAsync(id);

            if (orderResponse == OrderResponseType.Success)
            {
                return Ok(orderResponse);
            }

            return BadRequest(orderResponse);
        }
    }
}
