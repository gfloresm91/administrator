using Administrator.Identity.Configurations;
using Administrator.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Administrator.Identity
{
    public class AdministratorIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AdministratorIdentityDbContext(DbContextOptions<AdministratorIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
