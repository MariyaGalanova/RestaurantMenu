using Microsoft.AspNetCore.Mvc;
using Moq;
using RestaurantMenu.Controllers;
using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;
using RestaurantMenu.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timetable.Infrastructure.Models.Service.Dishe;
using Xunit;

namespace Timetable.Tests.Controllers
{
    /// <summary>
    ///     Dishe controller test
    /// </summary>
    public class DisheControllerTest
    {
        Mock<IDisheService> disheServiceMock;

        public DisheControllerTest()
        {
            disheServiceMock = new Mock<IDisheService>();
        }

        [Fact]
        public async Task GetDishes_ShouldReturn_Dishes()
        {
            //arrange
            List<DisheDto> dishes = GetTestDishes();

            disheServiceMock.Setup(r => r.GetDishesAsync()).Returns(Task.FromResult(dishes));

            DisheController controller = new DisheController(disheServiceMock.Object);

            //act
            IActionResult? result = await controller.GetDishes();
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetDisheById_ShouldReturn_Dishe()
        {
            //arrange
            var dishes = GetTestDishes();

            disheServiceMock.Setup(r => r.GetDisheByIdAsync(dishes[0].Id)).Returns(Task.FromResult(dishes[0]));

            DisheController controller = new DisheController(disheServiceMock.Object);

            //act
            IActionResult? result = await controller.GetDishe(dishes[0].Id);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
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

            disheServiceMock.Setup(r => r.CreateDisheAsync(dishe)).Returns(Task.FromResult(new CreateDisheResponseModel() {Dishe = dishe, Type = DisheResponseType.Success }));

            DisheController controller = new DisheController(disheServiceMock.Object);

            //act
            IActionResult? result = await controller.Post(dishe);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
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
