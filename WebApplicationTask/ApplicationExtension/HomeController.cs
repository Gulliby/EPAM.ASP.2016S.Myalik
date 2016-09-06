// <copyright file="HomeController.cs" company="No Company">
//     Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>
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
        /// <returns>JavaScript object notation result instance.</returns>
        public ActionResult Info(int? id)
        {
            return this.Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}
