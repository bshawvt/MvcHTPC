using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcHTPC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Account",
                url: "Account/{action}",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "Admin",
                url: "Admin/{action}",
                defaults: new { controller = "Admin", action = "Index" }
            );

            routes.MapRoute(
                name: "Auth",
                url: "Auth/{action}",
                defaults: new { controller = "Auth", action = "Index" }
            );

            routes.MapRoute(
                name: "Community",
                url: "Community/{action}/{id}",
                defaults: new { controller = "Community", action = "Forum", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Notifier",
                url: "Community/Notifier",
                defaults: new { controller = "Community", action = "Notifier" }
            );

            routes.MapRoute(
                name: "Folders",
                url: "Folders/Folder/{id}",
                defaults: new { controller = "Folder", action = "Folder", id = UrlParameter.Optional }
            );

            // last
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
