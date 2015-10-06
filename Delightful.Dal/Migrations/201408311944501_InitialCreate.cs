namespace Delightful.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookmark",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Url = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Keyword",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                        BookmarkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookmark", t => t.BookmarkId, cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Keyword", "BookmarkId", "dbo.Bookmark");
            DropTable("dbo.Keyword");
            DropTable("dbo.Bookmark");
        }
    }
}
