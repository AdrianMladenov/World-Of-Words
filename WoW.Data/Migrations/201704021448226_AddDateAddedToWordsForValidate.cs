namespace WoW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddedToWordsForValidate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WordForValidates", "dateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WordForValidates", "dateAdded", c => c.DateTime(nullable: false));
        }
    }
}
