using LearnEnglish.Business.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnEnglish.Business.Models;
using LearnEnglish.Data.Framework;
using LearnEnglish.Business.Builders.Interfaces;
using LearnEnglish.Business.Utils;

namespace LearnEnglish.Business.Logic
{
    public class UserPointsLogic : BaseLogic, IUserPointsLogic
    {
        private readonly IUserPointsModelBuilder _userPointsBuilder;

        public UserPointsLogic(IUserPointsModelBuilder userPointsBuilder, ApplicationDbContext context) : base(context)
        {
            _userPointsBuilder = userPointsBuilder;
        }

        public UserPointsModel Get()
        {
            var userId = GetUser();

           

            var userPoints = Context.UsersPoints.Where(a => a.User.Id == userId).FirstOrDefault();

            if (userId == null || userPoints == null)
            {
                return new UserPointsModel
                {
                    MaxListeningPoints = PointsLevel.GetMaxLevelPoints(PointsLevel.GetLevel(0)),
                    MaxSpeakingPoints = PointsLevel.GetMaxLevelPoints(PointsLevel.GetLevel(0)),
                    MaxWritingPoints = PointsLevel.GetMaxLevelPoints(PointsLevel.GetLevel(0)),
                    ProgressLevelPercentage = PointsLevel.GetProgress(0),
                    ListeningProgressPercentage = 0,
                    SpeakingProgressPercentage = 0,
                    WritingProgressPercentage = 0
                };
            }

            var avgPoints = (int)((userPoints.WritingPoints + userPoints.SpeakingPoints + userPoints.ListeningPoints) / 3);
            var userLevel = PointsLevel.GetLevel(avgPoints);

            return new UserPointsModel
            {
                MaxListeningPoints = PointsLevel.GetMaxLevelPoints(PointsLevel.GetLevel(userPoints.ListeningPoints ?? 0)),
                MaxSpeakingPoints = PointsLevel.GetMaxLevelPoints(PointsLevel.GetLevel(userPoints.SpeakingPoints ?? 0)),
                MaxWritingPoints = PointsLevel.GetMaxLevelPoints(PointsLevel.GetLevel(userPoints.WritingPoints ?? 0)),
                UserLevel = (int)userLevel,                
                ProgressLevelPercentage = PointsLevel.GetProgress(avgPoints ),
                ListeningProgressPercentage = PointsLevel.GetProgress(userPoints.ListeningPoints ?? 0),
                SpeakingProgressPercentage = PointsLevel.GetProgress(userPoints.SpeakingPoints ?? 0),
                WritingProgressPercentage = PointsLevel.GetProgress(userPoints.WritingPoints ?? 0)                

            };



            //userPoints.ProgressLevelPercentage = (int)((avgPoints / (float)PointsLevel.GetMaxLevelPoints(userLevel)) * 100);
            //userPoints.MaxListeningPoints = PointsLevel.GetMaxLevelPoints(PointsLevel.GetLevel(userPoints.ListeningPoints));
            //userPoints.MaxSpeakingPoints = PointsLevel.GetMaxLevelPoints(PointsLevel.GetLevel(userPoints.SpeakingPoints));
            //userPoints.MaxWritingPoints = PointsLevel.GetMaxLevelPoints(PointsLevel.GetLevel(userPoints.WritingPoints));
            //userPoints.UserLevel = (int)userLevel;
            //return userPoints;
        }
    }
}
