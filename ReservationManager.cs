using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab7
{
    public class ReservationManager
    {
        private readonly List<Restaurant> _restaurants;

        public List<Restaurant> GetRestaurants()
        {
            return _restaurants;
        }

        public ReservationManager()
        {
            _restaurants = new List<Restaurant>();
        }

        public void AddRestaurant(string name, int tableCount)
        {
            if (tableCount <= 0)
            {
                Console.WriteLine("Table count must be positive.");
                return;
            }

            var restaurant = new Restaurant(name, tableCount);
            _restaurants.Add(restaurant);
        }

        public bool BookTable(string restaurantName, DateTime date, int tableNumber)
        {
            var restaurant = _restaurants.Find(r => r.Name.Equals(restaurantName, StringComparison.OrdinalIgnoreCase));

            if (restaurant == null)
            {
                Console.WriteLine("Restaurant not found.");
                return false;
            }

            return restaurant.BookTable(date, tableNumber);
        }

        public List<string> FindAllFreeTables(DateTime date)
        {
            var freeTables = new List<string>();

            foreach (var restaurant in _restaurants)
            {
                freeTables.AddRange(restaurant.GetFreeTables(date));
            }

            return freeTables;
        }

        

        
    }

}