
using CafeMenu_API_.Data;
using CafeMenu_API_.DTOs;
using CafeMenu_API_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeMenu_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public OrderController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet (Name = "GetOrder")] //to get the order (read)
        public async Task<ActionResult<OrderDto>> GetOrder()
        {
            var order = await ReadOrder(); //call the exact method 
            if (order == null) return NotFound();

            return MapOrderDto(order);
        }



        [HttpPost]
        public async Task<ActionResult< OrderDto>> AddOrder(int foodId, int quantity)
        {
            //call the exact method 
            var order = await ReadOrder();
            // make order
            if (order == null) order = MakeOrder();
            // get food
            var food = await _dataContext.Foods.FindAsync(foodId);
            if (food == null) return BadRequest(new ProblemDetails { Title = "Food Not Found." });
            // add food
            order.AddFood(food, quantity);
            // save 
            var result = await _dataContext.SaveChangesAsync() > 0;

            if (result) return CreatedAtRoute("GetOrder", MapOrderDto(order));// not StatusCode(201);
            return BadRequest(new ProblemDetails { Title = "Problem saving item to basket"});
        }



        [HttpDelete]
        public async Task<ActionResult> CancelOrder(int foodId, int quantity)
        {
            //get order
            var basket = await ReadOrder();
            if (basket == null) return NotFound();
            //cancel , reduce
            basket.CancelRequest(foodId, quantity);
            //save 
            var result = await _dataContext.SaveChangesAsync() > 0;
            if (result) return Ok();
            return BadRequest(new ProblemDetails { Title = "there is an error." });

        }

        //exact method
        private async Task<Order> ReadOrder()
        {
            return await _dataContext.Orders
                            .Include(r => r.Requests)
                            .ThenInclude(f => f.Food)
                            .FirstOrDefaultAsync(o => o.CustomerId == Request.Cookies["CustomerId"]);
        }

        private Order MakeOrder()
        {
            var customerId = Guid.NewGuid().ToString(); // to generate a unique id to prevent the same number
            var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30)}; //cookie option
            Response.Cookies.Append("customerId", customerId, cookieOptions);
            var order = new Order { CustomerId = customerId };
            _dataContext.Orders.Add(order);
            return order;
        }

        private static ActionResult<OrderDto> MapOrderDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,                                                                     //DTO properties 1
                CustomerId = order.CustomerId,                                         // DTO properties 2
                Requests = order.Requests.Select(request => new FoodRequestDto // nested DTO
                {
                    FoodId = request.Id,
                    Name = request.Food.Name,
                    Price = request.Food.Price,
                    ImgUrl = request.Food.ImgUrl,
                    Type = request.Food.Type,
                    Timeslot = request.Food.Timeslot,
                    Stock = request.Quantity

                }).ToList()
            };
        }
    }
}
