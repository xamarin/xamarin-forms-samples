using System.Web.Http;

namespace TodoRESTService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "TodoItemsApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller="todoitems", id = RouteParameter.Optional }
            );
        }
    }
}
