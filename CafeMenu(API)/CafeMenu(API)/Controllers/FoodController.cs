using CafeMenu_API_.Controllers.Models;
using CafeMenu_API_.Data;
using CafeMenu_API_.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeMenu_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public FoodController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet] // 
        public async Task<ActionResult<List<Food>>> GetFoods(string orderBy, string searchTerm,string timeslot, string type) //to sort by this string
        {
            var query = _dataContext.Foods
                .Sort(orderBy)                     // this one doesn't work, orderBy must be required?
                                                   //.Search(searchTerm)
                .Filter(timeslot, type)
                .AsQueryable();

            return await query.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(int id)
        {
            return await _dataContext.Foods.FindAsync(id);
        }
    }
}
