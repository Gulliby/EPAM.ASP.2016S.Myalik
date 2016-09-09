using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Infrastructure
{
    public class CustomActionInvoker : IActionInvoker
    {
        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (!controllerContext.RequestContext.HttpContext.Request.IsLocal) return false;
            new ControllerActionInvoker().InvokeAction(controllerContext, actionName);
            return true;
        }
    }
}