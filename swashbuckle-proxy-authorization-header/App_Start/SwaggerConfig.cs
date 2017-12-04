using System.Web.Http;
using Swashbuckle.Application;
using WebActivatorEx;
using swashbuckle_proxy_authorization_header;
using System;
using swashbuckle_proxy_authorization_header.Filters;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace swashbuckle_proxy_authorization_header
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "swashbuckle_proxy_authorization_header");
                    c.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}\\bin\\swashbuckle-proxy-authorization-header.xml");
#if DEBUG
                    c.OperationFilter(() => new CustomHeaderOperationFilter("ProxyAuthorization"));
                    c.OperationFilter(() => new CustomHeaderOperationFilter("Proxy-Authorization"));
#endif
                })
                .EnableSwaggerUi();
        }
    }
}