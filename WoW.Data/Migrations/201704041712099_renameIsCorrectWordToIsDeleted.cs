namespace WoW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameIsCorrectWordToIsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WordForValidates", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.WordForValidates", "IsCorrectWord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WordForValidates", "IsCorrectWord", c => c.Boolean(nullable: false));
            DropColumn("dbo.WordForValidates", "IsDeleted");
        }
    }
}
