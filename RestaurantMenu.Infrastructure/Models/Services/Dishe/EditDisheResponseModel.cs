using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;

namespace Timetable.Infrastructure.Models.Service.Dishe
{
    /// <summary>
    ///     Edit dishe response model
    /// </summary>
    public class EditDisheResponseModel
    {
        public DisheResponseType Type { get; set; }
        public DisheDto Dishe { get; set; }

    }
}
