using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnEnglish.Models
{
    public class UserPoints
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public int? ListeningPoints { get; set; }

        public int? WritingPoints { get; set; }
    }
}