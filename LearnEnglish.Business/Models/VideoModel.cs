namespace LearnEnglish.Business.Models
{
    public class VideoModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public string Language { get; set; }
        public int Level { get; set; }
        public bool? ListeningModulePassed { get; set; }
        public bool? WritingModulePassed { get; set; }
        public bool? SpeakingModulePassed { get; set; }
    }
}