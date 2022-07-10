using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Administrator.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "4281262f-47a6-40a8-b370-349f09777dc9",
                        UserId = "2b0aeb96-8d9a-4bd3-9937-dfa4641af57b"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "6707dec1-06d7-4ca1-8fa9-3024916da8bf",
                        UserId = "2d9d1a43-564e-4f37-a57a-983dbe63b172"
                    }
                );
        }
    }
}
