namespace TSRD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkForms", "AcceptedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkForms", "ClosedTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.WorkForms", "Accepted_time");
            DropColumn("dbo.WorkForms", "Closed_time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkForms", "Closed_time", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkForms", "Accepted_time", c => c.DateTime(nullable: false));
            DropColumn("dbo.WorkForms", "ClosedTime");
            DropColumn("dbo.WorkForms", "AcceptedTime");
        }
    }
}
