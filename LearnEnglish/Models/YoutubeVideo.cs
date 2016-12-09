using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnEnglish.Models
{
    public class YoutubeVideo
    {
        public string VideoID { get; set; }
        public string Title { get; set; }
        public string VideoLink { get; set; }
        public string Thumbnailurl { get; set; }
        public string Code { get; set; }
        public int Duration { get; set; }
    }
}