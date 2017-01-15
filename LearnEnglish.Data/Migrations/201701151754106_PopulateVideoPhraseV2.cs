using LearnEnglish.Data.Framework;
using LearnEnglish.Data.Migrations.Seed;

namespace LearnEnglish.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateVideoPhraseV2 : DbMigration
    {
        public override void Up()
        {
            var videos = new VideoDataProvider().Create();
            var context = new ApplicationDbContext();
            var videosPhrases = new VideoPhraseProvider().Create( videos);
            context.VideoPhrases.AddRange(videosPhrases);
            context.SaveChanges();
        }
        
        public override void Down()
        {

        }
    }
}
