namespace LearnEnglish.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    public partial class userPointsv4 : DbMigration
    {
        public override void Up()
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            //string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            UserPoints userPoint = new UserPoints() { Id = 1, ListeningPoints = 600, WritingPoints = 1000, UserId = "263598d4-a23e-408b-84c5-867d2b317c59" };
            _context.UsersPoints.Add(userPoint);
            _context.SaveChanges();
        }

        public override void Down()
        {
        }
    }
}
