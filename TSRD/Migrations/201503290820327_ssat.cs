namespace TSRD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ssat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Units", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Units", "IDString", c => c.String(nullable: false));
            AlterColumn("dbo.Units", "Floor", c => c.String(nullable: false));
            AlterColumn("dbo.Units", "Area", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Units", "Area", c => c.String());
            AlterColumn("dbo.Units", "Floor", c => c.String());
            AlterColumn("dbo.Units", "IDString", c => c.String());
            AlterColumn("dbo.Units", "Name", c => c.String());
        }
    }
}
