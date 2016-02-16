using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingAPI.DataAccess;
using ShoppingAPI.JsonClass;
using ShoppingAPI.Managers.Interfaces;
using ShoppingAPI.Utils;

namespace ShoppingAPI.Controllers
{
    public class DrinksController : BaseApiController
    {
        private readonly IShoppingManager _shoppingManager;
        private delegate Shopping shoppingAction(string name,int quantity);

        public DrinksController(IShoppingManager shoppingManager)
        {
            _shoppingManager = shoppingManager;
        }

        [HttpGet]
        public HttpResponseMessage Get(string name)
        {
            var drink = _shoppingManager.get(name);
            if (drink == null)
                return CreateResponse(string.Format("No items found for {0}",name));

            var drinkJson = new DrinkJson(drink);
            var shoppingJson = new ShoppingJson();
            shoppingJson.drinks.Add(drinkJson);

            return CreateResponse<ShoppingJson>(shoppingJson);
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var drinks = _shoppingManager.get();
            if (drinks == null || drinks.Count == 0)
                return CreateResponse(string.Format("No items found"));

            List<DrinkJson> drinksJson = drinks.Select(drink => new DrinkJson(drink)).ToList();
            var shoppingJson = new ShoppingJson(drinksJson);

            return CreateResponse<ShoppingJson>(shoppingJson);
        }

        [HttpPost]
        public HttpResponseMessage Post(string name,int quantity)
        {
            return AddOrUpdate(name, quantity, _shoppingManager.add);
        }

        [HttpPut]
        public HttpResponseMessage Put(string name,int quantity)
        {
            return AddOrUpdate(name, quantity, _shoppingManager.update);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
                return CreateErrorResponse("name is a required parameter");

            try
            {
                _shoppingManager.delete(name);
                return CreateResponse(string.Format("{0} has been deleted",name));
            }
            catch (Exception ex) 
            {
                Log("Delete", ex.Message);
                return CreateErrorResponse(string.Format("No item with name {0} found", name));
            }
        }

        private HttpResponseMessage AddOrUpdate(string name, int? quantity, shoppingAction action)
        {
            if (string.IsNullOrEmpty(name) || quantity == null)
                return CreateErrorResponse("name and quantity are required parameters");

            try
            {
                var drink = action(name, quantity.Value);
                var drinkJson = new DrinkJson(drink);
                var shoppingJson = new ShoppingJson();
                shoppingJson.drinks.Add(drinkJson);

                return CreateResponse<ShoppingJson>(shoppingJson);
            }
            catch (Exception ex)
            {
                Log("AddOrUpdate", ex.Message);
                return CreateErrorResponse(ex.Message);
            }
        }

    }
}