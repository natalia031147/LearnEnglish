using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
