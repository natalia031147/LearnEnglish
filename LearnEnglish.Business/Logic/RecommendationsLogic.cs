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

        public RecommendationsLogic(ApplicationDbContext context, IVideoModelBuilder videoModelBuilder) : base(context)
        {
            _videoModelBuilder = videoModelBuilder;
        }

        public Recommendations Get()
        {
            string userId = GetUser();

            if (userId == null)
            {
                var video = _videoModelBuilder.Build(Context.Videos.OrderBy(o => o.Id).FirstOrDefault()) ;
                return new Recommendations
                {
                    UserLevel = null,
                    ListeningRecommendation = video,
                    WritingRecommendation = video
                };
            }
            var points = Context.UsersPoints.Where(v => v.User.Id == userId)
                .Select(s => new { s.ListeningPoints, s.WritingPoints }).FirstOrDefault();


            Enums.Level listeningLevel = PointsLevel.GetLevel((int)points.ListeningPoints);
            Enums.Level writingLevel = PointsLevel.GetLevel((int)points.WritingPoints);


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

            int arithmeticMean = ((int)points.ListeningPoints + (int)points.WritingPoints) / 2;
            Enums.Level level = PointsLevel.GetLevel(arithmeticMean);

            Recommendations recommendations = new Recommendations
            {
                UserLevel = level,
                ListeningRecommendation = videoForListening,
                WritingRecommendation = videoForWriting
            };



            return recommendations;
        }
    }
}
