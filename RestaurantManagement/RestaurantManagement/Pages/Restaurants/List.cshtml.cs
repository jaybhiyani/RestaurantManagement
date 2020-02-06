using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using RestaurantManagement.Core;
using RestaurantManagement.Data;

namespace RestaurantManagement.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        public readonly IRestaurantData restaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        // To get message property placed in appsettings.json file

        /*private readonly IConfiguration config;

        public ListModel(IConfiguration config)
        {
            this.config = config;
        }

        public void OnGet()
        {
            Message = config["Message"];
        }*/

        //public void OnGet(string searchTerm)
        //{
        //    Message = "Welcome to Main Page";
        //    //Restaurants = restaurantData.GetAll();    
        //    Restaurants = restaurantData.GetRestaurantsByName(searchTerm);
        //}
        public void OnGet()
        {
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
