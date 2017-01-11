using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LearnEnglish.Common.Enums;

namespace LearnEnglish.Models
{
    public class Recommendations
    {
        public Video ListeningRecommendation { get; set; }
        public Video WritingRecommendation { get; set; }
        public Level UserLevel { get; set; }
    }
}