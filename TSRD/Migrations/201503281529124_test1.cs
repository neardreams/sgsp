namespace TSRD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkForms", "WorkFormType", c => c.Int(nullable: false));
            DropColumn("dbo.WorkForms", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkForms", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.WorkForms", "WorkFormType");
        }
    }
}
