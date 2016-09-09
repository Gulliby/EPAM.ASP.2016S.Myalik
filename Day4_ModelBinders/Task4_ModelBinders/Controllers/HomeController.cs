using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task4_ModelBinders.Models;

namespace Task4_ModelBinders.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ActionName("CreateUser")]
        public ActionResult CreateUserPost()
        {
            var user = new User();
            if (TryUpdateModel(user, new FormValueProvider(this.ControllerContext)))
            {
                return ViewUser(user);
            }
            return View();
        }

        public ActionResult CreateUserFromQuery()
        {
            var user = new User();
            if (TryUpdateModel(user, new QueryStringValueProvider(this.ControllerContext)))
            {
                return ViewUser(user);
            }
            return View();
        }

        public ActionResult ViewUser(User user)
        {
            return View("ViewUser", user);
        }
    }
}