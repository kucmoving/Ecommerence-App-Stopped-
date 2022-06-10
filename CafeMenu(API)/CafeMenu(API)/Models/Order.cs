using CafeMenu_API_.Controllers.Models;

namespace CafeMenu_API_.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }

        // one to many relationship , and form new list each time
        public List<FoodRequest> Requests { get; set; } = new List<FoodRequest>();


        // to use the memory to handle + - function
        public void AddFood(Food food, int quantity)
        {
            if (Requests.All(request => request.FoodId != food.Id)) //to check request is not in order  ?
            {
                Requests.Add(new FoodRequest { Food = food, Quantity = quantity}); // if not then add food and quantity
            }

            var previousRequest = Requests.FirstOrDefault(request => request.FoodId == food.Id); // define the food was ordered
            if (previousRequest != null) previousRequest.Quantity += quantity;  // then add quantity 
        }

        public void CancelRequest(int foodId, int quantity)
        {
            var request = Requests.FirstOrDefault(request => request.FoodId == foodId); //to define old record
            if (request == null) return;                                                                           // nothing if null
            request.Quantity -= quantity;                                                                       // if any then reduce
            if (request.Quantity < 1) Requests.Remove(request); 
        }
    }
}
