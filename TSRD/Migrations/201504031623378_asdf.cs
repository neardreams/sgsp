namespace TSRD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NO = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ConsumableForms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ConsumableID = c.Int(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Consumables", t => t.ConsumableID, cascadeDelete: true)
                .Index(t => t.ConsumableID);
            
            CreateTable(
                "dbo.RMAForms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Contact = c.String(),
                        ContactInfo = c.String(),
                        RMATime = c.DateTime(),
                        ReturnTime = c.DateTime(),
                        Closed = c.Boolean(nullable: false),
                        PropertyID = c.Int(),
                        ConsumableID = c.Int(),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Consumables", t => t.ConsumableID)
                .ForeignKey("dbo.Properties", t => t.PropertyID)
                .Index(t => t.PropertyID)
                .Index(t => t.ConsumableID);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Specification = c.String(),
                        SN = c.String(),
                        NO = c.String(),
                        MACAddress = c.String(),
                        Disabled = c.Boolean(nullable: false),
                        PropertyTypeID = c.Int(nullable: false),
                        UnitID = c.Int(),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitID)
                .Index(t => t.PropertyTypeID)
                .Index(t => t.UnitID);
            
            CreateTable(
                "dbo.PropertyTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Company = c.String(),
                        Contact = c.String(),
                        ContactInfo = c.String(),
                        IDString = c.String(nullable: false),
                        Floor = c.String(nullable: false),
                        Area = c.String(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WorkForms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contact = c.String(nullable: false),
                        AcceptedTime = c.DateTime(nullable: false),
                        ClosedTime = c.DateTime(),
                        Closed = c.Boolean(nullable: false),
                        WorkFormType = c.Int(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Units", t => t.UnitID, cascadeDelete: true)
                .Index(t => t.UnitID);
            
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
            
            CreateTable(
                "dbo.WorkFormConsumables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WorkFormID = c.Int(nullable: false),
                        ConsumableID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Consumables", t => t.ConsumableID, cascadeDelete: true)
                .ForeignKey("dbo.WorkForms", t => t.WorkFormID, cascadeDelete: true)
                .Index(t => t.WorkFormID)
                .Index(t => t.ConsumableID);
            
            CreateTable(
                "dbo.PropertyForms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Properties", t => t.PropertyID, cascadeDelete: true)
                .Index(t => t.PropertyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyForms", "PropertyID", "dbo.Properties");
            DropForeignKey("dbo.WorkFormConsumables", "WorkFormID", "dbo.WorkForms");
            DropForeignKey("dbo.WorkFormConsumables", "ConsumableID", "dbo.Consumables");
            DropForeignKey("dbo.WorkFormProperties", "WorkFormID", "dbo.WorkForms");
            DropForeignKey("dbo.WorkFormProperties", "PropertyID", "dbo.Properties");
            DropForeignKey("dbo.WorkForms", "UnitID", "dbo.Units");
            DropForeignKey("dbo.Properties", "UnitID", "dbo.Units");
            DropForeignKey("dbo.RMAForms", "PropertyID", "dbo.Properties");
            DropForeignKey("dbo.Properties", "PropertyTypeID", "dbo.PropertyTypes");
            DropForeignKey("dbo.RMAForms", "ConsumableID", "dbo.Consumables");
            DropForeignKey("dbo.ConsumableForms", "ConsumableID", "dbo.Consumables");
            DropIndex("dbo.PropertyForms", new[] { "PropertyID" });
            DropIndex("dbo.WorkFormConsumables", new[] { "ConsumableID" });
            DropIndex("dbo.WorkFormConsumables", new[] { "WorkFormID" });
            DropIndex("dbo.WorkFormProperties", new[] { "PropertyID" });
            DropIndex("dbo.WorkFormProperties", new[] { "WorkFormID" });
            DropIndex("dbo.WorkForms", new[] { "UnitID" });
            DropIndex("dbo.Properties", new[] { "UnitID" });
            DropIndex("dbo.Properties", new[] { "PropertyTypeID" });
            DropIndex("dbo.RMAForms", new[] { "ConsumableID" });
            DropIndex("dbo.RMAForms", new[] { "PropertyID" });
            DropIndex("dbo.ConsumableForms", new[] { "ConsumableID" });
            DropTable("dbo.PropertyForms");
            DropTable("dbo.WorkFormConsumables");
            DropTable("dbo.WorkFormProperties");
            DropTable("dbo.WorkForms");
            DropTable("dbo.Units");
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.Properties");
            DropTable("dbo.RMAForms");
            DropTable("dbo.ConsumableForms");
            DropTable("dbo.Consumables");
        }
    }
}
