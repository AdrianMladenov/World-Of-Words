namespace WoW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddedToWordsForValidate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WordForValidates", "dateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WordForValidates", "dateAdded");
        }
    }
}
