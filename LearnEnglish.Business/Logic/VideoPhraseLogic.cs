using LearnEnglish.Business.Builders.Interfaces;
using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;
using LearnEnglish.Data.Framework;
using System.Collections.Generic;
using System.Linq;
using LearnEnglish.Business.Utils;
using System;
using LearnEnglish.Data.Entities;

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
                    model.PhraseTranslated = GoogleTranslate.TranslateText(model.Phrase, "en", "ro");
                }
            }


            return models;
        }
        public string PassModule(VideoModel video)
        {
            try
            {
                var userId = GetUser();

                var userProgress = Context.UserProgress.Where(v => v.Video.Id == video.Id && v.User.Id == userId).FirstOrDefault();


                if (userProgress == null)
                {
                    Context.UserProgress.Add(new UserProgress()
                    {
                        User = Context.Users.Where(v => v.Id == userId).FirstOrDefault(),
                        Video = Context.Videos.Where(v => v.Id == video.Id).FirstOrDefault(),
                        ListeningModulePassed = video.ListeningModulePassed,
                        WritingModulePassed = video.WritingModulePassed,
                        SpeakingModulePassed = video.SpeakingModulePassed
                    });
                    Context.SaveChanges();

                }
                else
                { 
                    userProgress.ListeningModulePassed = video.ListeningModulePassed;
                    userProgress.WritingModulePassed = video.WritingModulePassed;
                    userProgress.SpeakingModulePassed = video.SpeakingModulePassed;
                    userProgress.Video = Context.Videos.Where(v => v.Id == video.Id).FirstOrDefault();
                    userProgress.User = Context.Users.Where(v => v.Id == userId).FirstOrDefault();
                    Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Save the level Successful.";
        }
    }
}