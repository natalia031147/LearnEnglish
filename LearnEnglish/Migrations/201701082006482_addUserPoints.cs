namespace LearnEnglish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserPoints : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListeningPoints = c.Int(),
                        WritingPoints = c.Int(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPoints", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserPoints", new[] { "User_Id" });
            DropTable("dbo.UserPoints");
        }
    }
}
