namespace LearnEnglish.Business.Models
{
    public class VideoMv
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public bool? ListeningModulePassed { get; set; }
        public bool? WritingModulePassed { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Language { get; set; }
        public string Thumbnail { get; set; }
        public VideoPart[] parts { get; set; }
    }

    public class VideoPart
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string native { get; set; }
        public string source { get; set; }
    }

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
    }
}