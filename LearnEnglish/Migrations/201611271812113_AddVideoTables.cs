namespace LearnEnglish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideoTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LevelName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhraseTranslates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VideoPhraseId = c.Int(nullable: false),
                        PhraseTranslated = c.String(),
                        TranslateLanguage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.TranslateLanguage_Id)
                .Index(t => t.TranslateLanguage_Id);
            
            CreateTable(
                "dbo.VideoMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        VideoLink = c.String(),
                        Image = c.String(),
                        Level_Id = c.Int(),
                        VideoLanguage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Levels", t => t.Level_Id)
                .ForeignKey("dbo.Languages", t => t.VideoLanguage_Id)
                .Index(t => t.Level_Id)
                .Index(t => t.VideoLanguage_Id);
            
            CreateTable(
                "dbo.VideoPhrases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VideoId = c.Int(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        StartTime = c.Single(nullable: false),
                        EndTime = c.Single(nullable: false),
                        Phrase = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoMaterials", "VideoLanguage_Id", "dbo.Languages");
            DropForeignKey("dbo.VideoMaterials", "Level_Id", "dbo.Levels");
            DropForeignKey("dbo.PhraseTranslates", "TranslateLanguage_Id", "dbo.Languages");
            DropIndex("dbo.VideoMaterials", new[] { "VideoLanguage_Id" });
            DropIndex("dbo.VideoMaterials", new[] { "Level_Id" });
            DropIndex("dbo.PhraseTranslates", new[] { "TranslateLanguage_Id" });
            DropTable("dbo.VideoPhrases");
            DropTable("dbo.VideoMaterials");
            DropTable("dbo.PhraseTranslates");
            DropTable("dbo.Levels");
            DropTable("dbo.Languages");
        }
    }
}
