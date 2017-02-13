using System.Collections.Generic;
using LearnEnglish.Business.Models;

namespace LearnEnglish.Business.Logic.Interfaces
{
    public interface IVideoPhraseLogic
    {
        ICollection<VideoPhraseModel> GetAll(int videoId);
        string PassModule(VideoModel video);
    }
}