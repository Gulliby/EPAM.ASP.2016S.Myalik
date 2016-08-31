// <copyright file="HomeController.cs" company="No Company">
//     Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Our Party</author>
namespace WebApplicationTask.Controllers
{
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
        /// <returns>JsonResult instance.</returns>
        public ActionResult Index(int? id)
        {
            return new JsonResult();
        }

        /// <summary>
        /// About view.
        /// </summary>
        /// <param name="id">An identifier is a name that identifies either a unique object or a unique class of object.</param>
        /// <returns>JsonResult instance.</returns>
        public ActionResult About(int? id)
        {
            return new JsonResult();
        }

        /// <summary>
        /// Info view.
        /// </summary>
        /// <param name="id">An identifier is a name that identifies either a unique object or a unique class of object.</param>
        /// <param name="superSection">Custom segment.</param>
        /// <returns>JsonResult instance.</returns>
        public ActionResult Info(int? id, string superSection)
        {
            return new JsonResult();
        }
    }
}