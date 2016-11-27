using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class PhraseTranslate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public VideoMaterial VideoMaterial { get; set; }
        [MaxLength(255)]
        public Language TranslateLanguage { get; set; }
        [MaxLength(255)]
        public string PhraseTranslated { get; set; }

    }
}
