namespace LearnEnglish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateLevel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Levels(LevelName) VALUES('Elementary') ");
            Sql("INSERT INTO Levels(LevelName) VALUES('Pre-Intermediate') ");
            Sql("INSERT INTO Levels(LevelName) VALUES('Intermediate') ");
            Sql("INSERT INTO Levels(LevelName) VALUES('Upper-Intermediate') ");
            Sql("INSERT INTO Levels(LevelName) VALUES('Advanced') ");
        }
        
        public override void Down()
        {
        }
    }
}
