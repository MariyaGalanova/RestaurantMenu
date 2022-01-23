using FluentAssertions;
using Mapster;
using Moq;
using RestaurantMenu.Database.Models;
using RestaurantMenu.Database.Repositories.Interfaces;
using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;
using RestaurantMenu.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timetable.Infrastructure.Models.Service.Order;
using Xunit;

namespace Timetable.Tests.Services
{
    /// <summary>
    ///     Order service test
    /// </summary>
    public class OrderServiceTest
    {
        Mock<IOrderRepository> orderRepositoryMock;

        public OrderServiceTest()
        {
            orderRepositoryMock = new Mock<IOrderRepository>();
        }

        [Fact]
        public async Task GetOrders_ShouldReturn_Orders()
        {
            //arrange
            var orders = GetTestOrders();

            orderRepositoryMock.Setup(r => r.GetOrdersAsync()).Returns(Task.FromResult(orders.Adapt<List<Order>>()));

            OrderService service = new OrderService(orderRepositoryMock.Object);

            //act
            List<OrderDto> result = await service.GetOrdersAsync();

            //assert
            orders.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetOrderById_ShouldReturn_Order()
        {
            //arrange
            var orders = GetTestOrders();

            orderRepositoryMock.Setup(r => r.GetOrderByIdAsync(orders[0].Id)).Returns(Task.FromResult(orders[0].Adapt<Order>()));

            OrderService service = new OrderService(orderRepositoryMock.Object);

            //act
            OrderDto result = await service.GetOrderByIdAsync(orders[0].Id);

            //assert
            orders[0].Should().BeEquivalentTo(result);
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

            orderRepositoryMock.Setup(r => r.CreateOrderAsync(order.Adapt<Order>())).Returns(Task.FromResult(order.Adapt<Order>()));

            OrderService service = new OrderService(orderRepositoryMock.Object);

            //act
            CreateOrderResponseModel result = await service.CreateOrderAsync(order);

            //assert
            Assert.True(result.Type == OrderResponseType.Success);
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
