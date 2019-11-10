using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace siteweb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string type { get; set; }
        public virtual ICollection<Medcine> Medcines { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<siteweb.Models.Medcine> Medcines { get; set; }

        public System.Data.Entity.DbSet<siteweb.Models.Sexe> Sexes { get; set; }

        public System.Data.Entity.DbSet<siteweb.Models.Specialite> Specialites { get; set; }

        public System.Data.Entity.DbSet<siteweb.Models.Ville> Villes { get; set; }

        public System.Data.Entity.DbSet<siteweb.Models.RoleViewModel> RoleViewModels { get; set; }

        public System.Data.Entity.DbSet<siteweb.Models.rendez_vous> rendez_vous { get; set; }

    }
}