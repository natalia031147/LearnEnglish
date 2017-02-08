using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;
using System.Web.Http;

namespace LearnEnglish.Api
{
    public class UserPointsController : ApiController
    {
        private readonly IUserPointsLogic _userPointsLogic;

        public UserPointsController(IUserPointsLogic userPointsLogic)
        {
            _userPointsLogic = userPointsLogic;
        }


        public UserPointsModel Get()
        {
            return _userPointsLogic.Get();
        }
    }
}
