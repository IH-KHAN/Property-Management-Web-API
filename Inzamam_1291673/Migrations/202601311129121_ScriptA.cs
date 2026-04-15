namespace Inzamam_1291673.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        FeatureId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeatureId)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        PropertyId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 70),
                        ListedDate = c.DateTime(nullable: false, storeType: "date"),
                        AskingPrice = c.Decimal(nullable: false, storeType: "money"),
                        IsRental = c.Boolean(nullable: false),
                        Picture = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Features", "PropertyId", "dbo.Properties");
            DropIndex("dbo.Features", new[] { "PropertyId" });
            DropTable("dbo.Properties");
            DropTable("dbo.Features");
        }
    }
}
