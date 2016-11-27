﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class VideoMaterial
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string VideoSource { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public Language VideoLanguage { get; set; }
        [Required]
        public Level Level { get; set; }
    }
}
