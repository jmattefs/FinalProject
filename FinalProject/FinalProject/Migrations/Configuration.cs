namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FinalProject.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinalProject.Models.ApplicationDbContext context)
        {
            context.JobSeeker.AddOrUpdate(x => x.ID,
                new JobSeeker { Name = "John Smith", Address = "123 N 45 st", City = "Milwaukee", State = "WI", ZipCode = "53209", Email = "johnsmith@aol.com", Info = "Please hire me", Survey1Score = 2, Survey2Score = "Agreeable", Survey3Score = "Excellent", ID = 1, UserId = "abcdedfdd3fg", Survey1Complete = true, Survey2Complete = true, Survey3Complete = true, Test2ScoreINT = 4, Test3ScoreINT = 5, },
                new JobSeeker { Name = "Jane Smith", Address = "523 N 21 st", City = "Milwaukee", State = "WI", ZipCode = "53202", Email = "janesmith@gmail.com", Info = "I am super cool and have lots of job experience.", Survey1Score = 4, Survey2Score = "Extrovert", Survey3Score = "Good", ID = 2, UserId = "adbcdfdefg", Survey1Complete = true, Survey2Complete = true, Survey3Complete = true, Test2ScoreINT = 3, Test3ScoreINT = 4, },
                new JobSeeker { Name = "Brett Favre", Address = "543 N 21 st", City = "Kiln", State = "MI", ZipCode = "39556", Email = "brettfavreGOAT@yahoo.com", Info = "I am looking for a fresh start.", Survey1Score = 3, Survey2Score = "Neurotic", Survey3Score = "Average", ID = 3, UserId = "abcdefg", Survey1Complete = true, Survey2Complete = true, Survey3Complete = true, Test2ScoreINT = 5, Test3ScoreINT = 3, },
                new JobSeeker { Name = "John Doe", Address = "5423 N 33 st", City = "Mequon", State = "WI", ZipCode = "53223", Email = "genericjobseeker@gmail.com", ID = 4, UserId = "c7622777-d4d7-4620-bf6f-154963208d8e", Survey1Complete = false, Survey2Complete = false, Survey3Complete = false }
                );
            context.Employer.AddOrUpdate(x => x.ID,
                new Employer { Name = "CompanyA", Address = "1123 N 75 st", City = "Milwaukee", State = "WI", ZipCode = "53209", Info = "We are a great company to work for!", UserId = "aaazaazanfn39392" , ID= 1},
                  new Employer { Name = "CompanyB", Address = "23 N 85 st", City = "New Berlin", State = "WI", ZipCode = "53209", Info = "We pay our employees lots of money", UserId = "bbbaazanfn39392", ID=2, },
                    new Employer { Name = "CompanyC", Address = "333 N 115 st", City = "Brown Deer", State = "WI", ZipCode = "53223", Info = "We make super cool things at CompanyC", UserId = "cccaza39392", ID=3 },
                     new Employer { Name = "CompanyD", Email = "genericemployer@gmail.com", Address = "333 N 115 st", City = "Brown Deer", State = "WI", ZipCode = "53223", Info = "We do great things here at CompanyXYZ", UserId = "ddddaza39392", ID = 3 }
                );
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            ApplicationUser js = new ApplicationUser { Email = "genericjobseeker@gmail.com", Role = 1, Name = "Jabari Parker", Address = "5423 N 33 st", City = "Mequon", State = "WI", ZipCode = "53223", UserName = "genericjobseeker@gmail.com", Id= "c7622777-d4d7-4620-bf6f-154963208d8e" };
            userManager.Create(js, "000000");

            ApplicationUser e = new ApplicationUser { Email = "genericemployer@gmail.com", Role = 2, Name = "Company XYZ", UserName = "genericemployer@gmail.com", Id = "ddddaza39392", Address = "333 N 115 st", City = "Brown Deer", State = "WI", ZipCode = "53223" };
            userManager.Create(e, "000000");

            context.Jobs.AddOrUpdate(x => x.ID,
                new Job { Title = "Job X", Description = "You will have to do a lot of different things for this job.", CompanyID = "aaazaazanfn39392", ID = 1, TestAScore = 2, TestBScore = 0, TestCScore = 3, Company = "CompanyA" },
                new Job { Title = "Job Y", Description = "You will need to make calls from a list and sell Product XYZ.", CompanyID = "bbbaazanfn39392", ID = 2, TestAScore = 3, TestBScore = 3, TestCScore = 4, Company = "CompanyB" },
                new Job { Title = "Job Z", Description = "This job requires you to sort mail.", CompanyID = "cccaza39392", ID = 3, TestAScore = 0, TestBScore = 0, TestCScore = 0, Company = "CompanyC" },

                 new Job { Title = "Job XYZ", Description = "You will need to fill out forms.", CompanyID = "ddddaza39392", ID = 4, TestAScore = 0, TestBScore = 0, TestCScore = 0, Company = "CompanyD" }
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
