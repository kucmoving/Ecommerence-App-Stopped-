namespace CafeMenu_API_.DTOs
{
    public class FoodRequestDto
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public string ImgUrl { get; set; }
        public string Type { get; set; }
        public string Timeslot { get; set; }
        public int Stock { get; set; }
    }
}