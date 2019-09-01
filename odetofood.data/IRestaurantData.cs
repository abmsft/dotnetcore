using odetofood.core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace odetofood.data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id=1, Name="Scot's Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
                new Restaurant { Id=1, Name="Ahmed's Pizza", Location="London", Cuisine=CuisineType.Italian},
                new Restaurant { Id=1, Name="La Costa", Location="California", Cuisine=CuisineType.Italian}
            };

        }
        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where String.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;

        }
    }
}
