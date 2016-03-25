namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FinalProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinalProject.Models.ApplicationDbContext context)
        {
            context.JobSeeker.AddOrUpdate(x => x.ID,
                new JobSeeker { Name = "John Smith", Address = "123 N 45 st", City = "Milwaukee", State = "WI", ZipCode = "53209", Email = "johnsmith@aol.com", Info = "Please hire me", Survey1Score = 2, Survey2Score = "Agreeable", Survey3Score = "Excellent", ID = 1 , UserId = "abcdedfdd3fg" },
                new JobSeeker { Name = "Jane Smith", Address = "543 N 21 st", City = "Milwaukee", State = "WI", ZipCode = "53202", Email = "janesmith@gmail.com", Info = "I am super cool and have lots of job experience.", Survey1Score = 4, Survey2Score = "Extrovert", Survey3Score = "Good", ID = 2, UserId = "adbcdfdefg" },
                new JobSeeker { Name = "Brett Favre", Address = "543 N 21 st", City = "Kiln", State = "MI", ZipCode = "39556", Email = "brettfavreGOAT@yahoo.com", Info = "I am looking for a fresh start.", Survey1Score = 3, Survey2Score = "Neurotic", Survey3Score = "Average", ID = 3, UserId= "abcdefg" }
                );

            

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
