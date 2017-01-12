using System.Data.Entity;
using LearnEnglish.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LearnEnglish.Data.Framework
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoPhrase> VideoPhrases { get; set; }
        public DbSet<UserProgress> UserProgress { get; set; }
        public DbSet<UserPoints> UsersPoints { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}