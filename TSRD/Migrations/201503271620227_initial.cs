namespace TSRD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                        Amount = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        CreatedTime = c.DateTime(nullable: false),
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
                        Specification = c.String(),
                        SN = c.String(),
                        NO = c.String(),
                        MACAddress = c.String(),
                        PropertyTypeID = c.Int(),
                        UnitID = c.Int(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyTypeID)
                .ForeignKey("dbo.Units", t => t.UnitID, cascadeDelete: true)
                .Index(t => t.PropertyTypeID)
                .Index(t => t.UnitID);
            
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
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Company = c.String(),
                        Contact = c.String(),
                        ContactInfo = c.String(),
                        IDString = c.String(),
                        Floor = c.String(),
                        Area = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WorkForms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contact = c.String(),
                        AcceptedTime = c.DateTime(nullable: false),
                        ClosedTime = c.DateTime(),
                        Closed = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
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
                        Amount = c.Int(nullable: false),
                        PropertyID = c.Int(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Properties", t => t.PropertyID, cascadeDelete: true)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.WorkFormConsumables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ConsumableID = c.Int(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Consumables", t => t.ConsumableID, cascadeDelete: true)
                .Index(t => t.ConsumableID);
            
            CreateTable(
                "dbo.ConsumableForms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ConsumableID = c.Int(nullable: false),
                        Description = c.String(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Consumables", t => t.ConsumableID, cascadeDelete: true)
                .Index(t => t.ConsumableID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConsumableForms", "ConsumableID", "dbo.Consumables");
            DropForeignKey("dbo.WorkFormConsumables", "ConsumableID", "dbo.Consumables");
            DropForeignKey("dbo.WorkFormProperties", "PropertyID", "dbo.Properties");
            DropForeignKey("dbo.WorkForms", "UnitID", "dbo.Units");
            DropForeignKey("dbo.Properties", "UnitID", "dbo.Units");
            DropForeignKey("dbo.RMAForms", "PropertyID", "dbo.Properties");
            DropForeignKey("dbo.Properties", "PropertyTypeID", "dbo.PropertyTypes");
            DropForeignKey("dbo.RMAForms", "ConsumableID", "dbo.Consumables");
            DropIndex("dbo.ConsumableForms", new[] { "ConsumableID" });
            DropIndex("dbo.WorkFormConsumables", new[] { "ConsumableID" });
            DropIndex("dbo.WorkFormProperties", new[] { "PropertyID" });
            DropIndex("dbo.WorkForms", new[] { "UnitID" });
            DropIndex("dbo.Properties", new[] { "UnitID" });
            DropIndex("dbo.Properties", new[] { "PropertyTypeID" });
            DropIndex("dbo.RMAForms", new[] { "ConsumableID" });
            DropIndex("dbo.RMAForms", new[] { "PropertyID" });
            DropTable("dbo.ConsumableForms");
            DropTable("dbo.WorkFormConsumables");
            DropTable("dbo.WorkFormProperties");
            DropTable("dbo.WorkForms");
            DropTable("dbo.Units");
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.Properties");
            DropTable("dbo.RMAForms");
            DropTable("dbo.Consumables");
        }
    }
}
