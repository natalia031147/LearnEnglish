using System.ComponentModel.DataAnnotations;

namespace LearnEnglish.Data.Entities
{
    public class UserProgress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Video Video { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public bool? ListeningModulePassed { get; set; }

        public bool? WritingModulePassed { get; set; }

        public bool? SpeakingModulePassed { get; set; }
    }
}