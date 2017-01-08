namespace LearnEnglish.Migrations
{
    using Controllers;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public partial class addData : DbMigration
    {
        public override void Up()
        {

         List<Video> _videos = new List<Video>();
            _videos.Add(new Models.Video() { Id = 1, Language = "en", Level = (int)Common.Enums.Level.PreIntermediate, Thumbnail = "https://i.ytimg.com/vi/4Y8WR5VrN9E/mqdefault.jpg", Title = "dady is the sweetest daddy in the world", Url = "https://www.youtube.com/watch?v=4Y8WR5VrN9E" });
            _videos.Add(new Models.Video() { Id = 2, Language = "en", Level = (int)Common.Enums.Level.Intermediate, Thumbnail = "https://i.ytimg.com/vi/y5-vt3f8JM4/mqdefault.jpg", Title = "The Proposal - Film Clip", Url = "https://www.youtube.com/watch?v=y5-vt3f8JM4" });
            _videos.Add(new Models.Video() { Id = 3, Language = "en", Level = (int)Common.Enums.Level.PreIntermediate, Thumbnail = "https://i.ytimg.com/vi/zgnHF2CwrPs/mqdefault.jpg", Title = "Hercules I can Go The Distance", Url = "https://www.youtube.com/watch?v=zgnHF2CwrPs" });
            _videos.Add(new Models.Video() { Id = 4, Language = "en", Level = (int)Common.Enums.Level.PreIntermediate, Thumbnail = "https://i.ytimg.com/vi/1EZQ3rqO-_I/mqdefault.jpg", Title = "Game of Thrones 6x10 Martels and Lord Varys", Url = "https://www.youtube.com/watch?v=1EZQ3rqO-_I" });
            _videos.Add(new Models.Video() { Id = 5, Language = "en", Level = (int)Common.Enums.Level.UpperIntermediate, Thumbnail = "https://i.ytimg.com/vi/re5veV2F7eY/mqdefault.jpg", Title = "Mean Girls (1/10) Movie CLIP - Meeting the Plastics (2004)", Url = "https://www.youtube.com/watch?v=re5veV2F7eY" });
            _videos.Add(new Models.Video() { Id = 6, Language = "en", Level = (int)Common.Enums.Level.UpperIntermediate, Thumbnail = "https://i.ytimg.com/vi/wc93gQRRKbA/mqdefault.jpg", Title = "Tyrion's Trial in the Vale", Url = "https://www.youtube.com/watch?v=wc93gQRRKbA" });
            _videos.Add(new Models.Video() { Id = 7, Language = "en", Level = (int)Common.Enums.Level.Elementary, Thumbnail = "https://i.ytimg.com/vi/DQYNM6SjD_o/mqdefault.jpg", Title = "Miranda Lambert - The House That Built Me", Url = "https://www.youtube.com/watch?v=DQYNM6SjD_o" });
            _videos.Add(new Models.Video() { Id = 8, Language = "en", Level = (int)Common.Enums.Level.Intermediate, Thumbnail = "https://i.ytimg.com/vi/HSzx-zryEgM/mqdefault.jpg", Title = "Doctor Strange Official Trailer 2", Url = "https://www.youtube.com/watch?v=HSzx-zryEgM" });
            _videos.Add(new Models.Video() { Id = 9, Language = "en", Level = (int)Common.Enums.Level.Advanced, Thumbnail = "https://i.ytimg.com/vi/-bN_xU5kbSs/mqdefault.jpg", Title = "Guardians of the Galaxy Movie CLIP - Prison Break (2014) - Bradley Cooper Movie", Url = "https://www.youtube.com/watch?v=-bN_xU5kbSs" });



        ApplicationDbContext db = new ApplicationDbContext();
            db.Videos.AddRange(_videos);
            db.SaveChanges();
        }
        
        public override void Down()
        {
        }
    }
}
