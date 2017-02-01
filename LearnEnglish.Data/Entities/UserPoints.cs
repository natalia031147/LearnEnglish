using System.ComponentModel.DataAnnotations;

namespace LearnEnglish.Data.Entities
{
    public class UserPoints
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public int? ListeningPoints { get; set; }

        public int? WritingPoints { get; set; }

        public int? SpeakingPoints { get; set; }
    }
}