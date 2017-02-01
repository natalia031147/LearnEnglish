namespace LearnEnglish.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSpeakingColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProgresses", "SpeakingModulePassed", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProgresses", "SpeakingModulePassed");
        }
    }
}
