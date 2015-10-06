namespace Delightful.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutUserDansBookmark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookmark", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bookmark", "UserId");
            AddForeignKey("dbo.Bookmark", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookmark", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Bookmark", new[] { "UserId" });
            DropColumn("dbo.Bookmark", "UserId");
        }
    }
}
