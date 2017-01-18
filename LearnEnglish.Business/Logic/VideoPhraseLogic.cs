using LearnEnglish.Business.Builders.Interfaces;
using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;
using LearnEnglish.Data.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LearnEnglish.Business.Logic
{
    public class VideoPhraseLogic : BaseLogic, IVideoPhraseLogic
    {
        private readonly IVideoPhraseModelBuilder _videoPhraseModelBuilder;

        public VideoPhraseLogic(IVideoPhraseModelBuilder videoPhraseModelBuilder, ApplicationDbContext context) 
            : base(context)
        {
            _videoPhraseModelBuilder = videoPhraseModelBuilder;
        }

        public ICollection<VideoPhraseModel> GetAll(int videoId)
        {
            var phrases =
                Context.VideoPhrases.Where(p => p.Video == Context.Videos.FirstOrDefault(v => v.Id == videoId))
                    .ToList();

            var models = phrases.Select(_videoPhraseModelBuilder.Build).ToList();
            

            foreach (var model in models)
            {
                if (string.IsNullOrEmpty(model.PhraseTranslated) && !string.IsNullOrEmpty(model.Phrase))
                {
                    model.TranslatedByGoogle = true;
                    model.PhraseTranslated = GoogleTranslateLogic.TranslateText(model.Phrase, "en", "ro");
                }
            }


            return models;
        }
    }
}