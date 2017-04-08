namespace SmartLeopard.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserDevice", "Device_Id", "dbo.Device");
            DropIndex("dbo.UserDevice", new[] { "Device_Id" });
            DropPrimaryKey("dbo.Device");
            DropPrimaryKey("dbo.UserDevice");
            AddColumn("dbo.Device", "Mac", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Device", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.UserDevice", "Device_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Device", "Id");
            AddPrimaryKey("dbo.UserDevice", new[] { "User_Id", "Device_Id" });
            CreateIndex("dbo.UserDevice", "Device_Id");
            AddForeignKey("dbo.UserDevice", "Device_Id", "dbo.Device", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDevice", "Device_Id", "dbo.Device");
            DropIndex("dbo.UserDevice", new[] { "Device_Id" });
            DropPrimaryKey("dbo.UserDevice");
            DropPrimaryKey("dbo.Device");
            AlterColumn("dbo.UserDevice", "Device_Id", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
            AlterColumn("dbo.User", "Email", c => c.String(unicode: false));
            AlterColumn("dbo.User", "Name", c => c.String(unicode: false));
            AlterColumn("dbo.Device", "Id", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
            DropColumn("dbo.Device", "Mac");
            AddPrimaryKey("dbo.UserDevice", new[] { "User_Id", "Device_Id" });
            AddPrimaryKey("dbo.Device", "Id");
            CreateIndex("dbo.UserDevice", "Device_Id");
            AddForeignKey("dbo.UserDevice", "Device_Id", "dbo.Device", "Id", cascadeDelete: true);
        }
    }
}
