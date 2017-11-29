using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using swashbuckle_proxy_authorization_header.Filters;
using Swashbuckle.Swagger.Annotations;

namespace swashbuckle_proxy_authorization_header.Controllers
{
    /// <summary>
    /// Values controller
    /// </summary>
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Get by id method
        /// </summary>
        /// <remarks>
        /// Get string "value {id:int}" by called id
        /// </remarks>
        /// <param name="id">get id to return</param>
        /// <returns>value with id</returns>
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        //[ProxyAuthorizationFilter]
        public IHttpActionResult Get(int id)
        {
            var request = new ControllerRequest
            {
                Body = Request.Content.ReadAsStringAsync().Result,
                Headers = Request.Headers
                    .Select(header => 
                        new Tuple<string, List<string>>(header.Key, header.Value.ToList())).ToList()
            };

            return Json(request);
        }
    }

    internal class ControllerRequest
    {
        public List<Tuple<string, List<string>>> Headers;
        public string Body;
    }
}
