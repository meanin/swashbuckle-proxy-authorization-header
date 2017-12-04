using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace swashbuckle_proxy_authorization_header.Filters
{
    public class OverwriteProxyAuthorizationFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext context)
        {
            var proxyAuthorizationHeader = context.Request.Headers.SingleOrDefault(h => h.Key == "ProxyAuthorization");

            if(context.Request.Headers.ProxyAuthorization == null && proxyAuthorizationHeader.Value != null)
                context.Request.Headers.Add("Proxy-Authorization", proxyAuthorizationHeader.Value);

            base.OnAuthorization(context);
        }
    }
}