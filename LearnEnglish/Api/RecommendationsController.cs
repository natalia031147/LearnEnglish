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

       
        public RecommendationsModel Get()
        {
            return _recommendationsLogic.Get();
        }
    }
}
