using System.Web.Mvc;
using static VNStory.Web.RouteConfig;

namespace VNStory.Web.Areas.Membership
{
    public class MembershipAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Membership";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               name: "MembershipDefault",
               url: "Membership/{controller}/{action}/{id}",
               defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional },
               //namespaces: new[] { "VNStory.Web.Areas.Membership.Controllers" },
               constraints: new { customConstraint = new UserAgentConstraint("Unknown") }
           );

        }
    }
}