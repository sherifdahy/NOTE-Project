using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Identity;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

internal class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.HasIndex(r => r.Name).IsUnique();
        builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);

        builder.HasData(new List<ApplicationRole>()
        {
            new ApplicationRole()
            {
                Id = 1,
                Name = "Admin",
            },
            new ApplicationRole() 
            {
                Id = 2,
                Name = "User",
            }
        });
    }
}
