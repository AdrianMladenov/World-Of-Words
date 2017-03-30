namespace WoW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRegistrationDateForUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User Info", "RegistrationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User Info", "RegistrationDate");
        }
    }
}
