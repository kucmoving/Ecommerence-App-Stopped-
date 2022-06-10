using CafeMenu_API_.Controllers.Models;

namespace CafeMenu_API_.Extensions
{
    public static class FoodExtensions
    {
        public static IQueryable<Food> Sort(this IQueryable<Food> query, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(f => f.Name);
            query = orderBy switch
            {
                "price" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name)
            };
            return query;
        }

        public static IQueryable<Food> Search(this IQueryable<Food> query, string searchterm)
        {
            if (string.IsNullOrEmpty(searchterm)) return query;
            var smalllettersearch = searchterm.Trim().ToLower();
            return query.Where(p => p.Name.ToLower().Contains(smalllettersearch));
        }

        public static IQueryable<Food> Filter(this IQueryable<Food> query, string timeslot, string type)
        {
            var timeSlotList = new List<string>();
            var typeList = new List<string>();

            if (!string.IsNullOrEmpty(timeslot))
                timeSlotList.AddRange(timeslot.ToLower().Split(",").ToList());

            if (!string.IsNullOrEmpty(type))
                typeList.AddRange(type.ToLower().Split(",").ToList());

            query = query.Where(f => timeSlotList.Count == 0 || typeList.Contains(f.Timeslot.ToLower()));
            query = query.Where(f => typeList.Count == 0 || typeList.Contains(f.Type.ToLower()));

            return query;
        }
    }
}