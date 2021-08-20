using System;
using System.Data;
using System.Data.Entity.Migrations;
using System.Windows.Controls;
using CMP332.Core;
using CMP332.Core.Data;
using CMP332.MVVM.Models.User;
using Unity;

namespace CMP332.Migrations
{
    public class Configuration :DbMigrationsConfiguration<DataContext>
    {
        private IRepository<Role> roleContext;
        private IRepository<User> userContext;
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override async void Seed(DataContext context)
        {
            this.userContext = ContainerHelper.Container.Resolve<IRepository<User>>();
            this.roleContext = ContainerHelper.Container.Resolve<IRepository<Role>>();
            Console.WriteLine(@"**************************************************************");
            Console.WriteLine(@"**         WARNING: Your database is being seeded           **");
            Console.WriteLine(@"**************************************************************");
            Role sysAdmin =  new Role("System Admin");
            Role lettingsAgent =  new Role("Lettings Agent");
            Role maintenanceStaff =  new Role("Maintenance Staff");

            roleContext.AddOrUpdate(sysAdmin);
            roleContext.AddOrUpdate(lettingsAgent);
            roleContext.AddOrUpdate(maintenanceStaff);

            await roleContext.Commit();

            User userAdmin = new User("Admin","Password99!",sysAdmin);
            User userLettingAgent = new User("LettingAgent","Password99!",lettingsAgent);
            User userMaintenance = new User("MaintenanceStaff", "Password99!",maintenanceStaff);

            userContext.AddOrUpdate(userAdmin);
            userContext.AddOrUpdate(userLettingAgent);
            userContext.AddOrUpdate(userMaintenance);

            await userContext.Commit();

            Console.WriteLine(@"**************************************************************");
            Console.WriteLine(@"**         Success: Your database has been seeded           **");
            Console.WriteLine(@"**************************************************************");
        }
    }
}