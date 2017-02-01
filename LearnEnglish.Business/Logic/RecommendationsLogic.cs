using LearnEnglish.Business.Builders.Interfaces;
using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;
using LearnEnglish.Business.Utils;
using LearnEnglish.Data.Entities;
using LearnEnglish.Data.Framework;
using System.Linq;

namespace LearnEnglish.Business.Logic
{
    class RecommendationsLogic : BaseLogic, IRecommendationsLogic
    {
        private IVideoModelBuilder _videoModelBuilder;

        public RecommendationsLogic(IVideoModelBuilder videoModelBuilder, ApplicationDbContext context) : base(context)
        {
            _videoModelBuilder = videoModelBuilder;
        }

        public RecommendationsModel Get()
        {
            string userId = GetUser();

            
            var points = Context.UsersPoints.Where(v => v.User.Id == userId)
                .Select(s => new { s.ListeningPoints, s.WritingPoints, s.SpeakingPoints }).FirstOrDefault();

            if (userId == null || points == null)
            {
                var video = _videoModelBuilder.Build(Context.Videos.OrderBy(o => o.Level).ThenBy(o => o.Id).FirstOrDefault());
                return new RecommendationsModel
                {
                    ListeningRecommendation = video,
                    WritingRecommendation = video,
                    SpeakingRecommendation = video
                };
            }

            Enums.Level listeningLevel = PointsLevel.GetLevel((int)points.ListeningPoints);
            Enums.Level writingLevel = PointsLevel.GetLevel((int)points.WritingPoints);
            Enums.Level speakingLevel = PointsLevel.GetLevel((int)points.SpeakingPoints);


            var videoForListening = (from a in Context.Videos.Where(l => l.Level >= (int)listeningLevel)
                                     join b in Context.UserProgress
                                        .Where(w => w.User.Id == userId)
                                        on a equals b.Video into joined
                                     from j in joined.DefaultIfEmpty().Where(v => v.ListeningModulePassed != true || v.ListeningModulePassed == null)
                                     select new VideoModel
                                     {
                                         Id = a.Id,
                                         Language = a.Language,
                                         Level = a.Level,
                                         Thumbnail = a.Thumbnail,
                                         Title = a.Title,
                                         Url = a.Url,
                                         ListeningModulePassed = j.ListeningModulePassed,
                                         WritingModulePassed = j.WritingModulePassed
                                     }).OrderBy(o => o.Level).ThenByDescending(o => o.WritingModulePassed).ThenBy(o => o.Id).FirstOrDefault();

            var videoForWriting = (from a in Context.Videos.Where(l => l.Level >= (int)writingLevel)
                                   join b in Context.UserProgress
                                      .Where(w => w.User.Id == userId)
                                      on a equals b.Video into joined
                                   from j in joined.DefaultIfEmpty().Where(v => v.WritingModulePassed != true || v.WritingModulePassed == null)
                                   select new VideoModel
                                   {
                                       Id = a.Id,
                                       Language = a.Language,
                                       Level = a.Level,
                                       Thumbnail = a.Thumbnail,
                                       Title = a.Title,
                                       Url = a.Url,
                                       ListeningModulePassed = j.ListeningModulePassed,
                                       WritingModulePassed = j.WritingModulePassed
                                   }).OrderBy(o => o.Level).ThenByDescending(o => o.ListeningModulePassed).ThenBy(o => o.Id).FirstOrDefault();


            var videoForSpeaking = (from a in Context.Videos.Where(l => l.Level >= (int)speakingLevel)
                                   join b in Context.UserProgress
                                      .Where(w => w.User.Id == userId)
                                      on a equals b.Video into joined
                                   from j in joined.DefaultIfEmpty().Where(v => v.SpeakingModulePassed != true || v.SpeakingModulePassed == null)
                                   select new VideoModel
                                   {
                                       Id = a.Id,
                                       Language = a.Language,
                                       Level = a.Level,
                                       Thumbnail = a.Thumbnail,
                                       Title = a.Title,
                                       Url = a.Url,
                                       ListeningModulePassed = j.ListeningModulePassed,
                                       WritingModulePassed = j.WritingModulePassed
                                   }).OrderBy(o => o.Level).ThenByDescending(o => o.ListeningModulePassed).ThenByDescending(o => o.WritingModulePassed).ThenBy(o => o.Id).FirstOrDefault();

            int arithmeticMean = ((int)points.ListeningPoints + (int)points.WritingPoints) / 2;
            Enums.Level level = PointsLevel.GetLevel(arithmeticMean);

            RecommendationsModel recommendations = new RecommendationsModel
            {
                ListeningRecommendation = videoForListening,
                WritingRecommendation = videoForWriting,
                SpeakingRecommendation = videoForSpeaking
            };



            return recommendations;
        }
    }
}
