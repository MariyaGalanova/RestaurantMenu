using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;

namespace Timetable.Infrastructure.Models.Service.Dishe
{
    /// <summary>
    ///     Create dishe response model
    /// </summary>
    public class CreateDisheResponseModel
    {
        public DisheResponseType Type { get; set; }
        public DisheDto Dishe { get; set; }
    }
}
