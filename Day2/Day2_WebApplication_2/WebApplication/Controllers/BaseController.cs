using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class BaseController : Controller
    {      
        public ActionResult HandleUnknownAction()
        {
            return View();
        }
    }
}