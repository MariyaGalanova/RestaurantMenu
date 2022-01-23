using Microsoft.AspNetCore.Mvc;
using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;
using RestaurantMenu.Infrastructure.Services.Interfaces;
using Timetable.Infrastructure.Models.Service.Dishe;

namespace RestaurantMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisheController : ControllerBase
    {
        private readonly IDisheService _disheService;

        public DisheController(IDisheService disheService)
        {
            _disheService = disheService;
        }

        [HttpGet("GetDishes")]
        public async Task<IActionResult> GetDishes()
        {
            List<DisheDto> dishes = await _disheService.GetDishesAsync();

            return Ok(dishes);
        }

        [HttpGet("GetDishe/{id}")]
        public async Task<IActionResult> GetDishe(int id)
        {
            DisheDto dishe = await _disheService.GetDisheByIdAsync(id);

            return Ok(dishe);
        }

        [HttpGet("GetDisheByName/{name}")]
        public async Task<IActionResult> GetDishe(string name)
        {
            DisheDto dishe = await _disheService.GetDisheByNameAsync(name);

            return Ok(dishe);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DisheDto dishe)
        {
            CreateDisheResponseModel createDisheResponse = await _disheService.CreateDisheAsync(dishe);

            if (createDisheResponse.Type == DisheResponseType.Success)
            {
                return Ok(createDisheResponse);
            }

            return BadRequest(createDisheResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DisheDto dishe)
        {
            EditDisheResponseModel editDisheResponse = await _disheService.EditDisheAsync(id, dishe);

            if (editDisheResponse.Type == DisheResponseType.Success)
            {
                return Ok(editDisheResponse);
            }

            return BadRequest(editDisheResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DisheResponseType disheResponse = await _disheService.DeleteDisheAsync(id);

            if (disheResponse == DisheResponseType.Success)
            {
                return Ok(disheResponse);
            }

            return BadRequest(disheResponse);
        }
    }
}
