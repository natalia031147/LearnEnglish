using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LearnEnglish.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoPhrase> VideoPhrases { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
       
    }

}