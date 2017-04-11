namespace SmartLeopard.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tracing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "tracing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EndpointWithoutParams = c.String(unicode: false),
                        Method = c.String(unicode: false),
                        EndpointParams = c.String(unicode: false),
                        RequestContent = c.String(unicode: false),
                        ResponseStatusCode = c.String(unicode: false),
                        ResponseContent = c.String(unicode: false),
                        ProcessTimeMls = c.Double(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Updated = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("tracing");
        }
    }
}
