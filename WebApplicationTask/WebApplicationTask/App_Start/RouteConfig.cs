﻿// <copyright file="RouteConfig.cs" company="No Company">
//     Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace WebApplicationTask
{
    using System.Web.Mvc;
    using System.Web.Mvc.Routing.Constraints;
    using System.Web.Routing;
    using WebApplicationTask.Constraints;

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
                name: "StaticCustomOptional",
                url: "user/info/{superSection}",
                defaults: new { controller = "Home", action = "Info", superSection = UrlParameter.Optional },
                namespaces: new[] { "WebApplicationTask.Controllers" });

            routes.MapRoute(
                name: "NamespacePriority",
                url: "user/myinfo/{id}",
                defaults: new { controller = "Home", action = "Info", id = UrlParameter.Optional },
                namespaces: new[] { "ApplicationExtension" });

            routes.MapRoute(
                name: "CompoundConstraint",
                url: "news/{id}/{*catchall}",
                defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional },
                constraints: new
                {
                    httpMethod = new HttpMethodConstraint("GET", "POST"),
                    id = new CompoundRouteConstraint(
                        new IRouteConstraint[]
                        {
                            new AlphaRouteConstraint(),
                            new MinLengthRouteConstraint(6)
                        })
                });

            routes.MapRoute(
                name: "CustomConstraint",
                url: "about/get/{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint("GET"), id = new FibonacciConstraint() },
                namespaces: new[] { "WebApplicationTask.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplicationTask.Controllers" });
        }
    }
}
