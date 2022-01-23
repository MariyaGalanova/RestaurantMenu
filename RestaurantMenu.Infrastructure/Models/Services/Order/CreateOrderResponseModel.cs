using RestaurantMenu.Infrastructure.Enums;
using RestaurantMenu.Infrastructure.Models.Database;

namespace Timetable.Infrastructure.Models.Service.Order
{
    /// <summary>
    ///     Create order response model
    /// </summary>
    public class CreateOrderResponseModel
    {
        public OrderResponseType Type { get; set; }
        public OrderDto Order { get; set; }
    }
}
