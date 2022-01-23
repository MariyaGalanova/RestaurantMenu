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
using Timetable.Infrastructure.Models.Service.Dishe;
using Xunit;

namespace Timetable.Tests.Services
{
    /// <summary>
    ///     Dishe service test
    /// </summary>
    public class DisheServiceTest
    {
        Mock<IDisheRepository> disheRepositoryMock;

        public DisheServiceTest()
        {
            disheRepositoryMock = new Mock<IDisheRepository>();
        }

        [Fact]
        public async Task GetDishes_ShouldReturn_Dishes()
        {
            //arrange
            var dishes = GetTestDishes();

            disheRepositoryMock.Setup(r => r.GetDishesAsync()).Returns(Task.FromResult(dishes.Adapt<List<Dishe>>()));

            DisheService service = new DisheService(disheRepositoryMock.Object);

            //act
            List<DisheDto> result = await service.GetDishesAsync();

            //assert
            dishes.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetDisheById_ShouldReturn_Dishe()
        {
            //arrange
            var dishes = GetTestDishes();

            disheRepositoryMock.Setup(r => r.GetDisheByIdAsync(dishes[0].Id)).Returns(Task.FromResult(dishes[0].Adapt<Dishe>()));

            DisheService service = new DisheService(disheRepositoryMock.Object);

            //act
            DisheDto result = await service.GetDisheByIdAsync(dishes[0].Id);

            //assert
            dishes[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddDishe_ShouldReturn_Dishe()
        {
            //arrange
            DisheDto dishe = new DisheDto()
            {
                Id = 11,
                Name = "Medovik",
                Price = 700
            };

            disheRepositoryMock.Setup(r => r.CreateDisheAsync(dishe.Adapt<Dishe>())).Returns(Task.FromResult(dishe.Adapt<Dishe>()));

            DisheService service = new DisheService(disheRepositoryMock.Object);

            //act
            CreateDisheResponseModel result = await service.CreateDisheAsync(dishe);

            //assert
            Assert.True(result.Type == DisheResponseType.Success);
        }

        private List<DisheDto> GetTestDishes()
        {
            List<DisheDto> dishes = new List<DisheDto>
            {
                new DisheDto
                {
                    Id = 1,
                    Name = "Vareniki",
                    Price = 100
                },

                new DisheDto
                {
                    Id = 2,
                    Name = "Pasta",
                    Price = 300
                }
            };

            return dishes;
        }
    }
}
