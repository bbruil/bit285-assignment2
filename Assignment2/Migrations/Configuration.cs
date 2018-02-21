namespace Assignment2.Migrations
{
    using Assignment2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment2.Models.VisitorLogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Assignment2.Models.VisitorLogContext";
        }

        protected override void Seed(Assignment2.Models.VisitorLogContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Users.AddOrUpdate(u => u.UserID,
            new User()
            {
                UserID = 1,
                Email = "callme@yahool.com",
                FirstName = "Tom",
                LastName = "Jones",
                LoggedIn = true,
                ProgramID = 3,
                EmailUpdates = false,
                Password = "secretword"
            },
            new User()
            {
                UserID = 2,
                Email = "yesterday@gmail.com",
                FirstName = "Harry",
                LastName = "Junior",
                LoggedIn = false,
                ProgramID = 2,
                EmailUpdates = false,
                Password = "Holiday"
            }
            );

            context.Programs.AddOrUpdate(p => p.ProgramID,
            new Program()
            {
                ProgramID = 1,
                ProgramName = "Web Developer Degree"
            },
            new Program()
            {
                ProgramID = 2,
                ProgramName = "ETSP Degree"
            },
            new Program()
            {
                ProgramID = 3,
                ProgramName = "ETSP Degree"
            },
            new Program()
            {
                ProgramID = 4,
                ProgramName = "Network Technology Degree"
            }
            );





                
            
            
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
