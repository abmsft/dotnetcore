using odetofood.core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace odetofood.data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
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
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;

        }
    }
}
