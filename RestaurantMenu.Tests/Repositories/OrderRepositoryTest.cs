using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Database;
using RestaurantMenu.Database.Models;
using RestaurantMenu.Database.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Timetable.Tests.Repositories
{
    /// <summary>
    ///     Order repository test
    /// </summary>
    public class OrderRepositoryTest
    {
        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public OrderRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetOrders_ShouldReturn_Orders()
        {
            //arange
            ClearDatabase(context);

            var ordersNew = AddDb(context);

            var orderRepository = new OrderRepository(context);

            //act
            var result = await orderRepository.GetOrdersAsync();

            //assert
            ordersNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetOrderById_ShouldReturn_Order()
        {
            //arrange
            ClearDatabase(context);

            var ordersNew = AddDb(context);

            var orderRepository = new OrderRepository(context);

            //act
            var result = await orderRepository.GetOrderByIdAsync(ordersNew[0].Id);

            //assert
            ordersNew[0].Should().BeEquivalentTo(result);
        }


        [Fact]
        public async Task AddOrder_ShouldReturn_Order()
        {
            //arrange
            var order = new Order
            {
                Id = 11,
                Status = "Confirm"
            };

            var orderRepository = new OrderRepository(context);

            //act
            var result = await orderRepository.CreateOrderAsync(order);

            //assert
            order.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task EditOrder_ShouldReturn_Order()
        {
            //arrange
            ClearDatabase(context);

            var ordersNew = AddDb(context);
            var orderRepository = new OrderRepository(context);

            //act
            var result = await orderRepository.EditOrderAsync(ordersNew[0]);

            //assert
            ordersNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteOrder_ShouldReturn_Order()
        {
            //arrange
            ClearDatabase(context);

            var ordersNew = AddDb(context);
            var orderRepository = new OrderRepository(context);

            //act
            await orderRepository.DeleteOrderAsync(ordersNew[1]);

            //assert
            Assert.True(context.Orders.FirstOrDefault(t => t.Id == ordersNew[1].Id) == null);
        }

        private Order[] AddDb(DatabaseContext database)
        {
            var ordersNew = new[] {

                new Order
                {
                    Id = 1,
                    Status = "Waiting"
                },

                new Order
                {
                    Id = 2,
                    Status = "Coocking"
                }
            };

            database.Orders.AddRange(ordersNew);
            database.SaveChanges();

            return ordersNew;
        }
        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.Orders)
                context.Orders.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
