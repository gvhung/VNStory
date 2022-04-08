using System.Web.Mvc;

namespace VNStory.Web.Areas.Membership.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/UserMgmt
        public ActionResult Index()
        {
            return View();
        }

    }
}