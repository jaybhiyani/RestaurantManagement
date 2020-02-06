using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantManagement.Core;
using RestaurantManagement.Data;

namespace RestaurantManagement
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public IHtmlHelper _htmlHelper { get; }

        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this._restaurantData = restaurantData;
            this._htmlHelper = htmlHelper;
        }
        
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if(restaurantId.HasValue)
            {
                Restaurant = _restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (Restaurant.Id > 0)
            {
                _restaurantData.Update(Restaurant);
            }
            else
            {
                _restaurantData.Add(Restaurant);
                TempData["Message"] = "Restaurant: "+Restaurant.Name+" saved";
            }
            _restaurantData.Commit();
            return RedirectToPage("./List", new { restaurantId = Restaurant.Id});
        }
    }
}