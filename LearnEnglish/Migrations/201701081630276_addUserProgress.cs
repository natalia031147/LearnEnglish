namespace LearnEnglish.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public partial class addUserProgress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProgresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListeningModulePassed = c.Boolean(),
                        WritingModulePassed = c.Boolean(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Video_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.Video_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Video_Id);

           



        }

        public override void Down()
        {
            DropForeignKey("dbo.UserProgresses", "Video_Id", "dbo.Videos");
            DropForeignKey("dbo.UserProgresses", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserProgresses", new[] { "Video_Id" });
            DropIndex("dbo.UserProgresses", new[] { "User_Id" });
            DropTable("dbo.UserProgresses");
        }
    }
}
