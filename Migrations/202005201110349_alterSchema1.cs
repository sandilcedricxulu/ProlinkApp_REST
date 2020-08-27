namespace ProlinkApplications.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterSchema1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicant",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        studentId = c.String(),
                        gardianId = c.String(),
                        dateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Applicant");
        }
    }
}
