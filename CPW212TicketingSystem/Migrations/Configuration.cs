namespace CPW212TicketingSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CPW212TicketingSystem.TicketingSystemDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CPW212TicketingSystem.TicketingSystemDBContext context)
        {
            context.Roles.AddOrUpdate(r => r.RoleID,
                new Role { RoleID = 1, Name = "Admin", IsTechnician = true, CanAssignTickets = true, CanEditUsers = true, CanDeleteTickets = true, CanEditRoles = true, CanChangePriority = true, Level = 3 },
                new Role { RoleID = 2, Name = "Tech", IsTechnician = true, CanAssignTickets = true, CanEditUsers = true, CanDeleteTickets = false, CanEditRoles = false, CanChangePriority = true, Level = 2 },
                new Role { RoleID = 3, Name = "Admin", IsTechnician = false, CanAssignTickets = false, CanEditUsers = false, CanDeleteTickets = true, CanEditRoles = false, CanChangePriority = false, Level = 1 }
            );
            context.Users.AddOrUpdate(u => u.UserID,
                new User {UserID = 1, FirstName = "Alex", LastName = "Ramirez", Password = "123", Username = "Aramirez", Role = , AssignedTickets = null},
                new User { UserID = 2, FirstName = "Devon", LastName = "Thompson", Username = "Dthompson", Password = "123", Role = 2, AssignedTickets = null},
                new User { UserID = 3, FirstName = "Chad", LastName = "meow", Username = "Cmeow", Password = "123", Role = 1, AssignedTickets = null}

            
            );

            context.Priorities.AddOrUpdate(p => p.PriorityID,
                new Priority { PriorityID = 1, Name = "Critical", Level = 3},
                new Priority { PriorityID = 2, Name = "Medium", Level = 2},
                new Priority { PriorityID = 3, Name = "Low", Level = 1}
            );
            context.Tickets.AddOrUpdate();


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
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
