using System.Web.Mvc;
using System.Web.Routing;

namespace Seed.Web.Api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("LandingPage",
                            "",
                            new
                            {
                                controller = "Application",
                                action = "LandingPage"
                            });

            routes.MapRoute("LogIn",
                            "log-in",
                            new
                            {
                                controller = "Account",
                                action = "LogIn"
                            });

            routes.MapRoute("LogOff",
                "log-off",
                new
                {
                    controller = "Account",
                    action = "LogOff"
                });

            routes.MapRoute("Index",
                            "{*url}",
                            new
                            {
                                controller = "Application",
                                action = "Application",
                            });
        }
    }
}