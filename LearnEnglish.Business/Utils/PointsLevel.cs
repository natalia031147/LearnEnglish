using LearnEnglish.Data.Entities;

namespace LearnEnglish.Business.Utils
{
    public class PointsLevel
    {
        enum MaxLevelPoint { Elementary  = 500, PreIntermediate  = 1000, Intermediate  = 1700, UpperIntermediate = 2400, Advanced = 4000, Undefined = -1};
        
        public static Enums.Level GetLevel(int points)
        {
            Enums.Level level;
            if (points <= (int)MaxLevelPoint.Elementary)
            {
                level = Enums.Level.Elementary;
            }
            else if (points <= (int)MaxLevelPoint.PreIntermediate)
            {
                level = Enums.Level.PreIntermediate;
            }
            else if (points <= (int)MaxLevelPoint.Intermediate)
            {
                level = Enums.Level.Intermediate;
            }
            else if (points <= (int)MaxLevelPoint.UpperIntermediate)
            {
                level = Enums.Level.UpperIntermediate;
            }
            else
            {
                level = Enums.Level.Advanced;
            }
            return level;
        }

        public static int GetMaxLevelPoints(Enums.Level level)
        {
            MaxLevelPoint points;
            if (level == Enums.Level.Advanced)
            {
                points = MaxLevelPoint.Advanced;
            }
            else if (level == Enums.Level.UpperIntermediate)
            {
                points = MaxLevelPoint.UpperIntermediate;
            }
            else if (level == Enums.Level.Intermediate)
            {
                points = MaxLevelPoint.Intermediate;
            }
            else if (level == Enums.Level.PreIntermediate)
            {
                points = MaxLevelPoint.PreIntermediate;
            }
            else if (level == Enums.Level.Elementary)
            {
                points = MaxLevelPoint.Elementary;
            }
            else
            {
                points = MaxLevelPoint.Undefined;
            }
            return (int)points;


        }

        public static int GetProgress(int point)
        {
            var level = PointsLevel.GetLevel(point);
            float progress;
            if (level == Enums.Level.Elementary)
            {
                progress = (point / (float)PointsLevel.GetMaxLevelPoints(level)) * 100;
            }
            else
            {
                var previusLevelMaxPoint = (float)PointsLevel.GetMaxLevelPoints((Enums.Level)((int)level - 1));
                progress = ((point - previusLevelMaxPoint) / ((float)PointsLevel.GetMaxLevelPoints(level) - previusLevelMaxPoint)) * 100;
            }
            return (int)progress;
        }
    }
}
