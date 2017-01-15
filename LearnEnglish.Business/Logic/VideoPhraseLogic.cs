using System.Collections.Generic;
using System.Linq;
using LearnEnglish.Business.Builders.Interfaces;
using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;
using LearnEnglish.Data.Framework;

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

            return models;
        }
    }
}