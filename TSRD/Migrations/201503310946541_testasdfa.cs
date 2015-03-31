namespace TSRD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testasdfa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkFormProperties", "WorkForm_ID", "dbo.WorkForms");
            DropForeignKey("dbo.WorkFormProperties", "Property_ID", "dbo.Properties");
            DropIndex("dbo.WorkFormProperties", new[] { "WorkForm_ID" });
            DropIndex("dbo.WorkFormProperties", new[] { "Property_ID" });
            CreateTable(
                "dbo.WorkFormProperties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WorkFormID = c.Int(nullable: false),
                        PropertyID = c.Int(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Properties", t => t.PropertyID, cascadeDelete: true)
                .ForeignKey("dbo.WorkForms", t => t.WorkFormID, cascadeDelete: true)
                .Index(t => t.WorkFormID)
                .Index(t => t.PropertyID);
            
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkFormProperties",
                c => new
                    {
                        WorkForm_ID = c.Int(nullable: false),
                        Property_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkForm_ID, t.Property_ID });
            
            DropForeignKey("dbo.WorkFormProperties", "WorkFormID", "dbo.WorkForms");
            DropForeignKey("dbo.WorkFormProperties", "PropertyID", "dbo.Properties");
            DropIndex("dbo.WorkFormProperties", new[] { "PropertyID" });
            DropIndex("dbo.WorkFormProperties", new[] { "WorkFormID" });
            DropTable("dbo.WorkFormProperties");
            CreateIndex("dbo.WorkFormProperties", "Property_ID");
            CreateIndex("dbo.WorkFormProperties", "WorkForm_ID");
            AddForeignKey("dbo.WorkFormProperties", "Property_ID", "dbo.Properties", "ID", cascadeDelete: true);
            AddForeignKey("dbo.WorkFormProperties", "WorkForm_ID", "dbo.WorkForms", "ID", cascadeDelete: true);
        }
    }
}
