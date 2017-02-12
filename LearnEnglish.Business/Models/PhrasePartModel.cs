using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.Business.Models
{
    public class PhrasePartModel
    {
        public int OrderNumber { get; set; }
        public float StartTime { get; set; }
        public float EndTime { get; set; }
        public string Phrase { get; set; }
        public string PhraseTranslated { get; set; }
    }
}
