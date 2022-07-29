using Administrator.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Administrator.Identity
{
    public class AdministratorIdentityDbContext : IdentityDbContext
    {
        public AdministratorIdentityDbContext(DbContextOptions<AdministratorIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<RefreshToken>? RefreshTokens { get; set; }
        public virtual DbSet<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
