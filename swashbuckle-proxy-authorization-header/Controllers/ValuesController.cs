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
        /// Get request
        /// </summary>
        /// Get request values
        /// <returns>value with id</returns>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [ProxyAuthorizationFilter]
        [Route("api/Values/GetRequest")]
        public IHttpActionResult GetRequest()
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

        /// <summary>
        /// Get request
        /// </summary>
        /// Get request values
        /// <returns>value with id</returns>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
#if DEBUG
        [OverwriteProxyAuthorizationFilter]
#endif
        [ProxyAuthorizationFilter]
        [Route("api/Values/GetRequestWithBypassedProxyAuthorizationHeader")]
        public IHttpActionResult GetRequestWithBypassedProxyAuthorizationHeader()
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
