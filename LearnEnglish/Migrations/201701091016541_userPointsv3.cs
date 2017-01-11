namespace LearnEnglish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userPointsv3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserPoints", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserPoints", "UserId", c => c.Int(nullable: false));
        }
    }
}
