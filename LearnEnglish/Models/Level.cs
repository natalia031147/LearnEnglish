using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnEnglish.Models
{
    public class Level
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LevelName { get; set; }
    }
}