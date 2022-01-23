namespace RestaurantMenu.Database.Models
{
    /// <summary>
    ///     Order model
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public List<Dishe>? Dishes { get; set; }
    }
}
