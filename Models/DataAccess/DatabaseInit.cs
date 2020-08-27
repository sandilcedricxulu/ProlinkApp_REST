
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProlinkApplications.Models.ActionModels;

namespace ProlinkApplications.Models.DataAccess
{
    public class DatabaseInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var students = new List<Student>
            {
                //new Student{id=12, firstNanme="Alexander", lastName="alexandra@gmail.com", s="Accounting"},
                //new Student{id=34,name="Alonso" , email="alonso@gmail.com", stream="Math and Physics"},
                //new Student{id=100,name="Anand" , email="anand@outlook.com", stream="General"}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();  
        }
    }
}