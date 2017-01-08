namespace LearnEnglish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeVideoPhrases : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VideoPhrases", "TranslateLanguage", c => c.String(maxLength: 255));
            AlterColumn("dbo.VideoPhrases", "PhraseTranslated", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VideoPhrases", "PhraseTranslated", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.VideoPhrases", "TranslateLanguage", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
