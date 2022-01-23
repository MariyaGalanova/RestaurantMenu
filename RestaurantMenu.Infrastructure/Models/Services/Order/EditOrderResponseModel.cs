using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;

namespace Timetable.Infrastructure.Models.Service.Order
{
    /// <summary>
    ///     Edit order response model
    /// </summary>
    public class EditOrderResponseModel
    {
        public OrderResponseType Type { get; set; }
        public OrderDto Order { get; set; }

    }
}
