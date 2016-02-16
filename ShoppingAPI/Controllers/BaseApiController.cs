using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Http;
using ShoppingAPI.Utils;

namespace ShoppingAPI.Controllers
{
    public class BaseApiController : ApiController
    {

        /// <summary>
        /// Create OK Response with specific mediaType
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="mediaType">default: application/json</param>
        /// <returns></returns>
        public HttpResponseMessage CreateResponse<T>(T model, HttpStatusCode code = HttpStatusCode.OK, string mediaType = "application/json")
        {
            HttpResponseMessage response = Request.CreateResponse<T>(code, model, mediaType);
            return response;
        }

        /// <summary>
        /// Create KO Response with specific mediaType
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="mediaType">default: application/json</param>
        /// <returns></returns>
        public HttpResponseMessage CreateErrorResponse<T>(T model, string mediaType = "application/json")
        {
            HttpResponseMessage response = Request.CreateResponse<T>(HttpStatusCode.InternalServerError, model, mediaType);
            return response;
        }

        public void Log(string method,string error)
        {
            LogUtils.LogError(this.GetType().Name,method,error);
        }
    }
}