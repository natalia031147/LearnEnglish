using System.Collections.Generic;
using LearnEnglish.Business.Models;

namespace LearnEnglish.Business.Logic.Interfaces
{
    public interface IRecommendationsLogic
    {
        RecommendationsModel Get();
    }
}