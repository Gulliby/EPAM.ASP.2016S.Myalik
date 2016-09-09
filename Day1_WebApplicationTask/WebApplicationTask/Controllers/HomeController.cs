// <copyright file="HomeController.cs" company="No Company">
//     Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace WebApplicationTask.Controllers
{
    using System.Web.Helpers;
    using System.Web.Mvc;
   
    /// <summary>
    /// Entry point.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="id">An identifier is a name that identifies either a unique object or a unique class of object.</param>
        /// <returns>View instance.</returns>
        public ActionResult Index(int? id)
        {
            return this.View();
        }

        /// <summary>
        /// About view.
        /// </summary>
        /// <param name="id">An identifier is a name that identifies either a unique object or a unique class of object.</param>
        /// <returns>View instance.</returns>
        public ActionResult About(int? id)
        {
            return this.View();
        }

        /// <summary>
        /// Info view.
        /// </summary>
        /// <param name="superSection">Custom segment.</param>
        /// <returns>View instance.</returns>
        public ActionResult Info(string superSection)
        {
            ViewBag.SuperSection = superSection;
            return this.View();
        }
    }
}