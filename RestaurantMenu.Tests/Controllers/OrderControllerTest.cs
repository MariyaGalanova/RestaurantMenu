using Microsoft.AspNetCore.Mvc;
using Moq;
using RestaurantMenu.Controllers;
using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;
using RestaurantMenu.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timetable.Infrastructure.Models.Service.Order;
using Xunit;

namespace Timetable.Tests.Controllers
{
    /// <summary>
    ///     Order controller test
    /// </summary>
    public class OrderControllerTest
    {
        Mock<IOrderService> orderServiceMock;

        public OrderControllerTest()
        {
            orderServiceMock = new Mock<IOrderService>();
        }

        [Fact]
        public async Task GetOrders_ShouldReturn_Orders()
        {
            //arrange
            List<OrderDto> orders = GetTestOrders();

            orderServiceMock.Setup(r => r.GetOrdersAsync()).Returns(Task.FromResult(orders));

            OrderController controller = new OrderController(orderServiceMock.Object);

            //act
            IActionResult? result = await controller.GetOrders();
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetOrderById_ShouldReturn_Order()
        {
            //arrange
            var orders = GetTestOrders();

            orderServiceMock.Setup(r => r.GetOrderByIdAsync(orders[0].Id)).Returns(Task.FromResult(orders[0]));

            OrderController controller = new OrderController(orderServiceMock.Object);

            //act
            IActionResult? result = await controller.GetOrder(orders[0].Id);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task AddOrder_ShouldReturn_Order()
        {
            //arrange
            OrderDto order = new OrderDto()
            {
                Id = 11,
                Status = "Confirm"
            };

            orderServiceMock.Setup(r => r.CreateOrderAsync(order)).Returns(Task.FromResult(new CreateOrderResponseModel() {Order = order, Type = OrderResponseType.Success }));

            OrderController controller = new OrderController(orderServiceMock.Object);

            //act
            IActionResult? result = await controller.Post(order);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        private List<OrderDto> GetTestOrders()
        {
            List<OrderDto> orders = new List<OrderDto>
            {
                new OrderDto
                {
                    Id = 1,
                    Status = "Waiting"
                },

                new OrderDto
                {
                    Id = 2,
                    Status = "Coocking"
                }
            };

            return orders;
        }
    }
}
