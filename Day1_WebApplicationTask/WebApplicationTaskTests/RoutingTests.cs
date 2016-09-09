using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Machine.Specifications;
using MvcContrib.TestHelper;
using ApplicationExtension;
using WebApplicationTask;

namespace WebApplicationTaskTests
{
    [Subject("Route MVC")]
    public class RoutingTests
    {
        private Establish context = () => 
        {
            var routes = RouteTable.Routes;
            RouteConfig.RegisterRoutes(routes);
        };

        private It shouldRouteToApplicationExtensionHomeInfoWithId = () =>
        {
            "user/myinfo/1".Route().ShouldMapTo<ApplicationExtension.HomeController>(e => e.Info(1));
            "user/myinfo/2".Route().ShouldMapTo<ApplicationExtension.HomeController>(e => e.Info(2));
        };

        private It shouldRouteToHomeInfoWithParam = () =>
        {
            "user/info/alal".Route().ShouldMapTo<WebApplicationTask.Controllers.HomeController>(e => e.Info("alal"));
            "user/info/efefe".Route().ShouldMapTo<WebApplicationTask.Controllers.HomeController>(e => e.Info("efefe"));
        };

        private It shouldRouteToNewsIndexWithParam = () =>
        {
            "news/alalalalal".Route().ShouldMapTo<WebApplicationTask.Controllers.NewsController>(e => e.Index("alalalalal"));
            "news/efefefefefeea".Route().ShouldMapTo<WebApplicationTask.Controllers.NewsController>(e => e.Index("efefefefefeea"));
        };

        private It shouldRouteToHomeAboutWithId = () =>
        {
            "about/get/1".Route().ShouldMapTo<WebApplicationTask.Controllers.HomeController>(e => e.Index(1));
            "about/get/2".Route().ShouldMapTo<WebApplicationTask.Controllers.HomeController>(e => e.Index(2));
            "about/get/13".Route().ShouldMapTo<WebApplicationTask.Controllers.HomeController>(e => e.Index(13));
        };
    }
}
