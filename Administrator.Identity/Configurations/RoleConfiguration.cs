using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Administrator.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole
                    {
                        Id = "4281262f-47a6-40a8-b370-349f09777dc9",
                        Name = "Administrador",
                        NormalizedName = "ADMINISTRADOR"
                    },
                    new IdentityRole
                    {
                        Id = "6707dec1-06d7-4ca1-8fa9-3024916da8bf",
                        Name = "Normal",
                        NormalizedName = "NORMAL"
                    }
                );
        }
    }
}
