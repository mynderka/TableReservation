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

        public List<Restaurant> GetRestaurants()
        {
            return _restaurants;
        }

        
    }

}