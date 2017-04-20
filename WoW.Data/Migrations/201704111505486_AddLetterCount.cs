namespace WoW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLetterCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Words", "LetterCount", c => c.Int());
            AddColumn("dbo.WordForValidates", "LetterCount", c => c.Int());
           
        }
        
        public override void Down()
        {
            DropColumn("dbo.Words", "LetterCount");
            DropColumn("dbo.WordForValidates", "LetterCount");
        }
    }
}
