namespace Database.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<SOSFeevaleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SOSFeevaleContext context)
        {
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
            
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                CriarRolesPerfils(context);
                var store = new UserStore<Usuario>(context);
                var manager = new UserManager<Usuario>(store);
                var user = new Usuario
                {
                    UserName = "admin"
                };

                manager.Create(user, "adm123");
                manager.AddToRole(user.Id, "Admin");
                context.SaveChanges();
            }
        }

        private void CriarRolesPerfils(SOSFeevaleContext context)
        {
            var nomes = new string[] {
                "Admin",
                "User",
                "Company"
            };

            foreach (var nome in nomes)
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = nome };

                manager.Create(role);
            }

            context.SaveChanges();
        }
    }
}
