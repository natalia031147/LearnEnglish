using LearnEnglish.Data.Entities;

namespace LearnEnglish.Business.Models
{
    public class Recommendations
    {
        public Video ListeningRecommendation { get; set; }
        public Video WritingRecommendation { get; set; }
        public Enums.Level UserLevel { get; set; }
    }
}