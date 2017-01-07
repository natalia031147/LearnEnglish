using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearnEnglish.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Thumbnail { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int Level { get; set; }
    }

    public class VideoMv
    {
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

    public class VideoWithActions
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
