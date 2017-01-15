using System.Collections.Generic;
using LearnEnglish.Business.Models;
using LearnEnglish.Data.Entities;

namespace LearnEnglish.Business.Logic.Interfaces
{
    public interface IVideoPhraseLogic
    {
        ICollection<VideoPhraseModel> GetAll(int videoId);
    }
}