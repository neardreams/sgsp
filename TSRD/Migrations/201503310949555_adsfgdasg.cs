namespace TSRD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adsfgdasg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkFormConsumables", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkFormConsumables", "Amount");
        }
    }
}
