using System.Collections.Generic;
using System.Text;
using RestaurantManagement.Core;

namespace RestaurantManagement.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        public Restaurant GetById(int restaurantId);
        public Restaurant Update(Restaurant restaurant);
        public int Commit();
        public Restaurant Add(Restaurant newRestaurant);
        public Restaurant Delete(int id);
    }
}
