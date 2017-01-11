namespace LearnEnglish.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    public partial class addUserPointv2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserPoints", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserPoints", new[] { "User_Id" });
            AddColumn("dbo.UserPoints", "UserId", c => c.String(nullable: false));
            DropColumn("dbo.UserPoints", "User_Id");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserPoints", "User_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UserPoints", "UserId");
            CreateIndex("dbo.UserPoints", "User_Id");
            AddForeignKey("dbo.UserPoints", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
