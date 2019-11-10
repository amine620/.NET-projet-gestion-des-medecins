using Microsoft.Owin;
using Owin;
using siteweb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(siteweb.Startup))]
namespace siteweb
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }
        public void CreateDefaultRolesAndUsers()
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            IdentityRole Role = new IdentityRole();

            if (!RoleManager.RoleExists("Admins"))
            {
                Role.Name = "Admins";
                RoleManager.Create(Role);

                ApplicationUser user = new ApplicationUser();

                user.UserName = "Mourid";
                user.Email = "Mourid@Amine.com";
               
                var check = userManager.Create(user,"Amin@@@");

                if (check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admins");

                }

            }
        }
    }
}
