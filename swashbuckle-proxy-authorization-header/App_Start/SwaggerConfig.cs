using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using WebActivatorEx;
using swashbuckle_proxy_authorization_header;
using System.Collections.Generic;
using System;

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
                    c.OperationFilter<ProxyAuthorizationHeaderOperationFilter>();
                })
                .EnableSwaggerUi();
        }
    }

    internal class ProxyAuthorizationHeaderOperationFilter : IOperationFilter
    {
        private static string Name = "Proxy-Authorization";

        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            if (operation.parameters.All(p => p.name != Name))
            {
                operation.parameters.Add(new Parameter
                {
                    name = Name,
                    @in = "header",
                    description = $"{Name} header",
                    required = true,
                    type = "string"
                });
            }
        }
    }

}