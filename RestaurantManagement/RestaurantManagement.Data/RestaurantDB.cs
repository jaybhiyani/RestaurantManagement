using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Data
{
    public class RestaurantDB : DbContext
    {
        public RestaurantDB(DbContextOptions<RestaurantDB> options): base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
