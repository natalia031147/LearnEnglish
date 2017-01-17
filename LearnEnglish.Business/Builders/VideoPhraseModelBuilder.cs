using LearnEnglish.Business.Builders.Interfaces;
using LearnEnglish.Business.Models;
using LearnEnglish.Data.Entities;

namespace LearnEnglish.Business.Builders
{
    public class VideoPhraseModelBuilder : IVideoPhraseModelBuilder
    {
        public VideoPhraseModel Build(VideoPhrase videoPhrase)
        {
            return new VideoPhraseModel
            {
                Video = videoPhrase.Video,
                StartTime = videoPhrase.StartTime,
                EndTime = videoPhrase.EndTime,
                OrderNumber = videoPhrase.OrderNumber,
                Phrase = videoPhrase.Phrase,
                PhraseTranslated = videoPhrase.PhraseTranslated,
                TranslateLanguage = videoPhrase.TranslateLanguage
            };
        }
    }
}