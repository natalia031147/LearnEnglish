using LearnEnglish.Models;
using Microsoft.AspNet.Identity;

namespace LearnEnglish.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LearnEnglish.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LearnEnglish.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("admin123");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "admin@a.com",
                    PasswordHash = password,
                    PhoneNumber = "0011223366",
                    SecurityStamp = Guid.NewGuid().ToString()
                });
            base.Seed(context);

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
