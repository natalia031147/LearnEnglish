﻿using System.ComponentModel.DataAnnotations;

namespace LearnEnglish.Models
{
    public class UserProgress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Video Video { get; set; }

        [Required]
        public string UserId { get; set; }
       
        public bool? ListeningModulePassed { get; set; }

        public bool? WritingModulePassed { get; set; }
    }
}