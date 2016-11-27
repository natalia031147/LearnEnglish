namespace LearnEnglish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateLanguage : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Languages(Name) VALUES('English') ");
            Sql("INSERT INTO Languages(Name) VALUES('Romanian') ");
            Sql("INSERT INTO Languages(Name) VALUES('Russian') ");
        }
        
        public override void Down()
        {
        }
    }
}
