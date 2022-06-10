﻿namespace CafeMenu_API_.Controllers.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string ImgUrl { get; set; }
        public string Type { get; set; }
        public string Timeslot { get; set; }
        public int Stock { get; set; }  
    }
}
