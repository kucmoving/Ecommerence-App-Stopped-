using CafeMenu_API_.Controllers.Models;

namespace CafeMenu_API_.Models
{
    public class FoodRequest
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        // to link a 1:1 relationship

        public int FoodId { get; set; }
        public Food Food { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}