namespace TSRD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ena : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Units", "Enabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Units", "Enabled", c => c.Boolean());
        }
    }
}
