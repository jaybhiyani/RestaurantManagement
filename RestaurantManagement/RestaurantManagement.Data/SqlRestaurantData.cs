using System.Collections.Generic;
using RestaurantManagement.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestaurantManagement.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        public SqlRestaurantData(RestaurantDB db)
        {
            Db = db;
        }

        public RestaurantDB Db { get; }

        public Restaurant Add(Restaurant newRestaurant)
        {
            Db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return Db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if(restaurant != null)
            {
                Db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            var query = from r in Db.Restaurants
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant GetById(int restaurantId)
        {
            return Db.Restaurants.Find(restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in Db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = Db.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }
    }
}
