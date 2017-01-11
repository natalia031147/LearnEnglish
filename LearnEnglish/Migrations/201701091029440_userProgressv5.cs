namespace LearnEnglish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userProgressv5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProgresses", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserProgresses", new[] { "User_Id" });
            AddColumn("dbo.UserProgresses", "UserId", c => c.String(nullable: false));
            DropColumn("dbo.UserProgresses", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProgresses", "User_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UserProgresses", "UserId");
            CreateIndex("dbo.UserProgresses", "User_Id");
            AddForeignKey("dbo.UserProgresses", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
