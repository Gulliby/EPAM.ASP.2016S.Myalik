using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using WebApplication.Controllers;

namespace WebApplication.Infrastructure
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, Type controllerType)
        {
            return controllerType == typeof(HomeController) ? SessionStateBehavior.Disabled : base.GetControllerSessionBehavior(requestContext, controllerType);
        }

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            return string.Compare(controllerName, "Customer", StringComparison.OrdinalIgnoreCase) == 0 ? typeof(UserController) : base.GetControllerType(requestContext, controllerName);
        }
    }
}