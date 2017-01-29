using System.Linq;
using LearnEnglish.Business.Logic.Interfaces;
using LearnEnglish.Business.Models;
using LearnEnglish.Business.Utils;
using LearnEnglish.Data.Entities;
using LearnEnglish.Data.Framework;

namespace LearnEnglish.Business.Logic
{
    class RecommendationsLogic : BaseLogic, IRecommendationsLogic
    {

        public RecommendationsLogic(ApplicationDbContext context) : base(context)
        {
        }

        public Recommendations Get()
        {
            string userId = GetUser();

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
