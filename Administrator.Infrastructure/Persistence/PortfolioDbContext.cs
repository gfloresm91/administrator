using Administrator.Domain.Common;
using Administrator.Domain.Portfolio;
using Microsoft.EntityFrameworkCore;

namespace Administrator.Infrastructure.Persistence
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillItem>()
                .HasOne(skillItem => skillItem.SkillDetail)
                .WithMany(skillDetail => skillDetail.SkillsItems)
                .IsRequired()
                .HasForeignKey(skillItem => skillItem.SkillDetailId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SkillDetail>()
                .HasOne(skillDetail => skillDetail.Skill)
                .WithMany(skill => skill.SkillsDetails)
                .IsRequired()
                .HasForeignKey(skillDetail => skillDetail.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Skill>()
                .HasOne(skill => skill.UserInfo)
                .WithMany(userInfo => userInfo.Skills)
                .IsRequired()
                .HasForeignKey(skill => skill.UserInfoId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<UserInfo>? UsersInfo { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillDetail> SkillsDetails { get; set; }
        public DbSet<SkillItem> SkillsItems { get; set; }
    }
}
