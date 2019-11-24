using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web
{
    // API Controller to return the a list of restaurants (JSON or XML format).
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData db;

        // getting access to data source, ask the framework to inject and provide 
        // implementation of IRestauranteData - db
        public RestaurantsController(IRestaurantData db)
        {
            // create and initialize a private read only field and 
            // the parameter gives me access to the data source 
            this.db = db;
        }
        public IEnumerable<Restaurant> Get()
        {
            var model = db.GetAll();
            return model;

        }
    }
}
