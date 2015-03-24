namespace TSRD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Amount = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RMAForms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Contact = c.String(),
                        ContactInfo = c.String(),
                        RMATime = c.DateTime(nullable: false),
                        ReturnTime = c.DateTime(nullable: false),
                        Closed = c.Boolean(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        Consumable_ID = c.Int(),
                        Property_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Consumables", t => t.Consumable_ID)
                .ForeignKey("dbo.Properties", t => t.Property_ID)
                .Index(t => t.Consumable_ID)
                .Index(t => t.Property_ID);
            
            CreateTable(
                "dbo.WorkFormConsumables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        Consumable_ID = c.Int(),
                        WorkForm_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Consumables", t => t.Consumable_ID)
                .ForeignKey("dbo.WorkForms", t => t.WorkForm_ID)
                .Index(t => t.Consumable_ID)
                .Index(t => t.WorkForm_ID);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Specification = c.String(),
                        SN = c.String(),
                        MACAddress = c.String(),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        PropertyType_ID = c.Int(),
                        Unit_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyType_ID)
                .ForeignKey("dbo.Units", t => t.Unit_ID)
                .Index(t => t.PropertyType_ID)
                .Index(t => t.Unit_ID);
            
            CreateTable(
                "dbo.WorkFormProperties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        Property_ID = c.Int(),
                        WorkForm_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Properties", t => t.Property_ID)
                .ForeignKey("dbo.WorkForms", t => t.WorkForm_ID)
                .Index(t => t.Property_ID)
                .Index(t => t.WorkForm_ID);
            
            CreateTable(
                "dbo.PropertyTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IDString = c.String(),
                        Floor = c.String(),
                        Area = c.String(),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WorkForms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Accepted_time = c.DateTime(nullable: false),
                        Closed_time = c.DateTime(nullable: false),
                        Closed = c.Boolean(nullable: false),
                        Type = c.String(),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                        Unit_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Units", t => t.Unit_ID)
                .Index(t => t.Unit_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkForms", "Unit_ID", "dbo.Units");
            DropForeignKey("dbo.WorkFormProperties", "WorkForm_ID", "dbo.WorkForms");
            DropForeignKey("dbo.WorkFormConsumables", "WorkForm_ID", "dbo.WorkForms");
            DropForeignKey("dbo.Properties", "Unit_ID", "dbo.Units");
            DropForeignKey("dbo.Properties", "PropertyType_ID", "dbo.PropertyTypes");
            DropForeignKey("dbo.WorkFormProperties", "Property_ID", "dbo.Properties");
            DropForeignKey("dbo.RMAForms", "Property_ID", "dbo.Properties");
            DropForeignKey("dbo.WorkFormConsumables", "Consumable_ID", "dbo.Consumables");
            DropForeignKey("dbo.RMAForms", "Consumable_ID", "dbo.Consumables");
            DropIndex("dbo.WorkForms", new[] { "Unit_ID" });
            DropIndex("dbo.WorkFormProperties", new[] { "WorkForm_ID" });
            DropIndex("dbo.WorkFormProperties", new[] { "Property_ID" });
            DropIndex("dbo.Properties", new[] { "Unit_ID" });
            DropIndex("dbo.Properties", new[] { "PropertyType_ID" });
            DropIndex("dbo.WorkFormConsumables", new[] { "WorkForm_ID" });
            DropIndex("dbo.WorkFormConsumables", new[] { "Consumable_ID" });
            DropIndex("dbo.RMAForms", new[] { "Property_ID" });
            DropIndex("dbo.RMAForms", new[] { "Consumable_ID" });
            DropTable("dbo.WorkForms");
            DropTable("dbo.Units");
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.WorkFormProperties");
            DropTable("dbo.Properties");
            DropTable("dbo.WorkFormConsumables");
            DropTable("dbo.RMAForms");
            DropTable("dbo.Consumables");
        }
    }
}
