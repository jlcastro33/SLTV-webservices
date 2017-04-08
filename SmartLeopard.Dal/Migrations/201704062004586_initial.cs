namespace SmartLeopard.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Device",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Status = c.Int(nullable: false),
                        Model = c.String(unicode: false),
                        FirmwareVersion = c.String(unicode: false),
                        Language = c.String(unicode: false),
                        Disabled = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Updated = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Surname = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        ZipCode = c.String(unicode: false),
                        CountryCode = c.String(unicode: false),
                        Disabled = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Updated = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDevice",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Device_Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Device_Id })
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Device", t => t.Device_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Device_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDevice", "Device_Id", "dbo.Device");
            DropForeignKey("dbo.UserDevice", "User_Id", "dbo.User");
            DropIndex("dbo.UserDevice", new[] { "Device_Id" });
            DropIndex("dbo.UserDevice", new[] { "User_Id" });
            DropTable("dbo.UserDevice");
            DropTable("dbo.User");
            DropTable("dbo.Device");
        }
    }
}
