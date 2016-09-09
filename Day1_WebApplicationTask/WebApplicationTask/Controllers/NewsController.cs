// <copyright file="NewsController.cs" company="No Company">
// Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>
namespace WebApplicationTask.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// News controller.
    /// </summary>
    public class NewsController : Controller
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="id">An identifier is a name that identifies either a unique object or a unique class of object.</param>
        /// <returns>View instance.</returns>
        public ActionResult Index(string id)
        {
            ViewBag.Some = id;
            return this.View();
        }
    }
}