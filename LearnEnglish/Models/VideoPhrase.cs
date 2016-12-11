using System.ComponentModel.DataAnnotations;

namespace LearnEnglish.Models
{
    public class VideoPhrase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Video Video { get; set; }

        [Required]
        public int OrderNumber { get; set; }

        [Required]
        public float StartTime { get; set; }

        [Required]
        public float EndTime { get; set; }

        [MaxLength(255)]
        public string Phrase { get; set; }

        [MaxLength(255), Required]
        public string TranslateLanguage { get; set; }

        [MaxLength(255), Required]
        public string PhraseTranslated { get; set; }
    }
}
