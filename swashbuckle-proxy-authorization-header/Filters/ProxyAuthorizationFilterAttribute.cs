using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace swashbuckle_proxy_authorization_header.Filters
{
    public class ProxyAuthorizationFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext context)
        {
            var proxyAuthorizationHeader = context.Request.Headers.ProxyAuthorization;
            context.Request.Headers.TryGetValues("Proxy-Authorization", out var headerFromString);

            if (proxyAuthorizationHeader == null || headerFromString == null ||
                string.IsNullOrEmpty(proxyAuthorizationHeader.ToString()) ||
                headerFromString.All(string.IsNullOrEmpty))
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            base.OnAuthorization(context);
        }
    }
}