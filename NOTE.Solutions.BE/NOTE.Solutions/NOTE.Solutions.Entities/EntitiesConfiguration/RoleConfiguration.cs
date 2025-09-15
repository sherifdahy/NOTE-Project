using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NOTE.Solutions.Entities.Entities.Identity;
using NOTE.Solutions.Entities.Enums;

namespace NOTE.Solutions.Entities.EntitiesConfiguration;

internal class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.HasData(new List<ApplicationRole>()
        {
            new ApplicationRole()
            {
                Id = 1,
                Role = RoleType.Admin,
            },
            new ApplicationRole() 
            {
                Id = 2,
                Role = RoleType.Customer,
            },
        });

    }
}
