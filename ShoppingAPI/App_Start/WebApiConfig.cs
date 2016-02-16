using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Mvc;

namespace ShoppingAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
               name: "DefaultApiDelete",
               routeTemplate: "drinks/{name}",
               defaults: new { controller = "Drinks", action = "Delete" },
               constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiPost",
                routeTemplate: "drinks/{name}/{quantity}",
                defaults: new { controller = "Drinks", action = "Post" },
               constraints: new { httpMethod = new HttpMethodConstraint(new HttpMethod("POST")) }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiPut",
                routeTemplate: "drinks/{name}/{quantity}",
                defaults: new { controller = "Drinks", action = "Put" },
               constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );


            config.Routes.MapHttpRoute(
                name: "DrinkApiGetByName",
                routeTemplate: "drinks/{name}",
                defaults: new { controller = "Drinks", action = "Get" },
               constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "DrinkApiGetAll",
                routeTemplate: "drinks",
                defaults: new { controller = "Drinks", action = "GetAll" },
               constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
