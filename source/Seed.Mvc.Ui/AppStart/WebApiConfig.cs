using System.Runtime.Serialization.Formatters;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Seed.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            json.SerializerSettings.TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "ApiById",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional });
        }
    }
}
