namespace ProlinkApplications.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApprovedApplications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        schoolId = c.Int(nullable: false),
                        applicantId = c.Int(nullable: false),
                        schoolAdminId = c.Int(nullable: false),
                        invoice = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AwaitingApplications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        schoolId = c.Int(nullable: false),
                        applicantId = c.Int(nullable: false),
                        schoolAdminId = c.Int(nullable: false),
                        amount = c.Double(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DeclinedApplications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        schoolId = c.Int(nullable: false),
                        applicantId = c.Int(nullable: false),
                        schoolAdminId = c.Int(nullable: false),
                        invoice = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.StudentFile",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Student_id = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Student", t => t.Student_id)
                .Index(t => t.Student_id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstNanme = c.String(),
                        lastName = c.String(),
                        idNumber = c.String(),
                        email = c.String(),
                        resProof = c.String(),
                        cellNumber = c.String(),
                        grade = c.Int(nullable: false),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Gardian",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstNanme = c.String(),
                        lastName = c.String(),
                        idNumber = c.String(),
                        email = c.String(),
                        resProof = c.String(),
                        cellNumber = c.String(),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.GardianFile",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Student_id = c.Int(),
                        Gardian_id = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Student", t => t.Student_id)
                .ForeignKey("dbo.Gardian", t => t.Gardian_id)
                .Index(t => t.Student_id)
                .Index(t => t.Gardian_id);
            
            CreateTable(
                "dbo.ProlinkAdmin",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        email = c.String(),
                        idNumber = c.String(),
                        cellNumber = c.String(),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SchoolAdmin",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        email = c.String(),
                        idNumber = c.String(),
                        cellNumber = c.String(),
                        username = c.String(),
                        password = c.String(),
                        schoolId = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.School",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        cellNumber = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GardianFile", "Gardian_id", "dbo.Gardian");
            DropForeignKey("dbo.GardianFile", "Student_id", "dbo.Student");
            DropForeignKey("dbo.StudentFile", "Student_id", "dbo.Student");
            DropIndex("dbo.GardianFile", new[] { "Gardian_id" });
            DropIndex("dbo.GardianFile", new[] { "Student_id" });
            DropIndex("dbo.StudentFile", new[] { "Student_id" });
            DropTable("dbo.School");
            DropTable("dbo.SchoolAdmin");
            DropTable("dbo.ProlinkAdmin");
            DropTable("dbo.GardianFile");
            DropTable("dbo.Gardian");
            DropTable("dbo.Student");
            DropTable("dbo.StudentFile");
            DropTable("dbo.DeclinedApplications");
            DropTable("dbo.AwaitingApplications");
            DropTable("dbo.ApprovedApplications");
        }
    }
}
