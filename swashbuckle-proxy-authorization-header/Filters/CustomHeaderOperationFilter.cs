using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace swashbuckle_proxy_authorization_header.Filters
{
    internal class CustomHeaderOperationFilter : IOperationFilter
    {
        private readonly string _name;

        public CustomHeaderOperationFilter(string name)
        {
            _name = name;
        }

        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            if (operation.parameters.All(p => p.name != _name))
            {
                operation.parameters.Add(new Parameter
                {
                    name = _name,
                    @in = "header",
                    description = $"{_name} header",
                    required = false,
                    type = "string"
                });
            }
        }
    }
}