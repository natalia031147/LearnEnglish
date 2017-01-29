using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using LearnEnglish.Data.Entities;

namespace LearnEnglish.Business.Utils
{
    public class PointsLevel
    {
        public static Enums.Level GetLevel(int points)
        {
            Enums.Level level;
            if (points <= 500)
            {
                level = Enums.Level.Elementary;
            }
            else if (points <= 1000)
            {
                level = Enums.Level.PreIntermediate;
            }
            else if (points <= 1700)
            {
                level = Enums.Level.Intermediate;
            }
            else if (points <= 2400)
            {
                level = Enums.Level.PreIntermediate;
            }
            else
            {
                level = Enums.Level.Advanced;
            }
            return level;
        }
    }
}
