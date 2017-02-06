using System.Collections.Generic;
using System.Web.Http;
using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;
using System.Net.Http;

namespace LearnEnglish.Api
{
    public class LevelController : ApiController
    {

        private readonly ILevelLogic _levelLogic;

        public LevelController(ILevelLogic levelLogic)
        {
            _levelLogic = levelLogic;
        }

        public int GetUserLevel()
        {
            return _levelLogic.GetUserLevel();
        }

        [HttpPost]
        public string ChangeUserLevel(int level)
        {
            return _levelLogic.ChangeUserLevel(level);
        }
    }
}