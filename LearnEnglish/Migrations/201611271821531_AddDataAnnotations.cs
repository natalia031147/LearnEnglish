namespace LearnEnglish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VideoMaterials", "Level_Id", "dbo.Levels");
            DropForeignKey("dbo.VideoMaterials", "VideoLanguage_Id", "dbo.Languages");
            DropIndex("dbo.VideoMaterials", new[] { "Level_Id" });
            DropIndex("dbo.VideoMaterials", new[] { "VideoLanguage_Id" });
            AddColumn("dbo.PhraseTranslates", "VideoMaterial_Id", c => c.Int(nullable: false));
            AddColumn("dbo.VideoMaterials", "VideoSource", c => c.String(nullable: false));
            AddColumn("dbo.VideoPhrases", "VideoMaterial_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Languages", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Levels", "LevelName", c => c.String(nullable: false));
            AlterColumn("dbo.PhraseTranslates", "PhraseTranslated", c => c.String(maxLength: 255));
            AlterColumn("dbo.VideoMaterials", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.VideoMaterials", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.VideoMaterials", "Level_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.VideoMaterials", "VideoLanguage_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.VideoPhrases", "Phrase", c => c.String(maxLength: 255));
            CreateIndex("dbo.PhraseTranslates", "VideoMaterial_Id");
            CreateIndex("dbo.VideoMaterials", "Level_Id");
            CreateIndex("dbo.VideoMaterials", "VideoLanguage_Id");
            CreateIndex("dbo.VideoPhrases", "VideoMaterial_Id");
            AddForeignKey("dbo.PhraseTranslates", "VideoMaterial_Id", "dbo.VideoMaterials", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VideoPhrases", "VideoMaterial_Id", "dbo.VideoMaterials", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VideoMaterials", "Level_Id", "dbo.Levels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VideoMaterials", "VideoLanguage_Id", "dbo.Languages", "Id", cascadeDelete: true);
            DropColumn("dbo.PhraseTranslates", "VideoPhraseId");
            DropColumn("dbo.VideoMaterials", "VideoLink");
            DropColumn("dbo.VideoPhrases", "VideoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VideoPhrases", "VideoId", c => c.Int(nullable: false));
            AddColumn("dbo.VideoMaterials", "VideoLink", c => c.String());
            AddColumn("dbo.PhraseTranslates", "VideoPhraseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.VideoMaterials", "VideoLanguage_Id", "dbo.Languages");
            DropForeignKey("dbo.VideoMaterials", "Level_Id", "dbo.Levels");
            DropForeignKey("dbo.VideoPhrases", "VideoMaterial_Id", "dbo.VideoMaterials");
            DropForeignKey("dbo.PhraseTranslates", "VideoMaterial_Id", "dbo.VideoMaterials");
            DropIndex("dbo.VideoPhrases", new[] { "VideoMaterial_Id" });
            DropIndex("dbo.VideoMaterials", new[] { "VideoLanguage_Id" });
            DropIndex("dbo.VideoMaterials", new[] { "Level_Id" });
            DropIndex("dbo.PhraseTranslates", new[] { "VideoMaterial_Id" });
            AlterColumn("dbo.VideoPhrases", "Phrase", c => c.String());
            AlterColumn("dbo.VideoMaterials", "VideoLanguage_Id", c => c.Int());
            AlterColumn("dbo.VideoMaterials", "Level_Id", c => c.Int());
            AlterColumn("dbo.VideoMaterials", "Image", c => c.String());
            AlterColumn("dbo.VideoMaterials", "Name", c => c.String());
            AlterColumn("dbo.PhraseTranslates", "PhraseTranslated", c => c.String());
            AlterColumn("dbo.Levels", "LevelName", c => c.String());
            AlterColumn("dbo.Languages", "Name", c => c.String());
            DropColumn("dbo.VideoPhrases", "VideoMaterial_Id");
            DropColumn("dbo.VideoMaterials", "VideoSource");
            DropColumn("dbo.PhraseTranslates", "VideoMaterial_Id");
            CreateIndex("dbo.VideoMaterials", "VideoLanguage_Id");
            CreateIndex("dbo.VideoMaterials", "Level_Id");
            AddForeignKey("dbo.VideoMaterials", "VideoLanguage_Id", "dbo.Languages", "Id");
            AddForeignKey("dbo.VideoMaterials", "Level_Id", "dbo.Levels", "Id");
        }
    }
}
