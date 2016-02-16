using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingAPI.JsonClass
{
    public class EndpointJson
    {
        public string method { get; set; }
        public string endpoint { get; set; }
        public List<string> parameters { get; set; }
     }
}