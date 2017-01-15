using LearnEnglish.Data.Entities;

namespace LearnEnglish.Business.Models
{
    public class VideoPhraseModel
    {
        public Video Video { get; set; }
        public int OrderNumber { get; set; }
        public float StartTime { get; set; }
        public float EndTime { get; set; }
        public string Phrase { get; set; }
        public string TranslateLanguage { get; set; }
        public bool? TranslatedByGoogle { get; set; }
        public string PhraseTranslated { get; set; }
    }
}