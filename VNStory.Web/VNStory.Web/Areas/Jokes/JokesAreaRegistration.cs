using System.Web.Mvc;
using static VNStory.Web.RouteConfig;

namespace VNStory.Web.Areas.Jokes
{
    public class JokesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Jokes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               name: "JokesDefault",
               url: "Jokes/{controller}/{action}/{id}",
               defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional },
               //namespaces: new[] { "VNStory.Web.Areas.Jokes.Controllers" },
               constraints: new { customConstraint = new UserAgentConstraint("Unknown") }
           );
        }
    }
}