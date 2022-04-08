using System.Web.Mvc;

namespace VNStory.Web.Areas.Jokes.Controllers
{
    public class DashboardController : Controller
    {
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