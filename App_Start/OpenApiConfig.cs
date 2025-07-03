using System.Web.Http;
using System.Web.Http.Cors;

namespace Premium_Data
{
    public static class OpenApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // CORS instellen
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Routes etc...
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}
