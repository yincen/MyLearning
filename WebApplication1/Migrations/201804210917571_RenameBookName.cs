namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameBookName : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Books", "Name", "Title");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Books", "Title", "Name");
        }
    }
}
