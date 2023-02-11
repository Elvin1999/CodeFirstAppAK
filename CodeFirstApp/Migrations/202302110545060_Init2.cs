namespace CodeFirstApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Categories");
            DropColumn("dbo.Categories", "Id");
            AddColumn("dbo.Categories", "MyId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 30));
            AddPrimaryKey("dbo.Categories", "MyId");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "MyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Books", "Name", c => c.String());
            DropColumn("dbo.Categories", "MyId");
            AddPrimaryKey("dbo.Categories", "Id");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
