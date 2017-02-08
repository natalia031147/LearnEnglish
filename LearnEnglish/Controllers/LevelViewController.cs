using System.Web.Mvc;

namespace LearnEnglish.Controllers
{
    public class LevelViewController : Controller
    {
        // GET: Level
        public ActionResult ChangeLevel()
        {
            return View();
        }
    }
}