namespace WoW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserFromWord : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Words", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Words", new[] { "User_Id" });
            DropColumn("dbo.Words", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Words", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Words", "User_Id");
            AddForeignKey("dbo.Words", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
