using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.Business.Models
{
    public class UserPointsModel
    {
        public int ListeningProgressPercentage { get; set; }
        public int MaxListeningPoints { get; set; }
        public int WritingProgressPercentage { get; set; }
        public int MaxWritingPoints { get; set; }
        public int SpeakingProgressPercentage { get; set; }
        public int MaxSpeakingPoints { get; set; }
        public int UserLevel { get; set; }
        public int ProgressLevelPercentage { get; set; }
    }
}
