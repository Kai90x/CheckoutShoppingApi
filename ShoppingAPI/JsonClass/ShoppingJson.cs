using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingAPI.DataAccess;

namespace ShoppingAPI.JsonClass
{
    public class ShoppingJson
    {
        public List<DrinkJson> drinks { get; set; }

        public ShoppingJson()
        {
            this.drinks = new List<DrinkJson>();
        }

        public ShoppingJson( List<DrinkJson> drinks)
        {
            this.drinks = drinks;
        }
    }

    public class DrinkJson
    {
        public string name { get; set; }
        public int quantity { get; set; }

        public DrinkJson(Shopping item)
        {
            name = item.name;
            quantity = item.quantity;
        }
    }
}