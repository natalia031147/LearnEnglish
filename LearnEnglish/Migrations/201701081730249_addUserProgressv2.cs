namespace LearnEnglish.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public partial class addUserProgressv2 : DbMigration
    {
        public override void Up()
        {
            List<UserProgress> _userProgress = new List<UserProgress>();
            using (var _context = new ApplicationDbContext())
            {
              
                _userProgress.Add(new UserProgress() { Id = 1, Video = _context.Videos.Where(v => v.Id == 1).FirstOrDefault(), ListeningModulePassed = false, WritingModulePassed = true, User = _context.Users.Where(v => v.Email == "natalia@a.com").FirstOrDefault() });
                _userProgress.Add(new UserProgress() { Id = 2, Video = _context.Videos.Where(v => v.Id == 2).FirstOrDefault(), ListeningModulePassed = true, WritingModulePassed = true, User = _context.Users.Where(v => v.Email == "natalia@a.com").FirstOrDefault() });
                _userProgress.Add(new UserProgress() { Id = 3, Video = _context.Videos.Where(v => v.Id == 3).FirstOrDefault(), ListeningModulePassed = false, WritingModulePassed = true, User = _context.Users.Where(v => v.Email == "natalia@a.com").FirstOrDefault() });
                _userProgress.Add(new UserProgress() { Id = 4, Video = _context.Videos.Where(v => v.Id == 7).FirstOrDefault(), ListeningModulePassed = true, WritingModulePassed = true, User = _context.Users.Where(v => v.Email == "natalia@a.com").FirstOrDefault() });
                _context.UserProgress.AddRange(_userProgress);
                _context.SaveChanges();
            }

        }

        public override void Down()
        {
        }
    }
}
