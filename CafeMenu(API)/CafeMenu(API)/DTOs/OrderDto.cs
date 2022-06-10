using CafeMenu_API_.Models;

namespace CafeMenu_API_.DTOs
{
    public class OrderDto
    {
        public int Id  { get; set; }
        public string CustomerId { get; set; }
        public List<FoodRequestDto> Requests { get; set; }
    }
}
