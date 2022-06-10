using CafeMenu_API_.Controllers.Models;
using CafeMenu_API_.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeMenu_API_.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasData(
                            new Food
                            {
                                Id = 1,
                                Name = "1111",
                                Description = "11",
                                ImgUrl = "https://www.etestware.com/wp-content/uploads/2020/12/shutterstock_515285995-1200x580.jpg",
                                Price = 1200,
                                Type = "a",
                                Timeslot = "afternoon",
                                Stock = 80
                            },
                            new Food
                            {
                                Id = 2,
                                Name = "2222",
                                Description = "333",
                                ImgUrl = "https://www.etestware.com/wp-content/uploads/2020/12/shutterstock_515285995-1200x580.jpg",
                                Price =800,
                                Type = "b",
                                Timeslot = "afternoon",
                                Stock = 100
                            },
                            new Food
                            {
                                Id = 3,
                                Name = "333",
                                Description = "333",
                                ImgUrl = "https://www.etestware.com/wp-content/uploads/2020/12/shutterstock_515285995-1200x580.jpg",
                                Price = 1000,
                                Type = "c",
                                Timeslot = "afternoon",
                                Stock = 50
                            });
        }
    }
}
