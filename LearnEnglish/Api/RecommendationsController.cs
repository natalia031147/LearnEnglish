using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;

namespace LearnEnglish.Api
{
    public class RecommendationsController : ApiController
    {
        private readonly IRecommendationsLogic _recommendationsLogic;

        public RecommendationsController(IRecommendationsLogic recommendationsLogic)
        {
            _recommendationsLogic = recommendationsLogic;
        }

       
        public Recommendations Get()
        {
            return _recommendationsLogic.Get();
        }
    }
}
