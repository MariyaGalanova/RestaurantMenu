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
    ///     Dishe repository test
    /// </summary>
    public class DisheRepositoryTest
    {
        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public DisheRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetDishes_ShouldReturn_Dishes()
        {
            //arange
            ClearDatabase(context);

            var dishesNew = AddDb(context);

            var disheRepository = new DisheRepository(context);

            //act
            var result = await disheRepository.GetDishesAsync();

            //assert
            dishesNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetDisheById_ShouldReturn_Dishe()
        {
            //arrange
            ClearDatabase(context);

            var dishesNew = AddDb(context);

            var disheRepository = new DisheRepository(context);

            //act
            var result = await disheRepository.GetDisheByIdAsync(dishesNew[0].Id);

            //assert
            dishesNew[0].Should().BeEquivalentTo(result);
        }


        [Fact]
        public async Task AddDishe_ShouldReturn_Dishe()
        {
            //arrange
            var dishe = new Dishe
            {
                Id = 11,
                Name = "Medovik",
                Price = 700
            };

            var disheRepository = new DisheRepository(context);

            //act
            var result = await disheRepository.CreateDisheAsync(dishe);

            //assert
            dishe.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task EditDishe_ShouldReturn_Dishe()
        {
            //arrange
            ClearDatabase(context);

            var dishesNew = AddDb(context);
            var disheRepository = new DisheRepository(context);

            //act
            var result = await disheRepository.EditDisheAsync(dishesNew[0]);

            //assert
            dishesNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteDishe_ShouldReturn_Dishe()
        {
            //arrange
            ClearDatabase(context);

            var dishesNew = AddDb(context);
            var disheRepository = new DisheRepository(context);

            //act
            await disheRepository.DeleteDisheAsync(dishesNew[1]);

            //assert
            Assert.True(context.Dishes.FirstOrDefault(t => t.Id == dishesNew[1].Id) == null);
        }

        private Dishe[] AddDb(DatabaseContext database)
        {
            var dishesNew = new[] {

                new Dishe
                {
                    Id = 1,
                    Name = "Vareniki",
                    Price = 100
                },

                new Dishe
                {
                    Id = 2,
                    Name = "Pasta",
                    Price = 300
                }
            };

            database.Dishes.AddRange(dishesNew);
            database.SaveChanges();

            return dishesNew;
        }
        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.Dishes)
                context.Dishes.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
