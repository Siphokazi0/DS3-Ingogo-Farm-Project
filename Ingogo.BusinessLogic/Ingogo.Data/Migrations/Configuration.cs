using System.Data.Entity.Migrations;
using Ingogo.Data.Context;
using Ingogo.Data.Employee_Management.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ingogo.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        bool AddUserAndRole(ApplicationDbContext context)
        {
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            IdentityResult ir = rm.Create(new IdentityRole("Owner"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser
            {
                Email = "ingogofarm@outlook.com",
                UserName = "ingogofarm@outlook.com"
                //password Zxcvbnm,1
            };
            ir = um.Create(user, "Ingogo2015");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "Owner");
            return ir.Succeeded;
        }
        
        protected override void Seed(ApplicationDbContext context)
        {
            AddUserAndRole(context);
        }
    }
}
