using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using odetofood.core;
using odetofood.data;

namespace WebApplication1.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        public readonly IRestaurantData restaurantData;
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Message { get; private set; }

        [BindProperty(SupportsGet=true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}