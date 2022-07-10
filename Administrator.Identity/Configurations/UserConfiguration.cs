using Administrator.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Administrator.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                    new ApplicationUser
                    {
                        Id = "2b0aeb96-8d9a-4bd3-9937-dfa4641af57b",
                        Email = "admin@test.com",
                        NormalizedEmail = "admin@test.com",
                        Name = "Gabriel",
                        LastName = "Flores",
                        UserName = "gabrielflores",
                        NormalizedUserName = "gabrielflores",
                        PasswordHash = hasher.HashPassword(null, "Yourpassword123"),
                        EmailConfirmed = true,
                    },
                    new ApplicationUser
                    {
                        Id = "2d9d1a43-564e-4f37-a57a-983dbe63b172",
                        Email = "test@test.com",
                        NormalizedEmail = "test@test.com",
                        Name = "Test",
                        LastName = "User 1",
                        UserName = "testuser1",
                        NormalizedUserName = "testuser1",
                        PasswordHash = hasher.HashPassword(null, "Yourpassword123"),
                        EmailConfirmed = true,
                    }
                );
        }
    }
}
