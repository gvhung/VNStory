using System.Web.Mvc;
using static VNStory.Web.RouteConfig;

namespace VNStory.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //context.MapRoute(
            //    "AdminDefault",
            //    "Admin/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);

            context.MapRoute(
               name: "AdminDefault",
               url: "Admin/{controller}/{action}/{id}",
               defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional },
               //namespaces: new[] { "VNStory.Web.Areas.Admin.Controllers" },
               constraints: new { customConstraint = new UserAgentConstraint("Unknown") }
           );

        }
    }
}