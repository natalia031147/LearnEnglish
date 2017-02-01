namespace LearnEnglish.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userPointsModification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPoints", "SpeakingPoints", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPoints", "SpeakingPoints");
        }
    }
}
