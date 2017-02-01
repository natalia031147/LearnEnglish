using LearnEnglish.Data.Entities;

namespace LearnEnglish.Business.Models
{
    public class RecommendationsModel
    {
        public VideoModel ListeningRecommendation { get; set; }
        public VideoModel WritingRecommendation { get; set; }
        public VideoModel SpeakingRecommendation { get; set; }
    }
}