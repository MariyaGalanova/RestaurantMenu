using Mapster;
using RestaurantMenu.Database.Models;
using RestaurantMenu.Database.Repositories.Interfaces;
using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;
using RestaurantMenu.Infrastructure.Services.Interfaces;
using Timetable.Infrastructure.Models.Service.Dishe;

namespace RestaurantMenu.Infrastructure.Services
{
    /// <summary>
    ///     Dishe service
    /// </summary>
    public class DisheService : IDisheService
    {
        public IDisheRepository _disheRepository;

        public DisheService(IDisheRepository disheRepository)
        {
            _disheRepository = disheRepository;
        }

        /// <summary>
        ///     Get dishes async
        /// </summary>
        /// <returns></returns>
        public async Task<List<DisheDto>> GetDishesAsync()
        {
            List<Dishe> dishes = await _disheRepository.GetDishesAsync();
            return dishes.Adapt<List<DisheDto>>();
        }

        /// <summary>
        ///     Get dishe by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DisheDto> GetDisheByIdAsync(int id)
        {
            Dishe dishe = await _disheRepository.GetDisheByIdAsync(id);
            return dishe.Adapt<DisheDto>();
        }

        /// <summary>
        ///     Get dishe by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<DisheDto> GetDisheByNameAsync(string name)
        {
            Dishe dishe = await _disheRepository.GetDisheByNameAsync(name);
            return dishe.Adapt<DisheDto>();
        }

        /// <summary>
        ///     Create dishe async
        /// </summary>
        /// <param name="disheDto"></param>
        /// <returns></returns>
        public async Task<CreateDisheResponseModel> CreateDisheAsync(DisheDto disheDto)
        {
            Dishe dishe = disheDto.Adapt<Dishe>();
            Dishe disheCreated = await _disheRepository.CreateDisheAsync(dishe);

            return new CreateDisheResponseModel()
            {
                Type = DisheResponseType.Success,
                Dishe = disheCreated.Adapt<DisheDto>()
            };
        }

        /// <summary>
        ///     Edit dishe async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="disheDto"></param>
        /// <returns></returns>
        public async Task<EditDisheResponseModel> EditDisheAsync(int id, DisheDto disheDto)
        {
            Dishe dishe = await _disheRepository.GetDisheByIdAsync(id);

            if (dishe == null)
            {
                return new EditDisheResponseModel()
                {
                    Type = DisheResponseType.DisheNotFound
                };
            }

            disheDto.Id = dishe.Id;

            Dishe disheModel = disheDto.Adapt<Dishe>();
            Dishe disheEdited = await _disheRepository.EditDisheAsync(disheModel);

            return new EditDisheResponseModel()
            {
                Type = DisheResponseType.Success,
                Dishe = disheEdited.Adapt<DisheDto>()
            };

        }

        /// <summary>
        ///     Delete dishe async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DisheResponseType> DeleteDisheAsync(int id)
        {
            Dishe dishe = await _disheRepository.GetDisheByIdAsync(id);

            if (dishe == null)
            {
                return DisheResponseType.DisheNotFound;
            }

            await _disheRepository.DeleteDisheAsync(dishe);

            return DisheResponseType.Success;
        }
    }
}
