namespace TSRD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "ID1", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "ID2", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "ID3", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "ID3");
            DropColumn("dbo.Tests", "ID2");
            DropColumn("dbo.Tests", "ID1");
        }
    }
}
