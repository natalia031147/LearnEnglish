using System.Web.Mvc;

namespace LearnEnglish.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Add()
        {
            return View();
        }
        public void GetYoutubeInfo(string youtubeurl)
        {

        }
    }
}