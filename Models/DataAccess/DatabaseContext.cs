using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProlinkApplications.Models.ActionModels;
using ProlinkApplications.Models.Files;
using System.IO;

namespace ProlinkApplications.Models.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {
        }

        public DbSet<StudentFile> Files { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SchoolAdmin> SchoolAdmins { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<ProlinkAdmin> ProlinkAdmins { get; set; }
        public DbSet<Gardian> Gardians { get; set; }
        public DbSet<DeclinedApplications> DeclinedApplications { get; set; }
        public DbSet<AwaitingApplications> AwaitingApplications { get; set; }
        public DbSet<ApprovedApplications> ApprovedApplications { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<BannedApplications> BannedApplications { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}