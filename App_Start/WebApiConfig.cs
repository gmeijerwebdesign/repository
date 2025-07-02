using System.Web.Http;

namespace Premium_Data
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Attribute routing aanzetten zodat [Route("api/login")] werkt
            config.MapHttpAttributeRoutes();

            // Default API route (optioneel, maar handig als fallback)
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
