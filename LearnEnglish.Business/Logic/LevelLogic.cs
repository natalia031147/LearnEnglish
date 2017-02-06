using LearnEnglish.Business.Logic.Interfaces;
using System;
using System.Linq;
using LearnEnglish.Data.Framework;
using LearnEnglish.Data.Entities;
using LearnEnglish.Business.Utils;

namespace LearnEnglish.Business.Logic
{
    class LevelLogic : BaseLogic, ILevelLogic
    {
        public LevelLogic(ApplicationDbContext context) : base(context)
        {
        }

        public string ChangeUserLevel(int level)
        {
            try
            {
                string userId = GetUser();
                if (userId == null)
                {
                    return "";
                }

                var userPoints = Context.UsersPoints.Where(a => a.User.Id == userId).FirstOrDefault();
                var user = Context.Users.Where(a => a.Id == userId).FirstOrDefault();
                if (userPoints == null)
                {
                    var points = level > 1 ? PointsLevel.GetMaxLevelPoints((Enums.Level)(level - 1)) + 1 : 1;
                    Context.UsersPoints.Add(new UserPoints()
                    {
                        User = user,
                        ListeningPoints = points,
                        WritingPoints = points,
                        SpeakingPoints = points
                    });
                    Context.SaveChanges();
                    return "Save the level Successful.";
                }
                else
                {
                    var startPoints = level > 1 ? PointsLevel.GetMaxLevelPoints((Enums.Level)(level - 1)) + 1 : 1;
                    var maxLevelPoints = PointsLevel.GetMaxLevelPoints((Enums.Level)level);

                    userPoints.User = user;
                    userPoints.ListeningPoints = userPoints.ListeningPoints <= maxLevelPoints && userPoints.ListeningPoints >= startPoints ? userPoints.ListeningPoints : startPoints;
                    userPoints.WritingPoints = userPoints.WritingPoints <= maxLevelPoints && userPoints.WritingPoints >= startPoints ? userPoints.WritingPoints : startPoints; ;
                    userPoints.SpeakingPoints = userPoints.SpeakingPoints <= maxLevelPoints && userPoints.SpeakingPoints >= startPoints ? userPoints.SpeakingPoints : startPoints; ;
                    
                    Context.SaveChanges();
                    return "Save the level Successful.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public int GetUserLevel()
        {
            string userId = GetUser();

            var points = Context.UsersPoints.Where(v => v.User.Id == userId)
                .Select(s => new { s.ListeningPoints, s.WritingPoints, s.SpeakingPoints }).FirstOrDefault();

            if (userId == null || points == null)
            {
                return (int)Enums.Level.Elementary;
            }

            int arithmeticMean = ((int)points.ListeningPoints + (int)points.WritingPoints) / 2;
            Enums.Level level = PointsLevel.GetLevel(arithmeticMean);

            return (int)level;
        }
    }
}
