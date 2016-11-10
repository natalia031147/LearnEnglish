using System.Web.Mvc;

namespace LearnEnglish.Controllers
{
    public class VideoLessonsController : Controller
    {
        // GET: Video
        public ActionResult Add()
        {
            return View();
        }
    }
}