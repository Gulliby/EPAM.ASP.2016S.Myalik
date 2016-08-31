// <copyright file="HomeController.cs" company="No Company">
//     Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Our Party</author>
namespace ApplicationExtension
{
    using System.Web.Mvc;
    
    /// <summary>
    ///  Custom home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Info view.
        /// </summary>
        /// <param name="id">An identifier is a name that identifies either a unique object or a unique class of object.</param>
        /// <param name="superSection">Custom segment.</param>
        /// <returns>JsonResult instance.</returns>
        public ActionResult Info(int? id, string superSection)
        {
            ViewBag.Word = "test title";
            return new JsonResult(); 
        }
    }
}
