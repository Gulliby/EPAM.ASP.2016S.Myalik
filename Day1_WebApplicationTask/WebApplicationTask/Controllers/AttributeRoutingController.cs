// <copyright file="AttributeRoutingController.cs" company="No Company">
// Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>
namespace WebApplicationTask.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Attribute routing controller.
    /// </summary>
    [RoutePrefix("AttributeTest")]
    public class AttributeRoutingController : Controller
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <returns>View instance.</returns>
        [Route("Index")]
        public ActionResult Index()
        {
            ViewBag.Action = "Index";
            ViewBag.Controller = "Attribute Routing";
            return this.View();
        }

        /// <summary>
        /// About view.
        /// </summary>
        /// <param name="id">An identifier is a name that identifies either a unique object or a unique class of object.</param>
        /// <returns>View instance.</returns>
        [Route("About/{id:int}")]
        public ActionResult About(int? id)
        {
            ViewBag.Action = "About";
            ViewBag.Controller = "Attribute Routing";
            return this.View("Index");
        }

        /// <summary>
        /// Start view.
        /// </summary>
        /// <param name="path">The path where we need to start from.</param>
        /// <returns>View instance.</returns>
        [Route("Start/{path:maxlength(10):minlength(2)}")]
        public ActionResult Start(string path)
        {
            ViewBag.Action = "Start";
            ViewBag.Controller = "Attribute Routing";
            return this.View("Index");
        }
    }
}