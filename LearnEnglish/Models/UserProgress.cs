using System.ComponentModel.DataAnnotations;

namespace LearnEnglish.Models
{
    public class UserProgress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Video Video { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public bool? ListeningModulePassed { get; set; }

        [Required]
        public bool? WritingModulePassed { get; set; }
    }
}