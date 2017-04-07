namespace WoW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateOfCreationAndICollUsersToWords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersWords",
                c => new
                    {
                        WordId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.WordId, t.UserId })
                .ForeignKey("dbo.Words", t => t.WordId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.WordId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Answer", "DateOfCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Questions", "DateOfCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Words", "DateOfCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.WordForValidates", "DateOfCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.WordForValidates", "LastModifed", c => c.DateTime(nullable: false));
            DropColumn("dbo.Words", "DateAdded");
            DropColumn("dbo.WordForValidates", "dateAdded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WordForValidates", "dateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Words", "DateAdded", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.UsersWords", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersWords", "WordId", "dbo.Words");
            DropIndex("dbo.UsersWords", new[] { "UserId" });
            DropIndex("dbo.UsersWords", new[] { "WordId" });
            DropColumn("dbo.WordForValidates", "LastModifed");
            DropColumn("dbo.WordForValidates", "DateOfCreation");
            DropColumn("dbo.Words", "DateOfCreation");
            DropColumn("dbo.Questions", "DateOfCreation");
            DropColumn("dbo.Answer", "DateOfCreation");
            DropTable("dbo.UsersWords");
        }
    }
}
