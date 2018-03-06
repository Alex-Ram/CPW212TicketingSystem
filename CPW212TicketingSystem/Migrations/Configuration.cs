using System.Collections.Generic;

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
            Role admin = new Role(id: 1, name: "Admin", editUsers: true, delete: true, editRoles: true, isTech: true,
                level: 3, assign: true, priority: true);
            Role tech = new Role(id: 2, name: "Technician", editUsers: true, delete: true, editRoles: false, isTech: true,
                level: 2, assign: true, priority: true);
            Role user = new Role(id: 3, name: "User", editUsers: false, delete: false, editRoles: false, isTech: false,
                level: 1, assign: false, priority: false);

            context.Users.AddOrUpdate(u => u.UserID,

                new User(id: 1, fname:"Alex", lname:"Ramirez", password:"123", username:"Aramirez", tickets: new List<Ticket>(), role: admin ),
                new User(id: 2, fname: "Devon", lname: "Thompson", password: "123", username: "Dthompson", tickets: new List<Ticket>(), role: tech),
                new User(id: 3, fname: "Chad", lname: "Meow", password: "123", username: "Cmeow", tickets: new List<Ticket>(), role: user)
            );

            context.Priorities.AddOrUpdate(p => p.PriorityID,
                new Priority (id:  1, name: "Critical", level: 3),
                new Priority (id: 2, name: "Medium", level: 2),
                new Priority (id: 3, name: "Low", level: 1)
            );
            //context.Tickets.AddOrUpdate();


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
