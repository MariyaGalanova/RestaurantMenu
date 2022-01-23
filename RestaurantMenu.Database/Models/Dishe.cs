namespace RestaurantMenu.Database.Models
{
    /// <summary>
    ///     Dishe model
    /// </summary>
    public class Dishe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public List<Order>? Orders { get; set; }
    }
}
