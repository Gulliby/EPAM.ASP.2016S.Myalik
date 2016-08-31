// <copyright file="RouteConfig.cs" company="No Company">
//     Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Our Party</author>
namespace WebApplicationTask
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Class for routes requests.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Main method for routes requests.
        /// </summary>
        /// <param name="routes">RouteCollection instance.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Info",
                url: "user/info/{superSection}",
                defaults: new { controller = "Home", action = "Info", superSection = UrlParameter.Optional },
                namespaces: new[] { "ApplicationExtension" });

            routes.MapRoute(
                "About",
                "about/{id}",
                new { controller = "Home", action = "About", id = UrlParameter.Optional },
                new { id = @"\d+" },
                namespaces: new[] { "WebApplicationTask.Controllers" });

            routes.MapRoute(
                "AboutGet",
                "about/get/{id}",
                new { controller = "Home", action = "About", id = UrlParameter.Optional },
                new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) },
                namespaces: new[] { "WebApplicationTask.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplicationTask.Controllers" });
        }
    }
}
