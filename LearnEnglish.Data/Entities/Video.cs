using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearnEnglish.Data.Entities
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
}