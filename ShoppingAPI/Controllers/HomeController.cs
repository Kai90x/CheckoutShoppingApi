using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ShoppingAPI.JsonClass;

namespace ShoppingAPI.Controllers
{
    public class HomeController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            var endpoints = new List<EndpointJson>();
            endpoints.Add(new EndpointJson
            {
                endpoint = "/drinks",
                method = "GET"
            });

            endpoints.Add(new EndpointJson
            {
                endpoint = "/drinks/{name}",
                method = "GET"
            });

            endpoints.Add(new EndpointJson
            {
                endpoint = "/drinks/{name}/{quantity}",
                method = "POST"
            });

            endpoints.Add(new EndpointJson
            {
                endpoint = "/drinks/{name}/{quantity}",
                method = "PUT"
            });

            endpoints.Add(new EndpointJson
            {
                endpoint = "/drinks/{name}",
                method = "DELETE"
            });

            return CreateResponse(endpoints);
        }

    }
}