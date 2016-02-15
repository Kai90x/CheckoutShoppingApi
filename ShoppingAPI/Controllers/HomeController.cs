using System.Web.Http;

namespace ShoppingAPI.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "value";
        }

    }
}
