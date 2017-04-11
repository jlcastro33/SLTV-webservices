namespace SmartLeopard.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mac = c.String(nullable: false, unicode: false),
                        Status = c.Int(nullable: false),
                        Model = c.String(unicode: false),
                        FirmwareVersion = c.String(unicode: false),
                        Language = c.String(unicode: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Updated = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Surname = c.String(unicode: false),
                        Email = c.String(nullable: false, unicode: false),
                        Password = c.String(unicode: false),
                        ZipCode = c.String(unicode: false),
                        CountryCode = c.String(unicode: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Updated = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "UserDevice",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Device_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Device_Id });
            
        }
        
        public override void Down()
        {
            DropForeignKey("UserDevice", "FK_dbo.UserDevice_dbo.devices_Device_Id");
            DropForeignKey("UserDevice", "FK_dbo.UserDevice_dbo.users_User_Id");
            DropIndex("UserDevice", new[] { "Device_Id" });
            DropIndex("UserDevice", new[] { "User_Id" });
            DropTable("UserDevice");
            DropTable("users");
            DropTable("devices");
        }
    }
}
