namespace LearnEnglish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletePhraseTranslate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhraseTranslates", "Video_Id", "dbo.Videos");
            DropIndex("dbo.PhraseTranslates", new[] { "Video_Id" });
            AddColumn("dbo.VideoPhrases", "TranslateLanguage", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.VideoPhrases", "PhraseTranslated", c => c.String(nullable: false, maxLength: 255));
            DropTable("dbo.PhraseTranslates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PhraseTranslates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TranslateLanguage = c.String(maxLength: 255),
                        PhraseTranslated = c.String(maxLength: 255),
                        Video_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.VideoPhrases", "PhraseTranslated");
            DropColumn("dbo.VideoPhrases", "TranslateLanguage");
            CreateIndex("dbo.PhraseTranslates", "Video_Id");
            AddForeignKey("dbo.PhraseTranslates", "Video_Id", "dbo.Videos", "Id", cascadeDelete: true);
        }
    }
}
