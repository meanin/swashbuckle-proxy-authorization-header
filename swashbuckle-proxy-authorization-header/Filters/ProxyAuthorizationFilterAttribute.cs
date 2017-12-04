using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace swashbuckle_proxy_authorization_header.Filters
{
    public class ProxyAuthorizationFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext context)
        {
            var proxyAuthorizationHeader = context.Request.Headers.ProxyAuthorization;

            if (string.IsNullOrEmpty(proxyAuthorizationHeader?.ToString()))
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            base.OnAuthorization(context);
        }
    }
}