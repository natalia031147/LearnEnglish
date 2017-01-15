using System.Web.Mvc;

namespace LearnEnglish.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return View("~/Views/VideoView/BrowseVideos.cshtml");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}