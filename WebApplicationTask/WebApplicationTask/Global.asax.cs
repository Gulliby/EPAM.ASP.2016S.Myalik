// <copyright file="Global.asax.cs" company="No Company">
//     Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Our Party</author>
namespace WebApplicationTask
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Main MVC application class.
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
