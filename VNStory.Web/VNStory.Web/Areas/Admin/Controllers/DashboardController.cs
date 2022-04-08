using System.Web.Mvc;

namespace VNStory.Web.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/UserMgmt
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApproveUsers()
        {
            return View();
        }
    }
}