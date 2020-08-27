namespace ProlinkApplications.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BannedApplications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        applicantId = c.String(),
                        reason = c.String(),
                        dateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BannedApplications");
        }
    }
}
