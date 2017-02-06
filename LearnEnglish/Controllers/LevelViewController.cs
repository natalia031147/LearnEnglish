using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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