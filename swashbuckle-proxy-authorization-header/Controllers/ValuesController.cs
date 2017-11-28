using System.Net;
using System.Web.Http;
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
        [ProxyAuthorizationFilter]
        public string Get(int id)
        {
            return $"value {id}";
        }
    }
}
